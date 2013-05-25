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
                //User is valid?
                if(!UserIsFreigabeberechtigter()&&!UserIsKoordinator())
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
                    //make something if nothing is to do
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    DrawModulhandbooks();
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
            Core.DBOperations.ArchiveLogic al = new Core.DBOperations.ArchiveLogic();
            List<Modulhandbook> modulhandbooks = GetModulhandbooks();
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
            ArchiveLogic al =new ArchiveLogic();
            ModulhandbookContext mhc=new ModulhandbookContext();

            if (Request.QueryString["ModulhandbookID"] != null)
            {
                int MId = Int32.Parse(Request.QueryString["ModulhandbookID"]);
                List<Modulhandbook> books=mhc.Modulhandbooks.Where(m => m.ModulhandbookID==MId).ToList<Modulhandbook>();
                Modulhandbook book=books.First();
                ChosenModulhandbook.Text="Modulhandbuch: "+book.Name + " FSPOYear: " + book.FspoYear + " Abschluss: " + book.Abschluss + " ValidSemester: " + book.ValidSemester;

                if (Request.QueryString["SubjectID"] != null)
                {
                    int SId = Int32.Parse(Request.QueryString["SubjectID"]);
                    List<Subject> subjects=mhc.Subjects.Where(s => s.SubjectID==SId).ToList<Subject>();
                    ChosenSubject.Text="Subject: "+subjects.First().Name;

                }
                else
                {
                    ChosenModulhandbook.Text = "Modulhandbuch: "+book.Name + " FSPOYear: " + book.FspoYear + " Abschluss: " + book.Abschluss + " ValidSemester: " + book.ValidSemester;
                }
            }
        }
        private void DrawSubjects()
        {
            Core.DBOperations.ArchiveLogic al = new Core.DBOperations.ArchiveLogic();
            List<Subject> subjects = GetSubjects(Int32.Parse(Request.QueryString["ModulhandbookID"]));
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
            List<Modul> moduls = GetModuls(Int32.Parse(Request.QueryString["SubjectId"]));
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
            //redirect to ModulFreigeben/Kontrollieren
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

        private List<Modulhandbook> GetModulhandbooks()
        {
            List<Modulhandbook> result = new List<Modulhandbook>();
            List<Subject> subjects = GetSubjects();
            foreach (Subject s in subjects)
            {
                result.Add(s.Modulhandbook);
            }
            for (int i = 0; i < result.Count - 1; i++)
            {
                for (int j = i + 1; i < result.Count; j++)
                {
                    if (result[i].ModulhandbookID == result[j].ModulhandbookID)
                    {
                        result.RemoveAt(j);
                    }
                }
            }
            return result;           
        }
        private List<Subject> GetSubjects()
        {
            List<Subject> result = new List<Subject>();
            List<Modul> moduls = GetModuls();
            foreach (Modul m in moduls)
            {
                result.InsertRange(result.Count, m.Subjects.ToList<Subject>());
            }
            for (int i = 0; i < result.Count-1; i++)
            {
                for(int j=i+1;i<result.Count; j++)
                {
                    if (result[i].SubjectID == result[j].SubjectID)
                    {
                        result.RemoveAt(j);
                    }
                }
            }
            return result;
        }
        private List<Subject> GetSubjects(int handbookId)
        {
            List<Subject> All = GetSubjects();
            List<Subject> result = new List<Subject>();
            for (int i = 0; i < All.Count; i++)
            {
                if (All[i].ModulhandbookID == handbookId)
                {
                    result.Add(All[i]);
                }
            }
            return result;
        }

        private List<Modul> GetModuls()
        {
            ModulhandbookContext mhc = new ModulhandbookContext();
            ArchiveLogic al = new ArchiveLogic();
            List<Modul> moduls=null;
            if (UserIsFreigabeberechtigter())
            {
                if (UserIsKoordinator())
                {
                    moduls = mhc.Modules.Where(m => m.State == ModulState.created
                        || m.State == ModulState.waitingForAcceptionFromFreigabeberechtigter).ToList<Modul>();
                }
                else
                {
                    moduls = GetModulsByState(ModulState.waitingForAcceptionFromFreigabeberechtigter);
                }
            }
            else if (UserIsKoordinator())
            {
                moduls = GetModulsByState(ModulState.created);
            }
            //hÃ¶chste Versionen suchen
            List<Modul> highestVersion=new List<Modul>();
            foreach (Modul m in moduls)
            {
                Modul modul = GetHighestModulVersion(m);
                if (UserIsFreigabeberechtigter())
                {
                    if(UserIsKoordinator()&&(modul.State==ModulState.waitingForAcceptionFromFreigabeberechtigter||modul.State==ModulState.created))
                    {
                        highestVersion.Add(m);
                    }
                    else if(modul.State==ModulState.waitingForAcceptionFromFreigabeberechtigter){
                        highestVersion.Add(m);
                    }
                }
                else if(UserIsKoordinator()&&modul.State== ModulState.created)
                {
                    highestVersion.Add(GetHighestModulVersion(m));
                }
                
            }

            //doppelte Elemente entfernen
            for (int i = 0; i < highestVersion.Count; i++)
            {
                String Name = al.getNameFromModule(highestVersion[i]);
                int counter = 0;
                for (int j=0;j<highestVersion.Count;j++)
                {
                    if (al.getNameFromModule(highestVersion[j]) == Name)
                    {
                        counter++;
                        if (counter > 1)
                        {
                            highestVersion.RemoveAt(j);
                            counter--;
                        }
                    }
                }
            }
            return highestVersion;
        }
        private List<Modul> GetModuls(int subjectId)
        {
            List<Modul> all=GetModuls();
            List<Modul> toReturn = new List<Modul>();
            foreach (Modul m in all)
            {
                bool toAdd = false;
                foreach (Subject s in m.Subjects)
                {
                    if (s.SubjectID == subjectId)
                    {
                        toAdd = true;
                    }
                }
                if (toAdd)
                {
                    toReturn.Add(m);
                }
            }
            return toReturn;
        }

        private List<Modul> GetModulsByState(ModulState state)
        {
            ModulhandbookContext mhc = new ModulhandbookContext();
            return mhc.Modules.Where(m => m.State == state).ToList<Modul>();
        }
        private Modul GetHighestModulVersion(Modul modul)
        {
            ArchiveLogic al = new ArchiveLogic();
            ModulhandbookContext mhc = new ModulhandbookContext();
            String Name = al.getNameFromModule(modul);
            return al.getModuleByNameAttendVersion(Name);
        }
        private bool nothingToDo()
        {
            return GetModuls().Count == 0;
        }
    }
    
}