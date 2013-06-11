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
        <label>FÃ¤cher</label>
        <asp:DropDownList ID="DropDownList" runat="server" AutoPostBack="true" DataTextField="Name" DataValueField="ModulhandbookID">
        <asp:ListItem></asp:ListItem>
        </asp:DropDownList>  
        <asp:Table Id="SubjectsTable" runat="server"></asp:Table>
    </div>
    <div style="float:left; padding-left:4em; width:auto">
        <asp:TextBox ID="NameTextBox" Enabled="false" runat="server" width="100%"></asp:TextBox>
        <br />       
        <asp:TextBox  ID="DescriptionTextBox" TextMode="multiline" runat="server" height="200px" width="100%" style="resize:none"></asp:TextBox>
        <br />
        <asp:Label ID="ErrorLabel" Text="Fehler" runat="server" Visible="false" Style="color:red"></asp:Label>
        <br />
        <asp:Button ID="CancelBtn" runat="server" Text="Abbrechen" OnClick="CancelBtn_Click" OnClientClick="return confirm('MÃ¶chten Sie das Modul verwerfen und zur Hauptseite zurÃ¼ckkehren?');"/> 
        <asp:Button ID="FurtherBtn" runat="server" Text="Weiter" OnClick="FurtherBtn_Click" />
        <asp:Button ID="AdoptBtn" runat="server" Text="Ãœbernehmen" OnClick="AdoptBtn_Click" OnClientClick="return confirm('MÃ¶chten Sie das Modul wirklich erstellen?');"/>
        <asp:Button ID="PdfBtn" runat="server" Text="Pdf anzeigen" OnClick="PdfBtn_Click" />
    </div>

</asp:Content>
