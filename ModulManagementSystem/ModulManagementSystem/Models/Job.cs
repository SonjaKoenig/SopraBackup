using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ModulManagementSystem.Models
{

    /// <summary>
    /// the database model for a Job.
    /// </summary>
    public class Job
    {
        [ScaffoldColumn(false), KeyAttribute]

        public int JobID { get; set; }

        public String Name { get; set; }

        public String Text { get; set; }

        public DateTime JobCreated { get; set; }

        public Guid Executer { get; set; }

        public Guid JobCreatedBy { get; set; }

        public int ModulID {get; set;}
    }
}