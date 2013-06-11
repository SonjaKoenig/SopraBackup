<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModulBearbeiten.aspx.cs" Inherits="ModulManagementSystem.ModulBearbeiten" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="anzeigeBereich" style="float:left; width:20%; ">        
        <label>Modulpunkte</label>
        <asp:table ID="ModulpunkteTable" runat="server">
        </asp:table>
        <label>Fächer</label>
        <asp:DropDownList ID="DropDownList" runat="server" AutoPostBack="true" DataTextField="Name" DataValueField="ModulhandbookID">
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>    
        <asp:Table Id="SubjectsTable" runat="server"></asp:Table>
        <asp:Label ID="DebugLabel" runat="server"></asp:Label>
        <div style="height:100%">
        </div>       
    </div>
    <div style="float:left; padding-left:4em; width:auto">
        <asp:TextBox ID="NameTextBox" Enabled="false" runat="server" Text="Name" width="100%"></asp:TextBox>
        <br />       
        <asp:TextBox  ID="DescriptionTextBox" TextMode="multiline" runat="server" Text="Titel der Veranstaltung" height="200px" width="100%" style="resize:none"></asp:TextBox>
        <br />
        <asp:Label ID="CommentLabel" Text="Kommentar" runat="server" Style="color:black"></asp:Label>
        <br />
        <asp:TextBox ID="CommentTextBox" TextMode="MultiLine" runat="server" Text="" height="200px" width="100%" style="resize:none" Enabled="false"/>
        <br />
        <asp:Label ID="ErrorLabel" Text="Fehler" runat="server" Visible="false" Style="color:red"></asp:Label>
        <br />
        <asp:Button ID="CancelBtn" runat="server" Text="Abbrechen" OnClick="CancelBtn_Click" OnClientClick="return confirm('Möchten Sie das Modul verwerfen und zur Hauptseite zurückkehren?');"/> 
        <asp:Button ID="FurtherBtn" runat="server" Text="Weiter" OnClick="FurtherBtn_Click" />
        <asp:Button ID="AdoptBtn" runat="server" Text="Übernehmen" OnClick="AdoptBtn_Click" OnClientClick="return confirm('Möchten Sie das Modul wirklich erstellen?');"/>  
        <asp:Button ID="DeleteModulBtn" runat="server" Text="Modul löschen" OnClick="DeleteModulBtn_Click" OnClientClick="return confirm('Sind Sie sicher, dass Sie das Modul löschen wollen?');"/>  
        <asp:Button ID="ReleaseBtn" runat="server" Text="Modul freigeben" OnClick="ReleaseBtn_Click" visible="false" OnClientClick="return confirm('Sind Sie sicher, dass Sie das Modul freigeben wollen?');"/>
        <asp:Button ID="ControlBtn" runat="server" Text="Modul kontrollieren" OnClick="ControlBtn_Click" visible="false" OnClientClick="return confirm('Sind Sie mit dem Modul einverstanden?');"/>      
        <asp:Button ID="SendBackBtn" runat="server" Text="Modul ablehnen" OnClick="SendBackBtn_Click" visible="false" OnClientClick="return confirm('Wollen Sie diesen Modulvorschlag ablehnen');"/>
        <asp:Button ID="PdfBtn" runat="server" Text="Pdf anzeigen" OnClick="PdfBtn_Click" />
    </div>

</asp:Content>

