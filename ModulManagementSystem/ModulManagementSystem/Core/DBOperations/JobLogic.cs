using ModulManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ModulManagementSystem.Core.DBOperations
{
    public class JobLogic
    {
        private ModulhandbookContext context = new ModulhandbookContext();

        public List<Job> GetJobListForUser(Guid user)
        {
            DbSet<Job> jobs = context.Jobs;
            List<Job> result = new List<Job>();

            foreach (Job j in jobs)
            {
                if (j.Executer.Equals(user))
                {
                    result.Add(j);
                }
            }
            return result;

        }

        internal Job getJobById(int objId)
        {
            DbSet jobs = context.Jobs;
            foreach (Job j in jobs)
            {
                if (j.JobID.Equals(objId))
                {
                    return j;
                }
            }
            return null;
        }

        public void CreateNewJob(ModulState state, List<ModulPartDescription> mpdList, Modul module, Guid user)
        {
            String name = null, text = null;
            String modulname = getModulname(mpdList);
            ArchiveLogic logic = new ArchiveLogic();
            Guid executer = new Guid();
            if (state.Equals(ModulState.created))
            {
                name = "Das Modul " + modulname + " wurde erstellt";
                text = "Bitte kontrollieren.";
                MembershipUser Modulverantwortlicher1 = Membership.GetUser("Koordinator");
                executer = new Guid(Modulverantwortlicher1.ProviderUserKey.ToString());
            }
            else if (state.Equals(ModulState.waitingForAcceptionFromFreigabeberechtigter))
            {
                name = "Das Modul " + modulname + " wurde vom Koordinator kontrolliert";
                text = "Bitte freigeben";
                MembershipUser Modulverantwortlicher1 = Membership.GetUser("Freigeber");
                executer = new Guid(Modulverantwortlicher1.ProviderUserKey.ToString());
            }
            else if (state.Equals(ModulState.abgelehnt))
            {
                name = "Das Modul " + modulname + " wurde vom " + user.ToString() + " abgelehnt";
                text = "TODO: hier soll die begründung vom koordinator bzw freigabeberehtigtem rein";
                MembershipUser Modulverantwortlicher1 = Membership.GetUser("Freigeber");
                executer = new Guid(Modulverantwortlicher1.ProviderUserKey.ToString());
            }

            Job job = new Job()
            {
                JobCreated = System.DateTime.Now,
                JobCreatedBy = user,
                ModulID = module.ModulID,
                Executer = executer,
                Name = name,
                Text = text,
            };

            context.Jobs.Add(job);
            context.SaveChanges();
        }

        private static String getModulname(List<ModulPartDescription> mpdList)
        {
            String modulname = null;

            foreach (ModulPartDescription d in mpdList)
            {
                if (d.Name.Equals(GlobalNames.getModulNameText()))
                {
                    modulname = d.Description;
                }
            }

            return modulname;
        }
    }
}