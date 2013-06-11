using ModulManagementSystem.Core.DBOperations;
using ModulManagementSystem.Core.PDFOperations;
using ModulManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ModulManagementSystem
{
    public partial class Jobs : System.Web.UI.Page
    {

        private ArchiveLogic logic = new ArchiveLogic();
        private JobLogic jobLogic = new JobLogic();
        private PDFHandler pdf = new PDFHandler();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (jobListJob.Items.Count == 0)
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
                    jobListJob.Items.Add(new ListItem(j.JobID + ": " + j.Text + " " + j.Name));
                }
            }
        }

        protected void jobListJob_Click(object sender, BulletedListEventArgs e)
        {
            String text = jobListJob.Items[e.Index].Text;
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