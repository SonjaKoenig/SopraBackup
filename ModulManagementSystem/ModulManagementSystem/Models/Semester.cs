using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModulManagementSystem.Models
{

    /// <summary>
    /// the database model for a Semester.
    /// </summary>
    public class Semester
    {
        public int SemesterID { get; set; }

        public String Name { get; set; }

        public virtual ICollection<Modulhandbook> ModulHandbooks { get; set; }

        public int ArchiveID { get; set; }
    }
}