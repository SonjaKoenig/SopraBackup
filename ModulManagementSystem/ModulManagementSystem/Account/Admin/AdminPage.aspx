<%@ Page Title="Administration." Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="ModulManagementSystem.Account.Admin.AdminPage" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
     <hgroup class="title">
        <h1> Title %></h1>
        <h2>Be almighty. And have yourself a sandwich made.</h2>
    </hgroup>

    <section class="DefaultContainer" style="padding:12px"><%--User Management--%>
        <div class="DefaultTable" style="padding: 12px; color: white;">
            <p style="margin-top: 0">User Accounts<asp:Table runat="server" ID="UserTable" HorizontalAlign="Center">
                </asp:Table> <%--User Table--%>
            </p>
        </div>
    </section>
    <section class="DefaultContainer" style="padding:12px"><%--User Edit--%>
        <div class="DefaultTable" style="padding: 12px; color: white; top: 10px; left: 10px; height: 146px;">
            
            <asp:Label ID="Label1" runat="server" Text="You are currently editing no User." ForeColor="White"></asp:Label>
             <p style="margin-top: 0">
                 <asp:Table runat="server" ID="EditTable" HorizontalAlign="Center">
                 </asp:Table> <%--Edit Table--%>
                 <asp:Table runat="server" ID="NewUserTable" HorizontalAlign="Center">
                 </asp:Table> <%--Edit Table--%>
                 <p style="padding: 12px">
                     <asp:Button ID="ResetPassword" runat="server" Text="Reset Password" OnClick="ResetPassword_Click" />
                     <asp:Button ID="AddUser" runat="server" Text="Add new user" OnClick="AddUser_Click" />
                     <asp:Button ID="CreateUser" runat="server" Text="Quack quack go!" OnClick="CreateUser_Click" />
                 </p>
             </p>
            
        </div>
    </section>
    <section class="DefaultContainer" style="padding:12px; color:white;"><%--News Management--%>
        <div class="DefaultTable" style="padding: 13px">
            <p>Aktuell angezeigte News<asp:Table ID="NewsTable" runat="server">
                </asp:Table>
            </p>
            <%--Aktuelle News Table--%>
        </div>
    </section>
</asp:Content>