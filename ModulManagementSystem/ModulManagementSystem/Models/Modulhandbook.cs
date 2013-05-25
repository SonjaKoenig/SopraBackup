using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ModulManagementSystem.Models
{
    public class Modulhandbook 
    {
        [ScaffoldColumn(false)]
        public int ModulhandbookID { get; set; }

        public String Name { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }

        public int SemesterID { get; set; }

        public String Abschluss { get; set; }

        public int FspoYear { get; set; }

        public String ValidSemester { get; set; }

    }
}