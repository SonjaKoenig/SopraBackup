<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="ModulManagementSystem.About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent" >
    <hgroup class="title">
        <h1 style="color: #3e5667"><%: Title %>.</h1>
        <h2 style="color: #999">Hier kommen noch ein paar Informationen über das MMS hin.</h2>
    </hgroup>
   
    <div ID="info_panel" style="padding: 12px; border-width: 5px; font-family: Arial, Helvetica, Sans-Serif; color: #FFFFFF; top: -2px; left: 12px; height: 275px; width: 45%">
        <p style ="padding: 12px; color: #FFFFFF; font-size: 50px; font-family: Dotum; letter-spacing: -3pt; text-align: center;"> MMS 2013 </p>
        <p style="font-size: medium; line-height: 150%; padding-top: 12px; padding-right: 12px; padding-left: 12px;">Schnell. Simpel. Übersichtlich. </p>
        <p style="padding: 12px; font-size: medium; line-height: 150%; ">Mit der nächsten Generation von Tools bequem zur&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Modul-Erstellung, -Änderung und zur gesamten Modulverwaltung.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Begeistern Sie nicht nur Ihre Mitarbeiter sondern auch die Nutzer.</p>
    </div>

    <div id="info_panel_image" style="padding: 12px; top: -10px; height: 281px; width: 39%">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/UniLogo.gif" Height="272px"/>
    </div>
</asp:Content>
