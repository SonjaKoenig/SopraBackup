using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ModulManagementSystem.Core.DBOperations
{
    public class UserContainer
    {
        public String Username { get; set; }
        public String Email { get; set; }
        public DateTime LastLoginDate { get; set; }
        public Boolean IsModulverantwortlicher { get; set; }
        public Boolean IsKoordinator { get; set; }
        public Boolean IsFreigabeberechtigter { get; set; }
        public Boolean IsAdmin { get; set; }

        public UserContainer(String Username, String Email, Boolean IsKoordinator, Boolean IsFreigabeberechtigter, Boolean IsModulverantwortlicher)
        {
            this.Username = Username;
            this.Email = Email;
            this.LastLoginDate = Membership.GetUser(Username).LastLoginDate;
            this.IsFreigabeberechtigter = IsFreigabeberechtigter;
            this.IsKoordinator = IsKoordinator;
            this.IsModulverantwortlicher = IsModulverantwortlicher;
        }

        public UserContainer(String Username, String Email, int RoleNumber)
        {
            this.Username = Username;
            this.Email = Email;
            this.LastLoginDate = Membership.GetUser(Username).LastLoginDate;
            RoleFromNumber(RoleNumber);
        }

        public UserContainer(String Username, String Email, String[] RoleStrings)
        {
            this.Username = Username;
            this.Email = Email;
            this.LastLoginDate = Membership.GetUser(Username).LastLoginDate;
            RoleFromStrings(RoleStrings);
        }

        /// <summary>
        ///     Converts a Number representing the roles of a user to a string array which lists them.
        /// </summary>
        /// <param name="role">
        ///     The number representing the roles of a user.
        /// </param>
        /// <returns>
        ///     User roles as octal-number generated as follows
        /// 
        ///     Koordinator             |   n   y   n   y   n   y   n   y
        ///     Freigabeberechtigter    |   n   n   y   y   n   n   y   y
        ///     Modulverantwortlicher   |   n   n   n   n   y   y   y   y
        ///     ------------------------+--------------------------------
        ///     role:                   |   0   1   2   3   4   5   6   7
        /// </returns>
        private void RoleFromNumber(int RoleNumber)
        {
            switch (RoleNumber)
            {
                case 0:
                    break;
                case 1:
                    this.IsKoordinator = true;
                    this.IsModulverantwortlicher = false;
                    this.IsFreigabeberechtigter = false;
                    break;
                case 2:
                    this.IsKoordinator = false;
                    this.IsModulverantwortlicher = false;
                    this.IsFreigabeberechtigter = true;
                    break;
                case 3:
                    this.IsKoordinator = true;
                    this.IsModulverantwortlicher = false;
                    this.IsFreigabeberechtigter = true;
                    break;
                case 4:
                    this.IsKoordinator = false;
                    this.IsModulverantwortlicher = true;
                    this.IsFreigabeberechtigter = false;
                    break;
                case 5:
                    this.IsKoordinator = true;
                    this.IsModulverantwortlicher = true;
                    this.IsFreigabeberechtigter = false;
                    break;
                case 6:
                    this.IsKoordinator = false;
                    this.IsModulverantwortlicher = true;
                    this.IsFreigabeberechtigter = true;
                    break;
                case 7:
                    this.IsKoordinator = true;
                    this.IsModulverantwortlicher = true;
                    this.IsFreigabeberechtigter = true;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Returns a String Array of a User's Roles.
        /// </summary>
        /// <returns>
        /// String array of User's Roles.
        /// </returns>
        public String[] RoleStrings()
        {
            List<String> toReturn = new List<String>();

            if (IsKoordinator)
            {
                toReturn.Add("Koordinator");
            }
            if (IsFreigabeberechtigter)
            {
                toReturn.Add("Freigabeberechtigter");
            }
            if (IsModulverantwortlicher)
            {
                toReturn.Add("Modulverantwortlicher");
            }
            if (IsAdmin)
            {
                toReturn.Add("Administrator");
            }

            return toReturn.ToArray();
        }

        /// <summary>
        /// Converts boolean values into a string array of user roles.
        /// </summary>
        /// <param name="IsKoordinator">True, if user is of Role "Koordinator"</param>
        /// <param name="IsFreigabeberechtigter">True, if user is of Role "Freigabeberechtigter"</param>
        /// <param name="IsModulverantwortlicher">True, if user is of Role "Modulverantwortlicher"</param>
        /// <returns>
        /// String array of user's roles.
        /// </returns>
        public static String[] RoleStrings(Boolean IsKoordinator, Boolean IsFreigabeberechtigter, Boolean IsModulverantwortlicher, Boolean IsAdmin)
        {
            List<String> toReturn = new List<String>();

            if (IsKoordinator)
            {
                toReturn.Add("Koordinator");
            }
            if (IsFreigabeberechtigter)
            {
                toReturn.Add("Freigabeberechtigter");
            }
            if (IsModulverantwortlicher)
            {
                toReturn.Add("Modulverantwortlicher");
            }
            if (IsAdmin)
            {
                toReturn.Add("Administrator");
            }

            return toReturn.ToArray();
        }

        /// <summary>
        /// Sets boolean representation of this user's roles according to the representation of the given string array.
        /// </summary>
        /// <param name="RoleStrings">Representation of the user's roles.</param>
        private void RoleFromStrings(String[] RoleStrings)
        {
            List<String> toCompare = RoleStrings.ToList();
            NoRole();

            foreach (String item in toCompare)
            {
                if (item.CompareTo("Koordinator") == 0)
                {
                    IsKoordinator = true;
                }
                if (item.CompareTo("Freigabeberechtigter") == 0)
                {
                    IsFreigabeberechtigter = true;
                }
                if (item.CompareTo("Modulverantwortlicher") == 0)
                {
                    IsModulverantwortlicher = true;
                }
                if (item.CompareTo("Administrator") == 0)
                {
                    IsAdmin = true;
                }
            }
        }

        private void NoRole()
        {
            IsKoordinator = false;
            IsFreigabeberechtigter = false;
            IsModulverantwortlicher = false;
        }

        /// <summary>
        /// Adds this User to the database and sends an email, if successful.
        /// </summary>
        /// <returns>
        /// True on success.
        /// False on fail.
        /// </returns>
        public Boolean AddThisUser(String Password)
        {
            MailOperations.MailLogic Mail = new MailOperations.MailLogic();
            try
            {
                Membership.CreateUser(Username, Password, Email);
                Roles.AddUserToRoles(Username, RoleStrings());
                Mail.SendMail("mms_admin_service@uni-ulm.de", Email, "Registration confirmed", "You've been successfully registered to the MMS!");
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}