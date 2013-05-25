
using ModulManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    class DbTestInitializier
    {
        public DbTestInitializier(TestContext context)
        {
            //Neuer Datenbank initializer, der mehrere Testdaten anlegt

            Database.SetInitializer(new TestDataInitializer());
            using (var db = new TestContext())
            {
                var x = db.Modules.ToList();
            }
        }
    }
}
