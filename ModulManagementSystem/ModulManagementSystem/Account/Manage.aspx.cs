using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNet.Membership.OpenAuth;

namespace ModulManagementSystem.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        protected string SuccessMessage
        {
            get;
            private set;
        }

        protected void Page_Load()
        {
            if (!IsPostBack)
            {
                // Zu rendernde Abschnitte ermitteln
                var hasLocalPassword = true;
                changePassword.Visible = hasLocalPassword;
               
                // Rendererfolgsmeldung
                var message = Request.QueryString["m"];
                if (message != null)
                {
                    // Abfragezeichenfolge aus der Aktion entfernen
                    Form.Action = ResolveUrl("~/Account/Manage.aspx");

                    SuccessMessage =
                        message == "ChangePwdSuccess" ? "Ihr Kennwort wurde erfolgreich geändert."
                        : String.Empty;
                    successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
                }
            }

        }
        
        protected static string ConvertToDisplayDateTime(DateTime? utcDateTime)
        {
            return utcDateTime.HasValue ? utcDateTime.Value.ToLocalTime().ToString("G") : "[nie]";
        }
    }
}