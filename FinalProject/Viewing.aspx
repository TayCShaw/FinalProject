﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AllPagesMaster.Master" AutoEventWireup="true" CodeBehind="Viewing.aspx.cs" Inherits="FinalProject.Viewing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="Content/Site.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    <asp:Label ID="lblErrorMessages" runat="server"></asp:Label>
    <br />
    <asp:Label ID="lblThreadName" runat="server" style="display: block; text-align: center;" Font-Bold="True" Font-Italic="True" Font-Size="XX-Large" ForeColor="Black"></asp:Label>
    <br />
    <%--<asp:Button ID="btnReply" runat="server" OnClick="btnReply_Click" Text="Reply" /> --%>
</asp:Content>
