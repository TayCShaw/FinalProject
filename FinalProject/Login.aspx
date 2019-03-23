<%@ Page Title="" Language="C#" MasterPageFile="~/AllPagesMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FinalProject.WebForm3" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100" style="margin:0 auto">
        <tr>
            <td style="text-align: right" class="loginTable" colspan="2">
                <asp:Label ID="lblErrorMessages" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right" class="loginTable">
                <asp:Label ID="lblUsername" runat="server" class="loginlbl" Text="Username"></asp:Label>
            </td>
            <td class="loginTable">
                <asp:TextBox ID="txtUsername" class="loginTb" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right" class="loginTable5">
                <asp:Label ID="lblPassword" runat="server" class="loginlbl" Text="Password" ></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPassword" class="loginTb" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="loginTable">&nbsp;</td>
            <td>
                <asp:Button ID="btnSubmit" class="loginBtn" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">

</asp:Content>

