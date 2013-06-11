
using ModulManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ModulManagementSystem.Core.DBOperations
{
    /// <summary>
    /// Creater: p streicher
    /// This class contains all logic for jobs. The jobs are in the database specified for every user.
    /// </summary>
    public class JobLogic
    {
        private ModulhandbookContext context = new ModulhandbookContext();

        /// <summary>
        /// get all jobs for the given user
        /// </summary>
        /// <param name="user">jobs should belong to the given user</param>
        /// <returns>returns an empty list if no jobs were found for the given user</returns>
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

        /// <summary>
        /// returns a job with the given id
        /// </summary>
        /// <param name="objId">id to search for</param>
        /// <returns>the job with the given id or null if no job is found</returns>
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

        /// <summary>
        /// creates a job depending on the modulstate and write it into the db 
        /// </summary>
        /// <param name="state">modulstate after which the job is created</param>
        /// <param name="mpdList">needed for job parameters</param>
        /// <param name="module">needed for the module id</param>
        /// <param name="user">the job creater</param>
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
            else if (state.Equals(ModulState.waitingForFreigeber))
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