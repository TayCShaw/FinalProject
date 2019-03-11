<%@ Page Title="SIGNUP" Language="C#" MasterPageFile="~/AllPagesMaster.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="FinalProject.WebForm2" %>


<%--Shift more to the middle area. Don't have it left justified.
    
    CODING TODO:
    ++Compare validation on Email and Confirm email boxes
    ++Compare validation on Password and Confirm password boxes
    --++Validation on Password length
    ++(POSSIBLY EMAIL, WE COULD REMOVE IT AND JUST HAVE USERNAME/PASSWORD) Validate that email is in the correct form

    ++Check to see if username is already taken (THAT HAS TO BE DONE ON C# PAGE, USING SQL COMPARING TO TABLE
    --%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="w-100">
        <tr>
            <td class="auto-style4">Username:</td>
            <td class="auto-style5">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">E-mail address:</td>
            <td class="auto-style5">
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">Confirm e-mail address:</td>
            <td class="auto-style5">
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">Password:</td>
            <td class="auto-style5">
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">(Password must be between 6 and 16 characters long)</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">Confirm password:</td>
            <td class="auto-style5">
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style4 {
            width: 346px;
        }
        .auto-style5 {
            width: 441px;
        }
    </style>
</asp:Content>

