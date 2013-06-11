using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModulManagementSystem.Core.DBOperations;
using ModulManagementSystem.Models;


namespace ModulManagementSystem
{

    public partial class ModulAuswahl_Modulverantwortlicher : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!HttpContext.Current.User.IsInRole("Modulverantwortlicher"))
                {
                    Response.Redirect("Default.aspx");
                }
            }
            if (Request.QueryString["Bearbeiten"] != null)
            {
                //A allready existing Module should be edited
                if (Request.QueryString["Bearbeiten"].Equals("true"))
                {
                    DrawModuls();
                }
                //A new Module should be created
                else
                {
                    if (Request.QueryString["ModulhandbookID"] != null)
                    {
                        if (Request.QueryString["SubjectID"] == null)
                        {
                            DrawSubjects(Int32.Parse(Request.QueryString["ModulhandbookID"]));
                        }
                        else
                        {
                            NewModulBtn.Visible = true;
                        }
                    }
                    else
                    {
                        DrawModulhandbooks();
                    }
                }
            }
            DrawHeader();
        }

        void Subject_Click(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            Response.Redirect("ModulErstellen.aspx?SubjectId=" + link.ID + "&ModulhandbookID=" + Request.QueryString["ModulhandbookID"]);
        }

        void Modulhandbook_Click(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            Response.Redirect("ModulAuswahl-Modulverantwortlicher.aspx?Bearbeiten=" + Request.QueryString["Bearbeiten"]
                + "&ModulhandbookID=" + link.ID);
        }

        private void DrawHeader()
        {
            ArchiveLogic al = new ArchiveLogic();
            ModulhandbookContext mhc = new ModulhandbookContext();

            if (Request.QueryString["ModulhandbookID"] != null)
            {
                int MId = Int32.Parse(Request.QueryString["ModulhandbookID"]);
                List<Modulhandbook> books = mhc.Modulhandbooks.Where(m => m.ModulhandbookID == MId).ToList<Modulhandbook>();
                Modulhandbook book = books.First();
                ChosenModulhandbook.Text = "Modulhandbuch: "+book.Name + " FSPOYear: " + book.FspoYear + " Abschluss: " + book.Abschluss + " ValidSemester: " + book.ValidSemester;

                if (Request.QueryString["SubjectID"] != null)
                {
                    int SId = Int32.Parse(Request.QueryString["SubjectID"]);
                    List<Subject> subjects = mhc.Subjects.Where(s => s.SubjectID == SId).ToList<Subject>();
                    ChosenSubject.Text ="Subject: "+ subjects.First().Name;

                }
                else
                {
                    ChosenModulhandbook.Text = "Modulhandbuch: "+book.Name + " FSPOYear: " + book.FspoYear + " Abschluss: " + book.Abschluss + " ValidSemester: " + book.ValidSemester;
                }
            }
        }

        private void DrawModulhandbooks()
        {
            Core.DBOperations.ArchiveLogic al = new Core.DBOperations.ArchiveLogic();
            List<Modulhandbook> modulhandbooks = al.getEditableModulhandbooks();

            foreach (Modulhandbook m in modulhandbooks)
            {
                TableCell tc = new TableCell();
                LinkButton link = new LinkButton();
                link.Text = m.Name + " FSPOYear: " + m.FspoYear + " Abschluss: " + m.Abschluss + " ValidSemester: " + m.ValidSemester;
                link.ID = m.ModulhandbookID.ToString();
                link.Click += Modulhandbook_Click;
                tc.Controls.Add(link);
                TableRow tr = new TableRow();
                tr.Cells.Add(tc);
                ModulhandbookTable.Rows.Add(tr);
            }
        }
        private void DrawSubjects(int ModulhandbookId)
        {
            Core.DBOperations.ArchiveLogic al = new Core.DBOperations.ArchiveLogic();
            List<Subject> subjects = al.getAllSubjectsFromModulhandbook(ModulhandbookId);
            foreach (Subject s in subjects)
            {
                TableCell tc = new TableCell();
                LinkButton link = new LinkButton();
                link.Text = s.Name;
                link.ID = "" + s.SubjectID;
                link.Click += Subject_Click;
                tc.Controls.Add(link);
                TableRow tr = new TableRow();
                tr.Cells.Add(tc);
                SubjectTable.Rows.Add(tr);
            }
        }

        private void DrawModuls()
        {
            ArchiveLogic al = new ArchiveLogic();
            var mu = System.Web.Security.Membership.GetUser();
            Guid owner = (Guid)mu.ProviderUserKey;
            List<Modul> moduls = al.GetModulsModulverantwortlicher(HttpContext.Current, owner);
            foreach (Modul m in moduls)
            {
                TableCell tc = new TableCell();
                LinkButton link = new LinkButton();
                link.Text = al.getNameFromModule(m)+" ModulStatus: "+m.State+" Version: "+m.Version +" Jahr"+m.Year;
                link.ID = "" + m.ModulID;
                link.Click += Modul_Click;
                tc.Controls.Add(link);
                TableRow tr = new TableRow();
                tr.Cells.Add(tc);
                ModulTable.Rows.Add(tr);
            }
        }
        void Modul_Click(Object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
           Response.Redirect("ModulBearbeiten.aspx?ModulID=" + link.ID);
        }
        private bool Bearbeiten()
        {
            if (Request.QueryString["Bearbeiten"] != null)
            {
                return Request.QueryString["Bearbeiten"].Equals("true");
            }
            return false;
        }
    }
}