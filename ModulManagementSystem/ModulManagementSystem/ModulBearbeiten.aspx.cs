using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModulManagementSystem.Models;
using ModulManagementSystem.Core.PDFOperations;
using ModulManagementSystem.Core.DBOperations;
using System.IO;
using System.Web.Security;

namespace ModulManagementSystem
{
    public partial class ModulBearbeiten : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Modul modul = GetModulByQuerystring();
                List<ModulPartDescription> list = modul.Descriptions.ToList<ModulPartDescription>();
                Session["MPD"] = list;
                Session["CurrentIndex"] = 0;
                Session["Subjects"] = null;
                Session["Subjects"] = GetSubjects();

                DrawTable();
                DropDownList.DataBind();
                DropDownList.SelectedValue = Request.QueryString["ModulhandbookID"];
                DrawSubjects();
                NameTextBox.Text = list[0].Name;
                DescriptionTextBox.Text = list[0].Description;
                if (list[0].Comment != null)
                {
                    CommentTextBox.Text = list[0].Comment;
                }

                DropDownList.DataBind();
                DropDownList.SelectedValue = Request.QueryString["ModulhandbookID"];
            }
            else
            {
                if (Session["Message"] != null && (bool)Session["Message"])
                {
                    ErrorLabel.Visible = false;
                    Session["Message"] = false;
                }
                DrawTable();
                DrawSubjects();
            }
            //activate Koordinator- and Freigabeberechtigten options
            if (Request.QueryString["Control"] != null)
            {
                AdoptBtn.Visible = false;
                DeleteModulBtn.Visible = false;
                SendBackBtn.Visible = true;
                CommentTextBox.Enabled = true;
                NameTextBox.Enabled = false;
                DescriptionTextBox.Enabled = false;

                //User is only Koordinator
                if (HttpContext.Current.User.IsInRole("Koordinator") && !HttpContext.Current.User.IsInRole("Freigabeberechtigter"))
                {
                    ControlBtn.Visible = true;
                }
                //User is only Freigabeberechtigter
                else if (HttpContext.Current.User.IsInRole("Freigabeberechtigter") && !HttpContext.Current.User.IsInRole("Koordinator"))
                {
                    ReleaseBtn.Visible = true;
                }

            }
            //activate Modulverantwortlicher options   
            else
            {
                Modul modul = GetModulByQuerystring();
                modul = GetModulByQuerystring();
                var mu = System.Web.Security.Membership.GetUser();
                Guid owner = (Guid)mu.ProviderUserKey;
                if (!(owner == modul.Owner))
                Response.Redirect("Default.aspx");
            }
        }
        private Modul GetModulByQuerystring()
        {
            if (Request.QueryString["ModulId"] == null)
            {
                Response.Redirect("Default.aspx");
                return null;
            }
            else
            {
                ArchiveLogic al=new ArchiveLogic();
                return al.getModulById(Int32.Parse(Request.QueryString["ModulId"]));   
            }
        }
        private void DrawTable()
        {
            List<ModulPartDescription> list = GetModulpartDescriptions();
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
                        link.Text = list[i].Name;
                        link.ID = "Modulpunkt" + i;
                        link.Click += Modulpunkt_Click;
                        tc.Controls.Add(link);
                    }
                }
                TableRow tr = new TableRow();
                tr.Cells.Add(tc);
                if (Session["Control"] == null)
                {
                    TableCell tc2 = new TableCell();
                    if (list[i].Comment!=null && (!list[i].Comment.Trim().Equals("")))
                    {
                        Image haken = new Image();
                        haken.ImageUrl = "~/Images/exclamation.png";
                        tc2.Controls.Add(haken);
                        tr.Cells.Add(tc2);
                    }
                }
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

        protected void Modulpunkt_Click(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            jumpToDescription(int.Parse(link.ID.Substring(10)));
        }
        /// <summary>
        /// Delete the current Modul
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DeleteModulBtn_Click(object sender, EventArgs e)
        {
            Modul modul = GetModulByQuerystring();
            ArchiveLogic al = new ArchiveLogic();
            ModulhandbookContext mhc = new ModulhandbookContext();
            List<Modul> moduls = mhc.Modules.ToList<Modul>();
            foreach (Modul m in moduls)
            {
                if (al.getNameFromModule(m) == al.getNameFromModule(modul))
                {
                    mhc.Modules.Remove(m);
                }
            }
            mhc.SaveChanges();
            Response.Redirect("Default.aspx");
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
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

        private bool CheckDescriptions()
        {
            List<ModulPartDescription> descriptions = GetModulpartDescriptions();
            for (int i = 0; i < descriptions.Count; i++)
            {
                //Check double ModulPartDescriptions
                for (int j = i + 1; j < descriptions.Count; j++)
                {
                    if (descriptions[i].Name.Equals(descriptions[j].Name))
                    {
                        Session["Message"] = true;
                        CheckforMessage("Es können keine doppelten Modulpunkte akzeptiert werden!");
                        jumpToDescription(i);
                        return false;
                    }
                }
                //Check for empty Descriptions
                if (descriptions[i].Description.Equals("Hier Modulpunktbeschreibung eintragen")
                    || descriptions[i].Name.Equals("Eigener Modulpunkt"))
                {
                    Session["Message"] = true;
                    CheckforMessage("Ein Modulpunkt wurde noch nicht bearbeitet!");
                    jumpToDescription(i);
                    return false;
                }
                //Check for undone mandatory fields
                if (descriptions[i].IsNeeded)
                {
                    if (descriptions[i].Description.Equals(""))
                    {
                        Session["Message"] = true;
                        CheckforMessage("Ein Pflichtfeld darf nicht leer sein");
                        jumpToDescription(i);
                        return false;
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
            List<Subject> subjects = GetSubjects();
            if (subjects.Count <= 0)
            {
                Session["Message"] = true;
                CheckforMessage("Es muss mindestens ein Fach für das Modul ausgewählt werden!");
            }
            return true;
        }

        private void CheckforMessage(String message)
        {
            if (Session["Message"] != null && (bool)Session["Message"])
            {
                ErrorLabel.Text = message;
                ErrorLabel.Visible = true;
            }
        }

        /// <summary>
        /// Returns the Current Displayed ModulPartDescription
        /// </summary>
        /// <returns></returns>
        private ModulPartDescription GetCurrentModulPartDescription()
        {
            List<ModulPartDescription> list = GetModulpartDescriptions();
            int index = GetCurrentIndex();
            return list[index];
        }

        private void jumpToDescription(int index)
        {
            int indexOfCurrentModulpunkt = GetCurrentIndex();
            int indexOfNextModulpunkt = index;

            List<ModulPartDescription> list = GetModulpartDescriptions();

            list[indexOfCurrentModulpunkt].Description = DescriptionTextBox.Text;
            if (!CommentTextBox.Text.Trim().Equals(""))
            {
                list[indexOfCurrentModulpunkt].Comment = CommentTextBox.Text;
            }
            else
            {
                list[indexOfCurrentModulpunkt].Comment = null;
            }

            if (!list[indexOfCurrentModulpunkt].IsNeeded)
            {
                list[indexOfCurrentModulpunkt].Name = NameTextBox.Text;
                LinkButton link2 = (LinkButton)ModulpunkteTable.FindControl("Modulpunkt" + indexOfCurrentModulpunkt);
                link2.Text = NameTextBox.Text;
            }

            DescriptionTextBox.Text = list[indexOfNextModulpunkt].Description;
            NameTextBox.Text = list[indexOfNextModulpunkt].Name;
            CommentTextBox.Text = list[indexOfNextModulpunkt].Comment;

            if (list[indexOfNextModulpunkt].Name.Equals("Name"))
            {
                DescriptionTextBox.Enabled = false;
            }
            else if (Request.QueryString["Control"] == null)
            {
                DescriptionTextBox.Enabled = true;
            }

            Session["CurrentIndex"] = indexOfNextModulpunkt;
            Session["MPD"] = list;

            ModulpunkteTable.Rows.Clear();
            DrawTable();
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
                ArchiveLogic al=new ArchiveLogic();
                Modul modul = al.getModulById(Int32.Parse(Request.QueryString["ModulID"]));
                return modul.Subjects.ToList<Subject>();
            }
            else
            {
                return (List<Subject>)Session["Subjects"];
            }
        }
        protected void Subject_Click(Object sender, EventArgs e)
        {
            if (Request.QueryString["Control"] == null)
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

        }

        /// <summary>
        /// The man in charge of the Modul, updated it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AdoptBtn_Click(object sender, EventArgs e)
        {
            SaveChanges(ModulState.created);
        }

        /// <summary>
        /// The Freigabeberechtigte accepts the Modul
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ReleaseBtn_Click(object sender, EventArgs e)
        {
            SaveChanges(ModulState.freigeben);
        }

        /// <summary>
        /// The Koordinator accepts the Modul
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ControlBtn_Click(object sender, EventArgs e)
        {
            SaveChanges(ModulState.waitingForAcceptionFromFreigabeberechtigter);
        }

        /// <summary>
        /// The Koordinator or Freigabeberechtigte refused this Modul
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SendBackBtn_Click(object sender, EventArgs e)
        {
            SaveChanges(ModulState.abgelehnt);
        }

        /// <summary>
        /// Saves the Modul with the given Modulstate und version number 1+n where n is the number, of the latest version
        /// </summary>
        /// <param name="state"></param>
        private void SaveChanges(ModulState state)
        {
            if (CheckDescriptions())
            {
                int indexOfCurrentModulpunkt = GetCurrentIndex();
                List<ModulPartDescription> modulpartdescriptions = GetModulpartDescriptions();
                List<Subject> subjects = GetSubjects();
                modulpartdescriptions[indexOfCurrentModulpunkt].Name = NameTextBox.Text;
                modulpartdescriptions[indexOfCurrentModulpunkt].Description = DescriptionTextBox.Text;
                if (!CommentTextBox.Text.Trim().Equals(""))
                {
                    modulpartdescriptions[indexOfCurrentModulpunkt].Comment = CommentTextBox.Text;
                }



                var mu = System.Web.Security.Membership.GetUser();
                Guid user = (Guid)mu.ProviderUserKey;
                Modul modul = GetModulByQuerystring();
                ArchiveLogic al = new ArchiveLogic();
                JobLogic jl = new JobLogic();

                //create the new Modulpartdescriptions
                List<ModulPartDescription> mpdList = new List<ModulPartDescription>();
                foreach (ModulPartDescription m in modulpartdescriptions)
                {
                    ModulPartDescription toAdd = new ModulPartDescription()
                    {
                        IsNeeded = m.IsNeeded,
                        Description = m.Description,
                        Comment = m.Comment,
                        Name = m.Name
                    };
                    mpdList.Add(toAdd);
                }

                Modul newModule = al.CreateModul(mpdList, state, modul.Owner, user, DateTime.Now, subjects, modul.Version + 1);

                Session["Message"] = true;
                if (newModule != null)
                {
                    CheckforMessage("Neue Version Erstellt!");
                    jl.CreateNewJob(state, mpdList, newModule, user);
                }
                else
                {
                    CheckforMessage("Ein Fehler ist aufgetreten. Es wurde kein Modul erstellt!");
                }
            }
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
    }
}