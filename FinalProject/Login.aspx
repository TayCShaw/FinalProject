<%@ Page Title="" Language="C#" MasterPageFile="~/AllPagesMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FinalProject.WebForm3" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100" style="margin:0 auto">
        <tr>
            <td style="text-align: right" class="auto-style6" colspan="2">
                <asp:Label ID="lblErrorMessages" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right" class="auto-style6">
                <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label>
            </td>
            <td class="auto-style7">
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right" class="auto-style5">
                <asp:Label ID="lblPassword" runat="server" Text="Password" ></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style5 {
            width: 500px;
        }
        .auto-style6 {
            height: 29px;
        }
        .auto-style7 {
            height: 29px;
        }
    </style>
</asp:Content>

