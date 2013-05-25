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
        ///     Returns a list of string-arrays {username, email, role, lastlogin}, 
        ///     where role is an octal-number generated as follows
        /// 
        ///     Koordinator             |   n   y   n   y   n   y   n   y
        ///     Freigabeberechtigter    |   n   n   y   y   n   n   y   y
        ///     Modulverantwortlicher   |   n   n   n   n   y   y   y   y
        ///     ------------------------+--------------------------------
        ///     role:                   |   0   1   2   3   4   5   6   7
        /// </returns>
        public List<string[]> getAllUsers()
        {
            MembershipUserCollection allUsers;
            List<string[]> toReturn = new List<string[]>();
            string[] userStrings = new string[4];
            allUsers = Membership.GetAllUsers();

            foreach (MembershipUser user in allUsers)
            {
                String[] roles;

                roles = Roles.GetRolesForUser(user.UserName);                

                userStrings[0] = user.UserName;
                userStrings[1] = user.Email;
                userStrings[2] = RoleStringsToNumber(roles)+"";
                userStrings[3] = user.LastLoginDate.ToString();

                toReturn.Add(userStrings);
            }

            return toReturn;
        }

        /// <summary>
        ///     Adds a new User to the System
        /// </summary>
        /// <param name="name">User's loginname</param>
        /// <param name="password">User's password</param>
        /// <param name="email">User's email address</param>
        /// <param name="role">
        ///     User roles as octal-number generated as follows
        /// 
        ///     Koordinator             |   n   y   n   y   n   y   n   y
        ///     Freigabeberechtigter    |   n   n   y   y   n   n   y   y
        ///     Modulverantwortlicher   |   n   n   n   n   y   y   y   y
        ///     ------------------------+--------------------------------
        ///     role:                   |   0   1   2   3   4   5   6   7
        /// </param>
        /// <returns>
        ///     Returns true if adding was successfull; False otherwise.
        /// </returns>
        public Boolean addUser(String name, String password, String email, int role)
        {
            string[] rolesToAdd = new string[] {};
            try
            {
                Membership.CreateUser(name, password);

                rolesToAdd = RoleNumberToStrings(role);

                Roles.AddUserToRoles(name, rolesToAdd);
            }
            catch (MembershipCreateUserException e)
            {
                return false;
            }
            catch(ArgumentNullException e1)
            {
                return false;
            }
            catch(ArgumentException e2) 
            {
                return false;
            }
            catch(System.Configuration.Provider.ProviderException e3)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        ///     Converts an Array of Rolenames to its corresponding number.
        /// </summary>
        /// <param name="roles">
        ///     A String array, listing the roles of a user.
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
        public int RoleStringsToNumber(String[] roles)
        {
            int role = 0;

            foreach (string rolename in roles)
            {
                if (rolename.CompareTo("Koordinator") == 0)
                {
                    role += 1;
                }
                if (rolename.CompareTo("Freigabeberechtigter") == 0)
                {
                    role += 2;
                }
                if (rolename.CompareTo("Modulverantwortlicher") == 0)
                {
                    role += 4;
                }
            }

            return role;
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
        public String[] RoleNumberToStrings(int role)
        {
            String[] rolesToAdd = new string[] {};
            switch (role)
            {
                case 0:
                    break;
                case 1:
                    rolesToAdd = new string[] { "Koordinator" };
                    break;
                case 2:
                    rolesToAdd = new string[] { "Freigabeberechtigter" };
                    break;
                case 3:
                    rolesToAdd = new string[] { "Freigabeberechtigter", "Koordinator" };
                    break;
                case 4:
                    rolesToAdd = new string[] { "Modulverantwortlicher" };
                    break;
                case 5:
                    rolesToAdd = new string[] { "Modulverantwortlicher", "Koordinator" };
                    break;
                case 6:
                    rolesToAdd = new string[] { "Freigabeberechtigter", "Modulverantwortlicher" };
                    break;
                case 7:
                    rolesToAdd = new string[] { "Freigabeberechtigter", "Modulverantwortlicher", "Koordinator" };
                    break;
                default:
                    rolesToAdd = null;
                    break;
            }

            return rolesToAdd;
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
        /// <param name="roles">
        ///     User roles as octal-number generated as follows
        /// 
        ///     Koordinator             |   n   y   n   y   n   y   n   y
        ///     Freigabeberechtigter    |   n   n   y   y   n   n   y   y
        ///     Modulverantwortlicher   |   n   n   n   n   y   y   y   y
        ///     ------------------------+--------------------------------
        ///     role:                   |   0   1   2   3   4   5   6   7
        /// </param>
        /// <returns>
        ///     True on success.
        ///     False on fail.
        ///  </returns>
        public Boolean ChangeRole(String name, int roles)
        {
            try
            {
                Roles.RemoveUserFromRoles(name, RoleNumberToStrings(7));
                Roles.AddUserToRoles(name, RoleNumberToStrings(roles));
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }
    }
}