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
        //start at zero
        int anzahlDerPflichtfelder = 7;

        //The Descriptions for the mandatory fields
        List<String> defaultDescriptionsText = new List<string>(){"Kürzel des Moduls","Hier Modulname eintragen", "Numerische Wert der Leistungspunkte",
                "Semesterwochenstunden eintragen","Sprache", "Hier Turnus eintragen","Name des Modulverantwortlichen","Name des Dozenten",
                "Einordnung in den Studiengang","Inhaltliche Voraussetzungen","Lernziele","Inhalt der Vorlesung","Literatur zur Vorlesung",
                "Hier Lehr und Lernform eintragen","Arbeitsaufwand in Stunden","Art der Bewertungsmethode","Hier Leistungspunkte eintragen",
                "Hier Notenbildung eintragen"};

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!HttpContext.Current.User.IsInRole("Modulverantwortlicher"))
            {
                Response.Redirect("Default.aspx");
            }

            if (!IsPostBack)
            {
                List<ModulPartDescription> list = new List<ModulPartDescription>();
                list.Add(new ModulPartDescription() { Name = GlobalNames.getModulNameNum(), Description = this.defaultDescriptionsText[0], IsNeeded = true });
                list.Add(new ModulPartDescription() { Name = GlobalNames.getModulNameText(), Description = this.defaultDescriptionsText[1], IsNeeded = true });
                list.Add(new ModulPartDescription() { Name = GlobalNames.getModulNameECTS(), Description = this.defaultDescriptionsText[2], IsNeeded = true });
                list.Add(new ModulPartDescription() { Name = GlobalNames.getModulNameWeekHours(), Description = this.defaultDescriptionsText[3], IsNeeded = true });
                list.Add(new ModulPartDescription() { Name = GlobalNames.getModulNameLanguage(), Description = this.defaultDescriptionsText[4], IsNeeded = true });
                list.Add(new ModulPartDescription() { Name = GlobalNames.getModulNameTurnus(), Description = this.defaultDescriptionsText[5], IsNeeded = true });
                list.Add(new ModulPartDescription() { Name = GlobalNames.getModulNameMV(), Description = this.defaultDescriptionsText[6], IsNeeded = true });
                list.Add(new ModulPartDescription() { Name = GlobalNames.getModulNameLecturer(), Description = this.defaultDescriptionsText[7], IsNeeded = true });
                list.Add(new ModulPartDescription() { Name = GlobalNames.getModulNameFitsInStudy(), Description = this.defaultDescriptionsText[8], IsNeeded = true });
                list.Add(new ModulPartDescription() { Name = GlobalNames.getModulNameReqContent(), Description = this.defaultDescriptionsText[9], IsNeeded = true });
                list.Add(new ModulPartDescription() { Name = GlobalNames.getModulNameEducation(), Description = this.defaultDescriptionsText[10], IsNeeded = true });
                list.Add(new ModulPartDescription() { Name = GlobalNames.getModulNameContent(), Description = this.defaultDescriptionsText[11], IsNeeded = true });
                list.Add(new ModulPartDescription() { Name = GlobalNames.getModulNameLiterature(), Description = this.defaultDescriptionsText[12], IsNeeded = true });
                list.Add(new ModulPartDescription() { Name = GlobalNames.getModulNameTeaching(), Description = this.defaultDescriptionsText[13], IsNeeded = true });
                list.Add(new ModulPartDescription() { Name = GlobalNames.getModulNameEffort(), Description = this.defaultDescriptionsText[14], IsNeeded = true });
                list.Add(new ModulPartDescription() { Name = GlobalNames.getModulNameMark(), Description = this.defaultDescriptionsText[15], IsNeeded = true });
                list.Add(new ModulPartDescription() { Name = GlobalNames.getModulNameReqFormal(), Description = this.defaultDescriptionsText[16], IsNeeded = true });
                list.Add(new ModulPartDescription() { Name = GlobalNames.getModulNameGrade(), Description = this.defaultDescriptionsText[17], IsNeeded = true });
                Session["MPD"] = list;
                Session["CurrentIndex"] = 0;
                Session["Subjects"] = null;
                Session["Subjects"] = GetSubjects();
                DropDownList.DataBind();
                DropDownList.SelectedValue = Request.QueryString["ModulhandbookID"];
                NameTextBox.Text = list.First().Name;
                DescriptionTextBox.Text = this.defaultDescriptionsText[0];            
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
                    Response.Redirect("Default.aspx");
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
                //Check double ModulPartDescriptions
                for (int j = i+1; j < descriptions.Count; j++)
                {
                    if (descriptions[i].Name.Equals(descriptions[j].Name))
                    {
                        Session["Message"] = true;
                        CheckforMessage("Es können keine doppelten Modulpunkte akzeptiert werden!");
                        jumpToDescription(i);
                        return false;
                    }
                }

                //Check for undone mandatory fields
                if (i <= anzahlDerPflichtfelder)
                {
                    if (descriptions[i].Description.Equals(defaultDescriptionsText[i]))
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
                if (descriptions[i].Name.Equals("ECTS-Punkte") || descriptions[i].Name.Equals("Semesterwochenstunden"))
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
                if (DescriptionDone(list[i], defaultDescriptionsText[i]))
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

        private void ControlNameTextBox() 
        {
            if (GetCurrentIndex() <= anzahlDerPflichtfelder)
            {
                NameTextBox.Enabled = false;
            }
            else 
            {
                NameTextBox.Enabled = true;
            }
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
        private void CheckforMessage(String message)
        {
            if (Session["Message"] != null && (bool)Session["Message"])
            {
                ErrorLabel.Text = message;
                ErrorLabel.Visible = true;
            }
        }
        private void jumpToDescription(int index)
        {
            int indexOfCurrentModulpunkt = GetCurrentIndex();
            int indexOfNextModulpunkt = index;

            List<ModulPartDescription> list = GetModulpartDescriptions();

            list[indexOfCurrentModulpunkt].Description = DescriptionTextBox.Text;
            if (indexOfCurrentModulpunkt > anzahlDerPflichtfelder)
            {
                list[indexOfCurrentModulpunkt].Name = NameTextBox.Text;
                LinkButton link2 = (LinkButton)ModulpunkteTable.FindControl("Modulpunkt" + indexOfCurrentModulpunkt);
                link2.Text = NameTextBox.Text;
            }

            DescriptionTextBox.Text = list[indexOfNextModulpunkt].Description;
            NameTextBox.Text = list[indexOfNextModulpunkt].Name;

            Session["CurrentIndex"] = indexOfNextModulpunkt;
            Session["MPD"] = list;

            ModulpunkteTable.Rows.Clear();
            DrawTable();
            ControlNameTextBox();
        }



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
            ModulhandbookContext mhc=new ModulhandbookContext();
            String s = DropDownList.SelectedValue.Trim();
            int id = Int32.Parse(s);
            List<Modulhandbook> list = mhc.Modulhandbooks.Where(m => m.ModulhandbookID == id).ToList<Modulhandbook>();

            return al.getAllSubjectsFromModulhandbook(list.First().ModulhandbookID);

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

        //new stuff
        protected void PdfBtn_Click(object sender, EventArgs e)
        {
            Core.PDFOperations.PDFHandler pdf = new Core.PDFOperations.PDFHandler();

            int indexOfCurrentModulpunkt = GetCurrentIndex();
            List<ModulPartDescription> list = GetModulpartDescriptions();
            list[indexOfCurrentModulpunkt].Name = NameTextBox.Text;
            list[indexOfCurrentModulpunkt].Description = DescriptionTextBox.Text;
            var mu = System.Web.Security.Membership.GetUser();
            Guid owner = (Guid)mu.ProviderUserKey;
            ArchiveLogic al = new ArchiveLogic();
            JobLogic jl = new JobLogic();
            List<Subject> subjects = GetSubjects();
            Modul newModule = al.CreateModul(list, ModulState.created, owner, owner, DateTime.Now, subjects, 1);

            pdf.CreatePDF(newModule, Server);
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
    }
}