using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ModulManagementSystem.Models
{

    /// <summary>
    /// the database model for a Modulpartdescriptions.
    /// </summary>
    public class ModulPartDescription
    {
        [ScaffoldColumn(false)]
        public int ModulPartDescriptionID { get; set; }

        public bool IsNeeded { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public String Comment { get; set; }

        public int ModulID { get; set; }

        public virtual Modul Modul {get;set;}
    }
}