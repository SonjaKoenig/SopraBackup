using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ModulManagementSystem.Models
{
    public class ModulhandbookContext : DbContext
    {
        public ModulhandbookContext()
            : base("ModulManagementSystemData")
        {

        }

        public DbSet<Subject> Subjects { get; set; }        
        public DbSet<Archive> Archive { get; set; }
        public DbSet<Modul> Modules { get; set; }
        public DbSet<Modulhandbook> Modulhandbooks { get; set; }
        public DbSet<ModulPartDescription> ModulPartDescriptiones { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Job> Jobs { get; set; }
    }
}