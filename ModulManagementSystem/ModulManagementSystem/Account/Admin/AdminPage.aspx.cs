using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModulManagementSystem.Core.DBOperations;

namespace ModulManagementSystem.Account.Admin
{
    public partial class AdminPage : Page
    {

        private void DrawEditTable()
        {
            TableCell tc1 = new TableCell();
            TableCell tc2 = new TableCell();
            TableCell tc3 = new TableCell();
            TableCell tc4 = new TableCell();
            TableCell tc5 = new TableCell();
            TableCell tc6 = new TableCell();

            TextBox tb = new TextBox();
            tb.Width = 300;
            tb.Text = "Enter new email address";
            tc1.Text = "Change Email:";
            tc2.Controls.Add(tb);
            tc3.Text = "Save Changes.";

            TableRow trEmail = new TableRow();
            trEmail.Cells.Add(tc1);
            trEmail.Cells.Add(tc2);
            trEmail.Cells.Add(tc3);
            EditTable.Rows.Add(trEmail);


            DropDownList ddl = new DropDownList();
            ListItem li1 = new ListItem();
            ListItem li2 = new ListItem();
            ListItem li3 = new ListItem();
            ListItem li4 = new ListItem();
            li1.Value = "(none)";
            li2.Value = "Modulverantwortlicher";
            li3.Value = "Koordinator";
            li4.Value = "Freigabeberechtigter";
            li1.Text = "(none)";
            li2.Text = "Modulverantwortlicher";
            li3.Text = "Koordinator";
            li4.Text = "Freigabeberechtigter";
            ddl.Items.Add(li1);
            ddl.Items.Add(li2);
            ddl.Items.Add(li3);
            ddl.Items.Add(li4);
            ddl.Width = 313;
            ddl.SelectedIndex = 0;
            tc4.Text = "Change Role:";
            tc5.Controls.Add(ddl);
            tc6.Text = "Save Changes.";


            TableRow trRole = new TableRow();
            trRole.Cells.Add(tc4);
            trRole.Cells.Add(tc5);
            trRole.Cells.Add(tc6);
            EditTable.Rows.Add(trRole);

        }

