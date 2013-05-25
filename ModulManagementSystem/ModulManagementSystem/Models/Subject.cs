using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ModulManagementSystem.Models
{
    public class Subject
    {
        [ScaffoldColumn(false)]
        public int SubjectID { get; set; }

        public string Name { get; set; }

        [Display(Name = "Modulhandbook")]
        public int ModulhandbookID { get; set; }

        public virtual Modulhandbook Modulhandbook { get; set; }
        
        public virtual ICollection<Modul> Modules { get; set; }

        public int Year { get; set; }
    }
}