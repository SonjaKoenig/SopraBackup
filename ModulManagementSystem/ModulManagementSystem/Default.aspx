<%@ Page Title="Willkommen" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ModulManagementSystem._Default" %>

<asp:Content runat="server" ID="Searchbar" ContentPlaceHolderID="Searchbar">
    <div class=float-right id="searchbar-position">
        ^&nbsp;&nbsp;&nbsp; s<asp:TextBox runat="server" ID="SearchText" CssClass="searchbox-style" />
        <asp:Button ID="SearchButton" runat="server" CommandName="SearchButton" Text="Suchen" OnClick="SearchButton_Click" />
    </div>
</asp:Content>
<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %></h1>
                <h2>Alles rund um Modulhandbücher, Fächer und Module</h2>
            </hgroup>
            <div class="DefaultContainer">
                <div id="job_list"> 
                    <asp:BulletedList ID="jobList" runat="server" DisplayMode="LinkButton" OnClick="jobList_Click" CssClass="list-style"></asp:BulletedList>
                </div>
                <div class="DefaultContainer-Left">
                    <%-- Funktionen für registrierte Nutzer (buttons and links) --%>
                    <div id="modul_control">
                        <asp:LinkButton runat="server" ID="ModulErstellenLink" Visible="false" Text="Ein neues Modul erstellen" OnClick="ModulErstellenLink_Click"></asp:LinkButton>
                        <br />
                        <asp:LinkButton runat="server" ID="ModuleBearbeitenLink" Visible="false" Text="Meine Module bearbeiten" OnClick="ModuleBearbeitenLink_Click"> </asp:LinkButton>
                        <br />
                        <asp:LinkButton runat="server" ID="ModuleKontrollierenLink" Visible="false" Text="Module kontrollieren" OnClick="ModuleKontrollierenLink_Click"></asp:LinkButton>
                    </div>
                    <div class="DefaultTreeview">
                        <asp:TreeView ID="ModulhandbookTreeView"
                            DataSourceID="ModulhandbookXmlDataSource"
                            ShowStartingNode="False"
                            runat="server"
                            OnTreeNodeExpanded="ModulhandbookTreeView_TreeNodeExpanded" ExpandDepth="0" Width="270px" OnSelectedNodeChanged="ModulhandbookTreeView_SelectedNodeChanged">
                            <DataBindings>
                                <asp:TreeNodeBinding DataMember="Semester" TextField="Heading" />
                                <asp:TreeNodeBinding DataMember="Modulhandbuch" TextField="Heading" ImageUrl="~/Images/PDF_Icon.png" />
                                <asp:TreeNodeBinding DataMember="Fach" TextField="Heading" ImageUrl="~/Images/PDF_Icon.png" />
                                <asp:TreeNodeBinding DataMember="Modul" TextField="Heading" ImageUrl="~/Images/PDF_Icon.png" />
                            </DataBindings>
                        </asp:TreeView>
                        <asp:XmlDataSource ID="ModulhandbookXmlDataSource"
                            DataFile="Modulhandbook.xml"
                            runat="server" XPath="/*/*"></asp:XmlDataSource>
                    </div>
                </div>
                <%-- searchbar --%>
                <div class="DefaultContainer-Right">
                    <div class="DefaultTable">
                        <asp:BulletedList runat="server" ID="searchResultList" DisplayMode="LinkButton" OnClick="searchResultList_Click" CssClass="list-style" Width="200px" />
                    </div>
                    <%-- Newsfeed --%>
                    <div class="DefaultNewsfeed">
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

