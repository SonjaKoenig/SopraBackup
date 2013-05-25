using ModulManagementSystem;
using ModulManagementSystem.Core.DBOperations;
using ModulManagementSystem.Core.PDFOperations;
using ModulManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ModulManagementSystem
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;
        private ArchiveLogic logic = new ArchiveLogic();

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MakeLinksVisible();
        }

        private void MakeLinksVisible()
        {
            if (HttpContext.Current.User.IsInRole("Administrator"))
            {
                adminLink.Visible = true;
            }

            if (HttpContext.Current.User.IsInRole("Modulverantwortlicher"))
            {
               // modulCreate.Visible = true;
               // modulEdit.Visible = true;
            }

            if (HttpContext.Current.User.IsInRole("Freigabeberechtigter") || HttpContext.Current.User.IsInRole("Koordinator"))
            {
            //    modulControl.Visible = true;
            }
        }

        //protected void SearchButton_Click(object sender, EventArgs e)
        //{
        //    searchResultList.Items.Clear();
        //    List<Object> searchResults = logic.getSearchResults(SearchText.Text.ToLower());
        //    foreach (Object s in searchResults)
        //    {
        //        if (s is Modul)
        //        {
        //            searchResultList.Items.Add(new ListItem(logic.getNameFromModule((Modul)s) + " - " + ((Modul)s).Year));
        //        }
        //        else if (s is Subject)
        //        {//TODO subjects sollen nicht direkt in den ergebnissen angezeigt werden sondern nur alle module die zu dem subject gehören                    
        //            searchResultList.Items.Add(new ListItem(((Subject)s).Name));
        //        }
        //        else if (s is Modulhandbook)
        //        {
        //            searchResultList.Items.Add(new ListItem(((Modulhandbook)s).Name + " - " + ((Modulhandbook)s).FspoYear));
        //        }
        //    }               
        //}

        //protected void searchResultList_Click(object sender, BulletedListEventArgs e)
        //{
        //    String objName = searchResultList.Items[e.Index].Text;

        //    objName = objName.Remove(objName.LastIndexOf('-') - 1).ToLower();
        //    PDFHandler pdf = new PDFHandler();
        //    Modulhandbook mhb = logic.getModulhandbookByName(objName);
        //    Modul module = logic.getModuleByNameAttendVersion(objName);
        //    Subject subj = logic.getSubjectByName(objName);
        //    if (mhb != null)
        //    {
        //        pdf.WriteModulhandbookToPdf(mhb, Server);
        //    }
        //    else if (module != null)
        //    {
        //        pdf.CreatePDF(module, Server);
        //    }
        //    else if (subj != null)
        //    {
        //        pdf.CreateAndOpenSoubjectPdf(subj, Server);
        //    }
        //}
    }
}