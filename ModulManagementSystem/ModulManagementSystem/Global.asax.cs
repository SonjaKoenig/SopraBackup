using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using ModulManagementSystem;
using ModulManagementSystem.Models;
using System.Data.Entity;

namespace ModulManagementSystem
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
         
            // Code, der beim Anwendungsstart ausgeführt wird
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterOpenAuth();

            // Add Administrator.
            if (!Roles.RoleExists("Administrator"))
            {
                Roles.CreateRole("Administrator");
            }
            if (Membership.GetUser("Admin") == null)
            {
                Membership.CreateUser("Admin", "Pa$$word", "christian.brenner@uni-ulm.de");
                Roles.AddUserToRole("Admin", "Administrator");
            }

            if (!Roles.RoleExists("User"))
            {
                Roles.CreateRole("User");
            }

            if (!Roles.RoleExists("Freigabeberechtigter"))
            {
                Roles.CreateRole("Freigabeberechtigter");
                
            }
            if (Membership.GetUser("Freigeber") == null)
            {
                Membership.CreateUser("Freigeber", "Freigeber", "Freigeber@contoso.com");
                Roles.AddUserToRole("Freigeber", "Freigabeberechtigter");
            }


            if (!Roles.RoleExists("Modulverantwortlicher"))
            {
                Roles.CreateRole("Modulverantwortlicher");
            }
            if (Membership.GetUser("Modulverantwortlicher1") == null)
            {
                Membership.CreateUser("Modulverantwortlicher1", "Modulverantwortlicher1", "MV1@contoso.com");
                Roles.AddUserToRole("Modulverantwortlicher1", "Modulverantwortlicher");
            }
            if (Membership.GetUser("Modulverantwortlicher2") == null)
            {
                Membership.CreateUser("Modulverantwortlicher2", "Modulverantwortlicher2", "MV1@contoso.com");
                Roles.AddUserToRole("Modulverantwortlicher2", "Modulverantwortlicher");
            }

            if (!Roles.RoleExists("Koordinator"))
            {
                Roles.CreateRole("Koordinator");
            }
            if (Membership.GetUser("Koordinator") == null)
            {
                Membership.CreateUser("Koordinator", "Koordinator", "Koordinator@contoso.com");
                Roles.AddUserToRole("Koordinator", "Koordinator");
            }

            //Neuer Datenbank initializer, der mehrere Testdaten anlegt
            Database.SetInitializer(new ModulhandbookInitializer());
            using (var db = new ModulhandbookContext())
            {
                var x = db.Modules.ToList();
            }
        }

        void Application_End(object sender, EventArgs e)
        {
            

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code, der ausgeführt wird, wenn ein nicht behandelter Fehler auftritt

        }
    }
}