        private void DrawUserTable()
        {
            /* Init Table with Headers */
            TableRow header = new TableRow();
            TableHeaderCell thc1 = new TableHeaderCell();
            TableHeaderCell thc2 = new TableHeaderCell();
            TableHeaderCell thc3 = new TableHeaderCell();
            TableHeaderCell thc4 = new TableHeaderCell();
            TableHeaderCell thc5 = new TableHeaderCell();
            thc1.Text = "Username";
            thc2.Text = "Email";
            thc3.Text = "Role";
            thc4.Text = "Last Login";
            header.Cells.Add(thc1);
            header.Cells.Add(thc2);
            header.Cells.Add(thc3);
            header.Cells.Add(thc4);
            header.Cells.Add(thc5);
            UserTable.Rows.Add(header);

            /* Add Users to Table */
            AdminUtilities au = new AdminUtilities();
            List<UserContainer> list = au.getAllUsers();

            int rows = list.Count;
            int count = 0;

            foreach (UserContainer user in list)
            {
                TableCell tc1 = new TableCell();
                TableCell tc2 = new TableCell();
                TableCell tc3 = new TableCell();
                TableCell tc4 = new TableCell();
                TableCell tc5 = new TableCell();

                if (list != null)
                {
                    if (list[count] != null)
                    {
                        LinkButton link = new LinkButton();
                        link.Text = user.Username;
                        link.ID = "Username" + count;
                        link.Click += User_Click;
                        tc1.Controls.Add(link);
                        tc2.Text = user.Email;
                        foreach (String role in user.RoleStrings())
                        {
                            if (role != user.RoleStrings().Last())
                            {
                                tc3.Text = tc3.Text + role + ", ";
                            }
                            else
                            {
                                tc3.Text = tc3.Text + role;
                            }
                        }
                        tc4.Text = user.LastLoginDate.ToString();
                        LinkButton link2 = new LinkButton();
                        link2.Text = "edit";
                        link2.ID = "Edit" + count;
                        link2.Click += User_Click;
                        tc5.Controls.Add(link2);
                    }
                }
                count++;
                TableRow tr = new TableRow();
                tr.Cells.Add(tc1);
                tr.Cells.Add(tc2);
                tr.Cells.Add(tc3);
                tr.Cells.Add(tc4);
                tr.Cells.Add(tc5);
                UserTable.Rows.Add(tr);
            }
        }
        private void DrawNewUserTable()
        {
            TableCell tc1 = new TableCell();
            TableCell tc2 = new TableCell();
            TableCell tc3 = new TableCell();
            TableCell tc4 = new TableCell();
            TableCell tc5 = new TableCell();
            TableCell tc6 = new TableCell();
            TableCell tc7 = new TableCell();
            TableCell tc8 = new TableCell();
            TableCell tc9 = new TableCell();
            TableCell tc10 = new TableCell();

            TextBox tb1 = new TextBox();
            tb1.Width = 300;
            tb1.Text = "Enter username";
            tc1.Text = "Username:";
            tc2.Controls.Add(tb1);

            TextBox tb2 = new TextBox();
            tb2.Width = 300;
            tb2.Text = "Enter email address";
            tc3.Text = "Email:";
            tc4.Controls.Add(tb2);

            TextBox tb3 = new TextBox();    
            tb3.Width = 300;
            tb3.Text = "Enter password";
            tc5.Text = "Password:";
            tc6.Controls.Add(tb3);

            TextBox tb4 = new TextBox();
            tb4.Width = 300;
            tb4.Text = "Repeat password";
            tc7.Text = "Repeat password:";
            tc8.Controls.Add(tb4);

            DropDownList ddl = new DropDownList();
            ListItem li1 = new ListItem();
            ListItem li2 = new ListItem();
            ListItem li3 = new ListItem();
            ListItem li4 = new ListItem();
            li1.Value = "(none)";
            li2.Value = "Modulverantwortlicher";
            li3.Value = "Koordinator";
            li4.Value = "Freigabeberechtigter";
            li1.Text = "(none)";
            li2.Text = "Modulverantwortlicher";
            li3.Text = "Koordinator";
            li4.Text = "Freigabeberechtigter";
            ddl.Items.Add(li1);
            ddl.Items.Add(li2);
            ddl.Items.Add(li3);
            ddl.Items.Add(li4);
            ddl.Width = 313;
            ddl.SelectedIndex = 0;
            tc9.Text = "Role:";
            tc10.Controls.Add(ddl);

            TableRow tr1 = new TableRow();
            TableRow tr2 = new TableRow();
            TableRow tr3 = new TableRow();
            tr1.Cells.Add(tc1);
            tr1.Cells.Add(tc2);
            tr1.Cells.Add(tc3);
            tr1.Cells.Add(tc4);
            tr2.Cells.Add(tc5);
            tr2.Cells.Add(tc6);
            tr2.Cells.Add(tc7);
            tr2.Cells.Add(tc8);
            tr3.Cells.Add(tc9);
            tr3.Cells.Add(tc10);
            NewUserTable.Rows.Add(tr1);
            NewUserTable.Rows.Add(tr2);
            NewUserTable.Rows.Add(tr3);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           // UserTable = GenerateTable();
            DrawUserTable();
            DrawEditTable();
            EditTable.Visible = false;
            AddUser.Visible = true;
            ResetPassword.Visible = false;
            CreateUser.Visible = false;
        }

        protected void User_Click(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            Label1.Text = "You are currently editing user " + "Blubb";
            EditTable.Visible = true;
            AddUser.Visible = false;
            ResetPassword.Visible = true;
        }

        protected void ResetPassword_Click(object sender, EventArgs e)
        {
            AdminUtilities au = new AdminUtilities();
            au.ResetPassword("");
        }

        protected void AddUser_Click(object sender, EventArgs e)
        {
            AdminUtilities au = new AdminUtilities();
            DrawNewUserTable();
            AddUser.Visible = false;
            Label1.Text = "You are currently creating a new user.";
            CreateUser.Visible = true;
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            AdminUtilities au = new AdminUtilities();
        }       
    }
}