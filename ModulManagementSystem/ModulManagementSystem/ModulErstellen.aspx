<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModulErstellen.aspx.cs" Inherits="ModulManagementSystem.ModulErstellen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="anzeigeBereich" style="float:left; width:20%; ">        
        <label>Modulpunkte</label>
        <asp:table ID="ModulpunkteTable" runat="server">
        </asp:table>
        <div style="height:100%">

        </div>       
    </div>
    <div style="float:left; width:50%">
        <asp:TextBox ID="NameTextBox" Enabled="false" runat="server" width="100%"></asp:TextBox>
        <br />       
        <asp:TextBox  ID="DescriptionTextBox" TextMode="multiline" runat="server" height="200px" width="100%" style="resize:none"></asp:TextBox>
        <br />
        <asp:Label ID="ErrorLabel" Text="Fehler" runat="server" Visible="false" Style="color:red"></asp:Label>
        <br />
        <asp:Button ID="CancelBtn" runat="server" Text="Abbrechen" OnClick="CancelBtn_Click" OnClientClick="return confirm('Möchten Sie das Modul verwerfen und zur Hauptseite zurückkehren?');"/> 
        <asp:Button ID="FurtherBtn" runat="server" Text="Weiter" OnClick="FurtherBtn_Click" />
        <asp:Button ID="AdoptBtn" runat="server" Text="Übernehmen" OnClick="AdoptBtn_Click" OnClientClick="return confirm('Möchten Sie das Modul wirklich erstellen?');"/>
        <asp:Button ID="PdfBtn" runat="server" Text="Pdf anzeigen" OnClick="PdfBtn_Click" />
    </div>
    <div style="padding-left:4em; width:25%; float:left ">
        <label>Fächer</label>
        <asp:DropDownList ID="DropDownList" runat="server" AutoPostBack="true" DataSourceID="handbooksource" DataTextField="Name" DataValueField="ModulhandbookID">
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="handbooksource" runat="server" ConnectionString="<%$ ConnectionStrings:ModulManagementSystemData %>" SelectCommand="SELECT [Name], [ModulhandbookID], [SemesterID], [Abschluss], [FspoYear], [ValidSemester] FROM [Modulhandbooks]"></asp:SqlDataSource>       
        <asp:Table Id="SubjectsTable" runat="server"></asp:Table>
    </div>
</asp:Content>
