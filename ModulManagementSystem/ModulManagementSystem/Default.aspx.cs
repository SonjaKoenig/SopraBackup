using ModulManagementSystem.Core.DBOperations;
using ModulManagementSystem.Models;
using ModulManagementSystem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using ModulManagementSystem.Core.PDFOperations;
using System.Web.Security;

namespace ModulManagementSystem
{
    public partial class _Default : Page
    {
        private ArchiveLogic logic = new ArchiveLogic();
        private bool needToLoadXmlTree = true;
        private JobLogic jobLogic = new JobLogic();
        private PDFHandler pdf = new PDFHandler();
 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (needToLoadXmlTree)
                createDataSourceXmlFile();
            MakeLinksVisible();

            if (jobList.Items.Count == 0)
                createJobList();            
        }

        private void createJobList()
        {
            if (Membership.GetUser() != null)
            {
                MembershipUser user = Membership.GetUser();
                Guid guid = new Guid(user.ProviderUserKey.ToString());
                List<Job> jobs = jobLogic.GetJobListForUser(guid);

                foreach (Job j in jobs)
                {
                    jobList.Items.Add(new ListItem(j.JobID + ": " + j.Text + " " + j.Name));
                }
            }            
        }
        
        /// <summary>
        /// Creates a Xml-File that is the datasource for the treeview. It contains          all Modulhandbooks, Subjects and Modules
        /// </summary>
        private void createDataSourceXmlFile()
        {            
            XmlDocument doc = new XmlDocument();
            XmlNode semester, modulhandbook, subject, myRoot = null;
            XmlElement el;
            
            List<Subject> subjects = null;
            List<Modul> moduls = null;
            
            // füge einen root knoten hinzu
            myRoot = doc.CreateElement("Modulhandbücher");
            doc.AppendChild(myRoot);

            foreach (Semester sem in logic.getAllSemester())
            {
                el = doc.CreateElement("Semester");
                el.SetAttribute("Heading", sem.Name);
                semester = myRoot.AppendChild(el);
            
                // füge alle modulhandbücher hinzu
                List<Modulhandbook> handbookList = logic.getAllModulhandbooksFromSemester(sem.SemesterID);
                foreach (Modulhandbook mhb in handbookList)
                {                
                    el = doc.CreateElement("Modulhandbuch");
                    el.SetAttribute("Heading", mhb.Name);
                    modulhandbook = semester.AppendChild(el);
                    //füge alle Fächer von einem Modulhandbuch hinzu
                    subjects = logic.getAllSubjectsFromModulhandbook(mhb.ModulhandbookID);
                    foreach (Subject s in subjects)
                    {
                        el = doc.CreateElement("Fach");
                        el.SetAttribute("Heading", s.Name);
                        subject = modulhandbook.AppendChild(el);
                        //füge alle module von einem fach hinzu
                        moduls = logic.getAllModulesFromSubject(s.SubjectID);
                        foreach (Modul m in moduls)
                        {
                            if (m.State.Equals(ModulState.archiviert))
                            {
                                // finde den namen des moduls in der desctription
                                foreach (ModulPartDescription d in m.Descriptions)
                                {
                                    if (d.Name == GlobalNames.getModulNameText())
                                    {
                                        el = doc.CreateElement("Modul");
                                        el.SetAttribute("Heading", d.Description);
                                        subject.AppendChild(el);
                                    }
                                }
                            }
                        }
                    }           
                }
            }
            // hier muss der pfad zur \Modulhandbook.xml eingetragen werden. die datei liegt im root verzeichnis von den projekten
            doc.Save(Server.MapPath("/Modulhandbook.xml"));
            needToLoadXmlTree = false;
            //ModulhandbookTreeView.Parent.Visible = false;
        }

        private XmlElement getRoot(XmlDocument doc, XmlNode root, String newNode)
        {
            XmlElement newRoot = null;
            foreach (XmlNode node in root.ChildNodes)
            {
                if (node.Attributes["Heading"].Value.ToString().Equals(newNode))
                {
                    newRoot = (XmlElement)node;
                }
            }
            if (newRoot == null)
            {
                newRoot = doc.CreateElement("Semester");
                newRoot.SetAttribute("Heading", newNode);
                root.AppendChild(newRoot);
            }
            return newRoot;
        }

        protected void Search_Field(object sender, EventArgs e)
        {

        }

        protected void ModulHandbookName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void SubjectName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ModulName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void ModulhandbookTreeView_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
        {
           
        }

