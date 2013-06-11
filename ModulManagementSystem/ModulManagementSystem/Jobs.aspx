<%@ Page Title="Jobs" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Jobs.aspx.cs" Inherits="ModulManagementSystem.Jobs" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Verwalten Sie Ihre Aufgaben.</h2>
    </hgroup>
    <section id="jobForm">

        <div id="job_Panel">
            <asp:BulletedList ID="jobListJob" runat="server" DisplayMode="LinkButton" OnClick="jobListJob_Click" CssClass="list-style"></asp:BulletedList>
        </div>


    </section>
</asp:Content>
