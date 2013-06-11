<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModulAuswahl-Modulverantwortlicher.aspx.cs" Inherits="ModulManagementSystem.ModulAuswahl_Modulverantwortlicher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Table ID="ModulhandbookTable" runat="server"></asp:Table>
        <asp:Label ID="ChosenModulhandbook" runat="server"></asp:Label>
    </div>
    <div>
        <asp:Table ID="SubjectTable" runat="server"></asp:Table>
        <asp:Label ID="ChosenSubject" runat="server"></asp:Label>
    </div>
    <div style="margin-left:12em">
        <asp:Table ID="ModulTable" runat="server"></asp:Table>
        <asp:LinkButton ID="NewModulBtn" runat="server" Text="neues Modul erstellen"  Visible="false"></asp:LinkButton>
    </div>
    <div style="margin-left:4em">
        <asp:button id="BackBtn" runat="server" text="Zurück" OnClientClick="JavaScript: window.history.back(1); return false;"></asp:button>
    </div>
    </asp:Content>