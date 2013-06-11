using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ModulManagementSystem.Core.DBOperations
{
    public class AdminUtilities
    {
        /// <summary>
        ///     Gets a list of all registered users of the System.
        /// </summary>
        /// <returns>
        ///     Returns a list of UserContainers
        /// </returns>
        public List<UserContainer> getAllUsers()
        {
            MembershipUserCollection allUsers;
            List<UserContainer> toReturn = new List<UserContainer>();
            
            allUsers = Membership.GetAllUsers();
            foreach (MembershipUser user in allUsers)
            {
                try
                {
                    UserContainer item = new UserContainer(user.UserName, user.Email, Roles.GetRolesForUser(user.UserName));
                    toReturn.Add(item);
                }
                catch (NotSupportedException e)
                { }
            }

            return toReturn;
        }

        /// <summary>
        ///     Adds a new User to the System
        /// </summary>
        /// <param name="name">User's loginname</param>
        /// <param name="password">User's password</param>
        /// <param name="email">User's email address</param>
        /// <param name="IsKoordinator">True, if user is of Role "Koordinator"</param>
        /// <param name="IsFreigabeberechtigter">True, if user is of Role "Freigabeberechtigter"</param>
        /// <param name="IsModulverantwortlicher">True, if user is of Role "Modulverantwortlicher"</param>
        /// </param>
        /// <returns>
        ///     Returns true if adding was successfull; False otherwise.
        /// </returns>
        public Boolean addUser(String name, String password, String email, Boolean IsKoordinator, Boolean IsFreigabeberechtigter, Boolean IsModulverantwortlicher)
        {
            UserContainer NewUser = new UserContainer(name, email, IsModulverantwortlicher, IsKoordinator, IsFreigabeberechtigter);
            return NewUser.AddThisUser(password);
        }

        public Boolean addUser(UserContainer NewUser, String Password)
        {
            return NewUser.AddThisUser(Password);
        }
        
        /// <summary>
        ///     Resets user's password.
        /// </summary>
        /// <param name="name">Name of the user, whose password is to be resetted.</param>
        /// <returns>
        ///     True on success.
        ///     False on fail.
        /// </returns>
        public Boolean ResetPassword(String name)
        {
            try
            {
                Membership.GetUser(name).ResetPassword();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        ///     Changes users email address.
        /// </summary>
        /// <param name="name">Name of the user, whose email is to be changed.</param>
        /// <param name="newEmail">New email address of the user.</param>
        /// <returns>
        ///     True on success.
        ///     False on fail.
        /// </returns>
        public Boolean ChangeEmail(String name, String newEmail)
        {
            try
            {
                Membership.GetUser(name).Email = newEmail;
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        ///     Sets roles of a user to the roles corresponding to the integer roles.
        /// </summary>
        /// <param name="name">Name of the user, whose roles are to be changed.</param>
        /// <param name="IsKoordinator">True, if user is of Role "Koordinator"</param>
        /// <param name="IsFreigabeberechtigter">True, if user is of Role "Freigabeberechtigter"</param>
        /// <param name="IsModulverantwortlicher">True, if user is of Role "Modulverantwortlicher"</param>
        /// </param>
        /// <returns>
        ///     True on success.
        ///     False on fail.
        ///  </returns>
        public Boolean ChangeRole(String name, Boolean IsKoordinator, Boolean IsFreigabeberechtigter, Boolean IsModulverantwortlicher)
        {
            try
            {
                Roles.AddUserToRoles(name, UserContainer.RoleStrings(IsKoordinator, IsFreigabeberechtigter, IsModulverantwortlicher, false));
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }
    }
}