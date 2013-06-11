<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModulAuswahl-Koo-Frei.aspx.cs" Inherits="ModulManagementSystem.Modulauswahl_Koo_Frei" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div >
        <asp:Table ID="ModulhandbookTable" runat="server"></asp:Table>
        <asp:Label runat="server" ID="ChosenModulhandbook"></asp:Label>
    </div>
    <div >
        <asp:Table ID="SubjectTable" runat="server"></asp:Table>
        <asp:Label runat="server" ID="ChosenSubject"></asp:Label>
    </div>
    <div >
        <asp:Table ID="ModulTable" runat="server"></asp:Table>
    </div>
    <div >
        <asp:button id="BackBtn" runat="server" text="Zurück" OnClientClick="JavaScript: window.history.back(1); return false;"></asp:button>
    </div>
</asp:Content>