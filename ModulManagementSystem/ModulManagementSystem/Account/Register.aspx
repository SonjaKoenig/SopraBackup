<%@ Page Title="Registrieren" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ModulManagementSystem.Account.Register" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1 style="color: #3e5667"><%: Title %>.</h1>
        <h2 style="color: #999">Erstellen Sie mit dem unten stehenden Formular ein neues Konto.</h2>
    </hgroup>

    <div id="register_panel">
        <asp:CreateUserWizard runat="server" ID="RegisterUser" ViewStateMode="Disabled" OnCreatedUser="RegisterUser_CreatedUser">
            <LayoutTemplate>
                <asp:PlaceHolder runat="server" ID="wizardStepPlaceholder" />
                <asp:PlaceHolder runat="server" ID="navigationPlaceholder" />
            </LayoutTemplate>
            <WizardSteps>

                <asp:CreateUserWizardStep runat="server" ID="RegisterUserWizardStep">

                    <ContentTemplate>
                        <p class="message-info">
                            Kennwörter müssen mindestens <%: Membership.MinRequiredPasswordLength %> Zeichen lang sein.
                        </p>
                        <p class="validation-summary-errors">
                            <asp:Literal runat="server" ID="ErrorMessage" />
                        </p>

                        <fieldset>
                            <legend>Registrierungsformular</legend>
                            <ol>
                                <li>
                                    <asp:Label runat="server" AssociatedControlID="UserName">Benutzername</asp:Label>
                                    <asp:TextBox runat="server" ID="UserName" Width="200px"/>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                                        CssClass="field-validation-error" ErrorMessage="Das Benutzernamefeld ist erforderlich." />
                                </li>
                                <li>
                                    <asp:Label runat="server" AssociatedControlID="Email">E-Mail-Adresse</asp:Label>
                                    <asp:TextBox runat="server" ID="Email" TextMode="Email" Width="200px"/>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                        CssClass="field-validation-error" ErrorMessage="Das E-Mail-Adressfeld ist erforderlich." />
                                </li>
                                <li>
                                    <asp:Label runat="server" AssociatedControlID="Password">Kennwort</asp:Label>
                                    <asp:TextBox runat="server" ID="Password" TextMode="Password" Width="200px"/>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                                        CssClass="field-validation-error" ErrorMessage="Das Kennwortfeld ist erforderlich." />
                                </li>
                                <li>
                                    <asp:Label runat="server" AssociatedControlID="ConfirmPassword">Kennwort bestätigen</asp:Label>
                                    <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" Width="200px" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                                        CssClass="field-validation-error" Display="Dynamic" ErrorMessage="Das Feld zum Bestätigen des Kennworts ist erforderlich." />
                                    <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                        CssClass="field-validation-error" Display="Dynamic" ErrorMessage="Das Kennwort entspricht nicht dem Bestätigungskennwort." />
                                </li>
                            </ol>
                            <asp:Label ID="Label1" runat="server" Text="Label">Wählen Sie eine Rolle aus:</asp:Label>
                            <asp:DropDownList ID="DropDownListRolle" runat="server" DataSourceID="SqlDataSource1" DataTextField="RoleName" DataValueField="RoleName" Width="200px">
                            </asp:DropDownList>

                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MMSDbConnectionString %>" SelectCommand="SELECT [RoleName] FROM [Roles]"></asp:SqlDataSource>
                            <br />
                            <br />
                            <asp:Label ID="Label3" runat="server" Text="Fakultät:"></asp:Label>
                            <asp:DropDownList ID="DropDownListFakultaet" runat="server" Width="250px">
                                <asp:ListItem>Ingenieurswissenschaften und Informatik</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                            <br />
                            <asp:Button ID="RegisterButton" runat="server" CommandName="MoveNext" Text="Registrieren" OnClick="Register_Click" AccessKey="S" ToolTip="Einen neuen Account registrieren"/>
                            <br />
                            <br />
                            <asp:Label ID="Label2" runat="server" Text="Kommentar:"></asp:Label>
                            <br />
                            <br />
                            <asp:TextBox ID="CommentBox" runat="server" Height="90px" Width="227px"></asp:TextBox>
                            <br />
                            <br />

                        </fieldset>
                    </ContentTemplate>
                    <CustomNavigationTemplate />
                </asp:CreateUserWizardStep>
<asp:CompleteWizardStep runat="server"></asp:CompleteWizardStep>
            </WizardSteps>
        </asp:CreateUserWizard>
    </div>
</asp:Content>
