using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ModulManagementSystem.Models
{
    public class Modul 
    {
        [ScaffoldColumn(false), KeyAttribute]
        public int ModulID { get; set; }

        public virtual ICollection<ModulPartDescription> Descriptions { get; set; }

        public ModulState State { get; set; }

        /// <summary>
        /// allowed values: x>0
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// User in charge of modul
        /// </summary>
        public Guid Owner { get; set; }

        /// <summary>
        /// Creator of this Version
        /// </summary>
        public Guid Autor { get; set; }

        public DateTime LastChange { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }

        public int Year { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
    public enum ModulState { created, waitingForAcceptionFromFreigabeberechtigter, freigeben, abgelehnt, vorgeschlagen };
}