<%@ Page Title="Kontakt" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="ModulManagementSystem.Contact" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>So erreichen Sie unseren Support.</h2>
    </hgroup>

    <div id="kontakt_panel" aria-atomic="False" style="padding: 12px; border-width: 5px; font-family: Arial, Helvetica, Sans-Serif; top: 0px; left: 0px; height: 210px; width: 72%;">
    <section class="contact">
        <header>
            <p>&nbsp;</p>
 
            <p style="color: #FFFFFF; font-size: medium;">Per Telefon: +49 731 123456</p>
            <p>&nbsp;</p>
        </header>
    </section>

    <section class="contact">
        <header>
            <p style="color: #FFFFFF; font-size: medium;">Per E-Mail: <span><a href="mailto:Klaus@Peter.com">support-mms@uni-ulm.com</a></span></p>
        </header>
        <p>
            &nbsp;</p>
    </section>

    <section class="contact">
        <header>
            <p style="color: #FFFFFF; font-size: medium;">Per Post: <br \ />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                Armer Hans der Zuständige<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                Universität Ulm<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                Eselsberg, Ulm
            </p>
        </header>
       
    </section>
        </div>
</asp:Content>