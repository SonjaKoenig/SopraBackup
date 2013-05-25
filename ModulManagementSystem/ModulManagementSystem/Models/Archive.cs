using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ModulManagementSystem.Models
{
    public class Archive
    {
        public int ArchiveID { get; set; }

        public virtual ICollection<Semester> Semester { get; set; }
    }
}