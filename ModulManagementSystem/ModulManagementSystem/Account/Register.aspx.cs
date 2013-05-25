using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Membership.OpenAuth;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using ModulManagementSystem.Core.MailOperations;



namespace ModulManagementSystem.Account
{
    public partial class Register : Page
    {
        private MailLogic mailLogic = new MailLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];

           

        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, createPersistentCookie: false);

            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            if (!OpenAuth.IsLocalUrl(continueUrl))
            {
                continueUrl = "~/Pages/Default.aspx";
            }
            Response.Redirect("~/Pages/Default.aspx");
        }


        /// <summary>
        /// sending mail after registration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

         public void Register_Click(object sender, EventArgs e)
        {

            DropDownList roleList = (DropDownList)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("DropDownListRolle");
            DropDownList facultyList = (DropDownList)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("DropDownListFakultaet");
            TextBox commentBox = (TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("CommentBox");
            Button regButton = (Button)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("RegisterButton");


            mailLogic.SendMail(Membership.GetUser("Admin").Email, RegisterUser.Email,"Registrierungs erfolgreich","Hallo " + RegisterUser.UserName +
                  ".\n\n In kuerze erhalten Sie eine Bestaetigung vom Admin.");


            mailLogic.SendMail(RegisterUser.Email, Membership.GetUser("Admin").Email, "Account zum freischalten", RegisterUser.UserName + " moechte sich registrieren lassen. \nGewaehlte Rolle: " + roleList.Text +
               " \nKommentar: " + commentBox.Text + " \nFakultaet: " + facultyList.Text);

            if (Membership.GetUser(RegisterUser.UserName) == null)
            {
                Membership.CreateUser(RegisterUser.UserName, RegisterUser.Password, RegisterUser.Email);
                //  Roles.AddUserToRole(RegisterUser.UserName, "User");

            }
            Response.Redirect("/Default.aspx");

             }
        }
    }
