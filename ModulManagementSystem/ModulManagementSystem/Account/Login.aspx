<%@ Page Title="Anmelden" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ModulManagementSystem.Account.Login" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1 style="color: #3e5667"><%: Title %>.</h1>
        <h2 style="color: #999">Lokales Konto für die Anmeldung verwenden.</h2>
    </hgroup>
    <section id="loginForm">
        <asp:Login runat="server" ViewStateMode="Disabled" RenderOuterTable="false">
            <LayoutTemplate>
                <p class="validation-summary-errors">
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
                <div id="login_panel" style="padding: 12px 12px 32px 12px; width: auto; height: auto">
                <fieldset>
                    <legend>Anmeldeformular</legend>
                    <ol>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="UserName">Benutzername</asp:Label>
                            <asp:TextBox runat="server" ID="UserName" Width="200px" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" CssClass="field-validation-error" ErrorMessage="Das Benutzernamefeld ist erforderlich." />
                        </li>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="Password">Kennwort</asp:Label>
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" Width="200px" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="field-validation-error" ErrorMessage="Das Kennwortfeld ist erforderlich." />
                        </li>
                        <li>
                            <asp:CheckBox runat="server" ID="RememberMe" />
                            <asp:Label runat="server" AssociatedControlID="RememberMe" CssClass="checkbox">Speichern?</asp:Label>
                        </li>
                    </ol>
                    <asp:Button runat="server" CommandName="Login" Text="Anmelden"/>
                </fieldset>
            </LayoutTemplate>
        </asp:Login>
        <p>
            <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Registrieren</asp:HyperLink>
            wenn Sie noch kein Konto besitzen.
        </p>
        </div>
    </section>
</asp:Content>
