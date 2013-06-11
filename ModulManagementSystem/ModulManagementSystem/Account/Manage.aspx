<%@ Page Title="Account settings" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="ModulManagementSystem.Account.Manage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Verwalten Sie Ihr Konto.</h2>
    </hgroup>

    <section id="passwordForm">
        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
            <p class="message-success"><%: SuccessMessage %></p>
        </asp:PlaceHolder>

        <p style="padding: 12px; color: #808080;">Sie sind angemeldet als <strong><%: User.Identity.Name %></strong>.</p>        

        <div id="info_panel" style="padding: 12px; top: 23px; left: 0px; height: 429px; width: 345px;">
            <asp:PlaceHolder runat="server" ID="changePassword" Visible="false">
                <h3 style="color: white;">Kennwort ändern</h3>
                <p>&nbsp;</p>
                <asp:ChangePassword ID="ChangePassword1" runat="server" CancelDestinationPageUrl="~/" ViewStateMode="Disabled" RenderOuterTable="false" SuccessPageUrl="Manage.aspx?m=ChangePwdSuccess">
                    <ChangePasswordTemplate>
                        <p class="validation-summary-errors">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                        <fieldset class="changePassword">
                            <legend>Details zum Ändern des Kennworts</legend>
                            <ol>
                                <li>
                                    <asp:Label runat="server" ID="CurrentPasswordLabel" AssociatedControlID="CurrentPassword" style="color: white;">Aktuelles Kennwort</asp:Label>
                                    <asp:TextBox runat="server" ID="CurrentPassword" CssClass="passwordEntry" TextMode="Password" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="CurrentPassword"
                                        CssClass="field-validation-error" ErrorMessage="Das Feld für das aktuelle Kennwort ist erforderlich."
                                        ValidationGroup="ChangePassword" />
                                </li>
                                <li>
                                    <asp:Label runat="server" ID="NewPasswordLabel" AssociatedControlID="NewPassword" style="color: white;">Neues Kennwort</asp:Label>
                                    <asp:TextBox runat="server" ID="NewPassword" CssClass="passwordEntry" TextMode="Password" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="NewPassword"
                                        CssClass="field-validation-error" ErrorMessage="Das neue Kennwort ist erforderlich."
                                        ValidationGroup="ChangePassword" />
                                </li>
                                <li>
                                    <asp:Label runat="server" ID="ConfirmNewPasswordLabel" AssociatedControlID="ConfirmNewPassword" style="color: white;">Neues Kennwort bestätigen</asp:Label>
                                    <asp:TextBox runat="server" ID="ConfirmNewPassword" CssClass="passwordEntry" TextMode="Password" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ConfirmNewPassword"
                                        CssClass="field-validation-error" Display="Dynamic" ErrorMessage="Das Bestätigen des neuen Kennworts ist erforderlich."
                                        ValidationGroup="ChangePassword" />
                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword"
                                        CssClass="field-validation-error" Display="Dynamic" ErrorMessage="Das neue Kennwort entspricht nicht dem Bestätigungskennwort."
                                        ValidationGroup="ChangePassword" />
                                </li>
                            </ol>
                            <asp:Button ID="Button2" runat="server" CommandName="ChangePassword" Text="Kennwort ändern" ValidationGroup="ChangePassword" />
                        </fieldset>
                    </ChangePasswordTemplate>
                </asp:ChangePassword>
            </asp:PlaceHolder>
        </div>
    </section>

    
</asp:Content>
