using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using ModulManagementSystem.Models;
using ModulManagementSystem.Core.DBOperations;
using System.Data.Linq;
using System.Data.Entity;

namespace ModulManagementSystem
{
    public partial class ModulErstellen : System.Web.UI.Page
    {
        List<ModulPartDescription> defaultMPDs = GlobalNames.getDefaultDescriptions();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!HttpContext.Current.User.IsInRole("Modulverantwortlicher"))
            {
                Response.Redirect("Default.aspx");
            }
            if (!IsPostBack)
            {
                Session["MPD"] = defaultMPDs;
                Session["CurrentIndex"] = 0;
                Session["Subjects"] = null;
                Session["Subjects"] = GetSubjects();
                DropDownList.DataSource = GetModulhandbooks();
                DropDownList.DataBind();
                DropDownList.SelectedValue = Request.QueryString["ModulhandbookID"];
                NameTextBox.Text = defaultMPDs.First().Name;
                DescriptionTextBox.Text = defaultMPDs.First().Description;  
            }
            else 
            {
                if (Session["Message"] != null && (bool)Session["Message"])
                {
                    ErrorLabel.Visible = false;
                    Session["Message"] = false;
                }
            }
            DrawTable();
            DrawSubjects();
        }

        /// <summary>
        /// Saves the new Modul if the input was valid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AdoptBtn_Click(object sender, EventArgs e)
        {
            if(CheckDescriptions())
            {
                int indexOfCurrentModulpunkt = GetCurrentIndex();
                List<ModulPartDescription> list = GetModulpartDescriptions();
                list[indexOfCurrentModulpunkt].Name = NameTextBox.Text;
                list[indexOfCurrentModulpunkt].Description = DescriptionTextBox.Text;
                var mu = System.Web.Security.Membership.GetUser();
                Guid owner = (Guid)mu.ProviderUserKey;
                ArchiveLogic al=new ArchiveLogic();
                JobLogic jl = new JobLogic();
                List<Subject> subjects = GetSubjects();
                Modul newModule = al.CreateModul(list, ModulState.created, owner, owner, DateTime.Now, subjects, 1);
                Session["Message"] = true;
                if (newModule != null)
                {
                    CheckforMessage("Neues Modul erstellt!");
                    jl.CreateNewJob(ModulState.created, list, newModule, owner);
                }
                else 
                {
                    CheckforMessage("Ein Fehler ist aufgetreten. Es wurde kein Modul erstellt!");
                }   
            }
        }

        /// <summary>
        /// Checks the User input
        /// </summary>
        /// <returns>Returns true, if everything is fine</returns>
        public bool CheckDescriptions()
        {
            List<ModulPartDescription> descriptions = GetModulpartDescriptions();
            for (int i = 0; i < descriptions.Count; i++)
            {
                //Check for undone mandatory fields
                if (descriptions[i].IsNeeded)
                {
                    if (descriptions[i].Description.Equals(defaultMPDs[i].Description))
                    {
                        Session["Message"] = true;
                        CheckforMessage("Ein Pflichtfeld muss noch bearbeitet werden");
                        jumpToDescription(i);
                        return false;
                    }
                }

                //Check double Modules
                if (descriptions[i].Name.Equals(GlobalNames.getModulNameText()))
                {
                    ModulhandbookContext mhc = new ModulhandbookContext();
                    ArchiveLogic al=new ArchiveLogic();
                    List<Modul> list = mhc.Modules.ToList<Modul>();
                
                    foreach (Modul m in list)
                    {
                        if (descriptions[i].Description == al.getNameFromModule(m))
                        {
                            Session["Message"] = true;
                            CheckforMessage("Ein Modul mit diesem Namen existiert schon!");
                            jumpToDescription(i);
                            return false;
                        }
                    }
                }

                //Check for invalide Types
                if (descriptions[i].Name.Equals(GlobalNames.getModulNameECTS()) 
                    || descriptions[i].Name.Equals(GlobalNames.getModulNameWeekHours())
                    || descriptions[i].Name.Equals(GlobalNames.getModulNameEffort()))
                {
                    double Num;
                    bool isNum = double.TryParse(descriptions[i].Description, out Num);

                    if (!isNum)
                    {
                        Session["Message"] = true;
                        CheckforMessage("Der Modulpunkt muss eine Zahl enthalten");
                        jumpToDescription(i);
                        return false;
                    }
                }

            }
            //Check the Subjects
            List<Subject> subjects = GetSubjects();
            //At least one Subject must be chosen
            if (subjects.Count < 1)
            {
                Session["Message"] = true;
                CheckforMessage("Sie wüssen mindestens ein Fach für das Modul festlegen!");
                return false;
            }

            //A Module cannot exist more then once inside a Modulhandbook
            if (subjects.Count >= 2)
            {
                for (int i = 0; i < subjects.Count; i++)
                {
                    Modulhandbook m = subjects[i].Modulhandbook;
                    for (int j = 1 + 1; j < subjects.Count;j++)
                    {
                        if (m == subjects[j].Modulhandbook)
                        {
                            Session["Message"] = true;
                            CheckforMessage("Ein Modul kann nicht zweimal im gleichen Modulhandbuch auftreten!");
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// The 'Abbrechen'-Button was clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        /// <summary>
        /// The 'Weiter'-Button was clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void FurtherBtn_Click(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            int indexOfCurrentModulpunkt = GetCurrentIndex();
            int indexOfNextModulpunkt = indexOfCurrentModulpunkt + 1;
            List<ModulPartDescription> list = GetModulpartDescriptions();

            if (indexOfNextModulpunkt >= list.Count)
            {
                jumpToDescription(indexOfCurrentModulpunkt);
            }
            else
            {
                jumpToDescription(indexOfNextModulpunkt);
            }
        }

        protected void Modulpunkt_Click(object sender, EventArgs e)
        {
            LinkButton link=sender as LinkButton;
            jumpToDescription(int.Parse(link.ID.Substring(10)));

        }

        /// <summary>
        /// This Methode draws the ModulpunktTable
        /// </summary>
        private void DrawTable()
        {
            List<ModulPartDescription> list = GetModulpartDescriptions();
            int rows = 0;
            if (list != null)
            {
                rows=list.Count;
            }
            for (int i = 0; i < rows; i++)
            {
                TableCell tc = new TableCell();
                if (list != null)
                {
                    if (list[i] != null)
                    {
                        LinkButton link = new LinkButton();
                        link.Text = list[i].Name;
                        link.ID = "Modulpunkt" + i;
                        link.Click += Modulpunkt_Click;
                        tc.Controls.Add(link);
                    }
                }

                TableCell tc2 = new TableCell();
                if (DescriptionDone(list[i], defaultMPDs[i].Description))
                {
                    Image icon = new Image();
                    icon.ImageUrl = "~/Images/haken.gif";
                    tc2.Controls.Add(icon);
                }

                TableRow tr = new TableRow();
                tr.Cells.Add(tc);
                tr.Cells.Add(tc2);
                ModulpunkteTable.Rows.Add(tr);
            }
            LinkButton linkSelected = (LinkButton)ModulpunkteTable.FindControl("Modulpunkt" + GetCurrentIndex());
            linkSelected.Style.Value = "background-color:yellow";
        }

        private int GetCurrentIndex()
        {
            if (Session["CurrentIndex"] != null)
            {
                return (int)Session["CurrentIndex"];
            }
            else 
            {
                return 0;
            }
        }
        /// <summary>
        /// Returns the List of Modulpartdescriptions, which are stored in the "MPD" Cookie
        /// </summary>
        /// <returns></returns>
        private List<ModulPartDescription> GetModulpartDescriptions()
        {
            if (Session["MPD"] != null)
            {
                return (List<ModulPartDescription>)Session["MPD"];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Helper methode to draw a Message at the next Postback to the Error Label
        /// </summary>
        /// <param name="message"></param>
        private void CheckforMessage(String message)
        {
            if (Session["Message"] != null && (bool)Session["Message"])
            {
                ErrorLabel.Text = message;
                ErrorLabel.Visible = true;
            }
        }
        /// <summary>
        /// Stored the values of the textboxes to the MPD Cookie, "jumps" to the chosen Modulpartdescription and draws his content. 
        /// </summary>
        /// <param name="index"></param>
        private void jumpToDescription(int index)
        {
            int indexOfCurrentModulpunkt = GetCurrentIndex();
            int indexOfNextModulpunkt = index;

            List<ModulPartDescription> list = GetModulpartDescriptions();

            list[indexOfCurrentModulpunkt].Description = DescriptionTextBox.Text;
            list[indexOfCurrentModulpunkt].Name = NameTextBox.Text;
            LinkButton link2 = (LinkButton)ModulpunkteTable.FindControl("Modulpunkt" + indexOfCurrentModulpunkt);
            link2.Text = NameTextBox.Text;

            DescriptionTextBox.Text = list[indexOfNextModulpunkt].Description;
            NameTextBox.Text = list[indexOfNextModulpunkt].Name;

            Session["CurrentIndex"] = indexOfNextModulpunkt;
            Session["MPD"] = list;

            ModulpunkteTable.Rows.Clear();
            DrawTable();
        }

        /// <summary>
        /// Draws the Subjects of the chosen Modulhandbok of the Dropdownlist. Marks allready chosen subjects with color
        /// </summary>
        private void DrawSubjects()
        {
            List<Subject> list = GetSubjectsToDisplay();
            List<Subject> allready = GetSubjects();
            int rows = 0;
            if (list != null)
            {
                rows = list.Count;
            }
            for (int i = 0; i < rows; i++)
            {
                TableCell tc = new TableCell();
                if (list != null)
                {
                    if (list[i] != null)
                    {

                        LinkButton link = new LinkButton();
                        link.Text = "Fach: "+list[i].Name;
                        link.ID = "Subject" + list[i].SubjectID;
                        link.Click += Subject_Click;
                        tc.Controls.Add(link);
                        if (allready.Any(s => s.SubjectID == list[i].SubjectID))
                        {
                            link.Style.Value = "background-color:yellow";
                        }
                    }
                }
                TableRow tr = new TableRow();
                tr.Cells.Add(tc);
                SubjectsTable.Rows.Add(tr);
            }
        }
        private List<Subject> GetSubjectsToDisplay()
        {
            ArchiveLogic al=new ArchiveLogic();
            return al.getSubjectstoDisplay(DropDownList.SelectedValue.Trim());
        }
        private List<Subject> GetSubjects()
        {
            if (Session["Subjects"] == null)
            {
                List<Subject> toReturn = new List<Subject>();
                int id = Int32.Parse(Request.QueryString["SubjectID"]);
                ModulhandbookContext mhc = new ModulhandbookContext();
                return mhc.Subjects.Where(s => s.SubjectID == id).ToList<Subject>();
            }
            else
            {
                return (List<Subject>)Session["Subjects"];
            }
        }
        protected void Subject_Click(Object sender, EventArgs e)
        {
            ModulhandbookContext mhc = new ModulhandbookContext();
            LinkButton link = sender as LinkButton;
            int id = Int32.Parse(link.ID.Substring(7));
            Subject subject = mhc.Subjects.Where(s => s.SubjectID == id).ToList<Subject>().First();
            List<Subject> list = GetSubjects();
            Boolean delete = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].SubjectID == id)
                {
                    list.RemoveAt(i);
                    delete = true;
                }
            }
            if (!delete)
            {
               list.Add(subject);
            }
            Session["Subjects"] = list;
            SubjectsTable.Rows.Clear();
            DrawSubjects();
        }

        /// <summary>
        /// Creates a Pdf of the Current Modul and open it with a valid pdf viewer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void PdfBtn_Click(object sender, EventArgs e)
        {
            jumpToDescription(0);
            Core.PDFOperations.PDFHandler pdf = new Core.PDFOperations.PDFHandler();
            List<ModulPartDescription> list = GetModulpartDescriptions();
            String title = "";
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Name.Equals(GlobalNames.getModulNameText()))
                {
                    title = list[i].Description;
                    i = list.Count;
                }
            }
            Modul newModule = new Modul()
            {
                Descriptions = list,
            };
            pdf.CreatePDF(newModule, title, Server);

        }

        private bool DescriptionDone(ModulPartDescription mpd, String defaultText)
        {
            if (mpd.Description.Trim().Equals(""))
            {
                return false;
            }
            if (mpd.Description.ToUpper().Trim() == defaultText.ToUpper().Trim())
            {
                return false;
            }
            if (mpd.Name.Equals("ECTS-Punkte")||mpd.Name.Equals("Semesterwochenstunden"))
            {
                String text = mpd.Description;
                double Num;
                bool isNum = double.TryParse(text, out Num);

                if (!isNum)
                {
                    return false;
                }
            }
            return true;
        }
        protected ICollection<Modulhandbook> GetModulhandbooks()
        {
            ArchiveLogic al = new ArchiveLogic();
            return al.getEditableModulhandbooks();
        }
    }
}