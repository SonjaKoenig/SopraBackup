using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModulManagementSystem.Models;
using ModulManagementSystem.Core.DBOperations;

namespace ModulManagementSystem
{
    public partial class Modulauswahl_Koo_Frei : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!UserIsFreigabeberechtigter() && !UserIsKoordinator())
                {
                    Response.Redirect("Default.aspx");
                }
                DrawHeader();
            }
            else
            {
                DrawHeader();
            }
            if (Request.QueryString["ModulhandbookID"] != null)
            {
                if (Request.QueryString["SubjectID"] != null)
                {
                    DrawModuls();

                }
                else
                {
                    DrawSubjects();
                }
            }
            else
            {
                if (nothingToDo())
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    DrawModulhandbooks();
                    //debugDraw();

                }
            }
        }

        private bool UserIsFreigabeberechtigter()
        {
            return (HttpContext.Current.User.IsInRole("Freigabeberechtigter"));
        }
        private bool UserIsKoordinator()
        {
            return (HttpContext.Current.User.IsInRole("Koordinator"));
        }
        private void DrawModulhandbooks()
        {
            ArchiveLogic al = new ArchiveLogic();
            List<Modulhandbook> modulhandbooks = al.GetModulhandbooksKooFrei(HttpContext.Current);
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
        private void DrawHeader()
        {
            ArchiveLogic al = new ArchiveLogic();
            ModulhandbookContext mhc = new ModulhandbookContext();
            if (Request.QueryString["ModulhandbookID"] != null)
            {
                int MId = Int32.Parse(Request.QueryString["ModulhandbookID"]);
                List<Modulhandbook> books = mhc.Modulhandbooks.Where(m => m.ModulhandbookID == MId).ToList<Modulhandbook>();
                Modulhandbook book = books.First();
                ChosenModulhandbook.Text = "Modulhandbuch: " + book.Name + " FSPOYear: " + book.FspoYear + " Abschluss: " + book.Abschluss + " ValidSemester: " + book.ValidSemester;

                if (Request.QueryString["SubjectID"] != null)
                {
                    int SId = Int32.Parse(Request.QueryString["SubjectID"]);
                    List<Subject> subjects = mhc.Subjects.Where(s => s.SubjectID == SId).ToList<Subject>();
                    ChosenSubject.Text = "Subject: " + subjects.First().Name;

                }
                else
                {
                    ChosenModulhandbook.Text = "Modulhandbuch: " + book.Name + " FSPOYear: " + book.FspoYear + " Abschluss: " + book.Abschluss + " ValidSemester: " + book.ValidSemester;
                }
            }
        }
        private void DrawSubjects()
        {
            ArchiveLogic al = new ArchiveLogic();
            List<Subject> subjects = al.GetSubjectsKooFrei(HttpContext.Current, Int32.Parse(Request.QueryString["ModulhandbookID"]));
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
            List<Modul> moduls = al.GetModulsKooFrei(HttpContext.Current, Int32.Parse(Request.QueryString["SubjectId"]));
            foreach (Modul m in moduls)
            {
                TableCell tc = new TableCell();
                LinkButton link = new LinkButton();
                link.Text = al.getNameFromModule(m) + " ModulStatus: " + m.State + " Version: " + m.Version + " Jahr" + m.Year;
                link.ID = "" + m.ModulID;
                link.Click += Modul_Click;
                tc.Controls.Add(link);
                TableRow tr = new TableRow();
                tr.Cells.Add(tc);
                ModulTable.Rows.Add(tr);
            }
        }
        /// <summary>
        /// debug function to display modules only
        /// </summary>
        private void debugDraw()
        {
            ArchiveLogic al = new ArchiveLogic();
            List<Modul> moduls = al.GetModulsKooFrei(HttpContext.Current);
            foreach (Modul m in moduls)
            {
                TableCell tc = new TableCell();
                LinkButton link = new LinkButton();
                link.Text = al.getNameFromModule(m) + " ModulStatus: " + m.State + " Version: " + m.Version + " Jahr" + m.Year;
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
            Response.Redirect("ModulBearbeiten.aspx?ModulID=" + link.ID + "&Control=true");
        }
        void Subject_Click(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            Response.Redirect("ModulAuswahl-Koo-Frei.aspx?ModulhandbookID="
                + Request.QueryString["ModulhandbookID"]
                + "&SubjectID=" + link.ID);
        }
        void Modulhandbook_Click(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            Response.Redirect("ModulAuswahl-Koo-Frei.aspx?ModulhandbookID=" + link.ID);
        }

        private bool nothingToDo()
        {
            ArchiveLogic al = new ArchiveLogic();
            return al.GetModulsKooFrei(HttpContext.Current).Count == 0;
        }

    }
    
}