        /// <summary>
        /// Method that searches for all Modules, Modulhandbooks and Subjects that contain the string sprecified in the SearchText textbox. Searches for Names and Years
        /// </summary>
        /// <param name="sender">not used</param>
        /// <param name="e">not used</param>
        protected void SearchButton_Click(object sender, EventArgs e)
        {
            //ContentPlaceHolder searchbar;
            //TextBox searchText;
            //Button searchButton;

            //searchbar = (ContentPlaceHolder)Master.FindControl("Searchbar");
            //searchText = (TextBox)searchbar.FindControl("SearchText");
            //searchButton = (Button)searchbar.FindControl("SearchButton");

            searchResultList.Items.Clear();
            List<Object> searchResults = logic.getSearchResults(SearchText.Text.ToLower());
            foreach (Object s in searchResults)
            {
                if (s is Modul)
                {
                    if (((Modul)s).State.Equals(ModulState.archiviert))
                        searchResultList.Items.Add(new ListItem(logic.getNameFromModule((Modul)s) + " - Modul von " + ((Modul)s).Year));
                }
                else if (s is Subject)
                {
                    searchResultList.Items.Add(new ListItem(((Subject)s).Name) + " - Fach von " + ((Subject)s).Modulhandbook.FspoYear);
                }
                else if (s is Modulhandbook)
                {
                    searchResultList.Items.Add(new ListItem(((Modulhandbook)s).Name + " - Modulhandbuch von " + ((Modulhandbook)s).FspoYear)); 
                }
            }               
        }

        /// <summary>
        /// creates and opens a pdf document for the clicked element. Only for Modulhandbooks and Modules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ModulhandbookTreeView_SelectedNodeChanged(object sender, EventArgs e)
        {

            Modulhandbook mhb = logic.getModulhandbookByNameAndSemester(ModulhandbookTreeView.SelectedNode.Text.ToLower(), getSemesterNodeText(ModulhandbookTreeView.SelectedNode));
            Modul module = logic.getModuleByName(ModulhandbookTreeView.SelectedNode.Text.ToLower());
            Subject subj = logic.getSubjectByName(ModulhandbookTreeView.SelectedNode.Text.ToLower());
            if (mhb != null)
            {
                pdf.WriteModulhandbookToPdf(mhb, Server);
            }
            else if (module != null)
            {
                pdf.CreatePDF(module, Server);
            }
            else if (subj != null)
            {
                pdf.CreateAndOpenSoubjectPdf(subj, Server);
            }
        }

        private String getSemesterNodeText(System.Web.UI.WebControls.TreeNode node)
        {
            if (node.Parent.Depth == 0)
            {
                return node.Parent.Text;
            }
            if (node.Parent.Depth == 1)
            {
                return node.Parent.Parent.Text;
            }
            if (node.Parent.Depth == 2)
            {
                return node.Parent.Parent.Parent.Text;
            }
            return null;
        }

        /// <summary>
        /// creates and opens a pdf document if the user clicked on a search result in the search result list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void searchResultList_Click(object sender, BulletedListEventArgs e)
        {
            String objName = searchResultList.Items[e.Index].Text;
            
            objName = objName.Remove(objName.LastIndexOf('-') - 1).ToLower();
           
            Modulhandbook mhb = logic.getModulhandbookByName(objName);
            Modul module = logic.getModuleByNameAttendVersion(objName);
            Subject subj = logic.getSubjectByName(objName);
            if (mhb != null)
            {
                pdf.WriteModulhandbookToPdf(mhb, Server);
            }
            else if (module != null)
            {
                pdf.CreatePDF(module, Server);
            }
            else if(subj != null)
            {
                pdf.CreateAndOpenSoubjectPdf(subj, Server);
            }
        }
        /// <summary>
        /// set Link Visible when specific User is logged in
        /// </summary>
        private void MakeLinksVisible()
        {
            if (HttpContext.Current.User.IsInRole("Modulverantwortlicher") || HttpContext.Current.User.IsInRole("Administrator"))
            {
                ModulErstellenLink.Visible = true;
                ModuleBearbeitenLink.Visible = true;
            }
            if (HttpContext.Current.User.IsInRole("Freigabeberechtigter") 
                || HttpContext.Current.User.IsInRole("Koordinator") 
                || HttpContext.Current.User.IsInRole("Administrator") )
            {
                ModuleKontrollierenLink.Visible = true;
            }
        }
        protected void ModulErstellenLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModulAuswahl-Modulverantwortlicher.aspx?Bearbeiten=false");
        }
        protected void ModuleBearbeitenLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModulAuswahl-Modulverantwortlicher.aspx?Bearbeiten=true");
        }
        protected void ModuleKontrollierenLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModulAuswahl-Koo-Frei.aspx");
        }

        /// <summary>
        /// created and opens the modules that belongs to the clicked job and redirects the user to the edit module page 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void jobList_Click(object sender, BulletedListEventArgs e)
        {
            String text = jobList.Items[e.Index].Text;
            int objId = Int16.Parse(text.Remove(text.IndexOf(':')));
            Job job = jobLogic.getJobById(objId);
            if (job != null)
            {
                PDFHandler handler = new PDFHandler();
                Modul module = logic.getModulById(job.ModulID);
                handler.CreatePDF(module, Server);

                if (HttpContext.Current.User.IsInRole("Freigabeberechtigter") || HttpContext.Current.User.IsInRole("Koordinator"))
                {
                    Response.Redirect(@"http://localhost:56639/ModulBearbeiten.aspx?ModulID=" + job.ModulID + "&Control=true");
                }

                else if (HttpContext.Current.User.IsInRole("Modulverantwortlicher"))
                {
                    Response.Redirect(@"http://localhost:56639/ModulBearbeiten.aspx?ModulID=" + job.ModulID);
                }
            }
        }
    }         
}