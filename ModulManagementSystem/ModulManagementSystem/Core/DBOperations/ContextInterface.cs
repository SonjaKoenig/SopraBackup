using ModulManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModulManagementSystem.Core.DBOperations
{
    public abstract class ContextInterface : DbContext
    {
        public ContextInterface(string connectionString) : base(connectionString) { }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Archive> Archive { get; set; }
        public DbSet<Modul> Modules { get; set; }
        public DbSet<Modulhandbook> Modulhandbooks { get; set; }
        public DbSet<ModulPartDescription> ModulPartDescriptiones { get; set; }
        public DbSet<Semester> Semesters { get; set; }

    }
}
