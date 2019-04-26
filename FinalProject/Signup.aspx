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
            <td class="loginTable" style="text-align: right"> 
                <asp:Label ID="lblUsername" runat="server" class="signuplbl" Text="Username"></asp:Label>
            </td>
            <td class="loginTable">
                <asp:TextBox ID="txtUsername" runat="server" AutoPostBack="True" class="loginTb" OnTextChanged="txtUsername_TextChanged"></asp:TextBox>
                <asp:Label ID="lblUsernameError" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="loginTable" style="text-align: right">
                <asp:Label ID="lblPassword" runat="server" class="signuplbl" Text="Password"></asp:Label>
            </td>
            <td class="loginTable">
                <asp:TextBox ID="txtPassword" runat="server" class="loginTb" TextMode="Password"></asp:TextBox>
                <asp:CompareValidator ID="validPasswords" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ErrorMessage="Passwords do not match!"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="loginTable" style="text-align: right">
                <asp:Label ID="lblConfirmPassword" runat="server" class="signuplbl" Text="Confirm Password"></asp:Label>
            </td>
            <td class="loginTable">
                <asp:TextBox ID="txtConfirmPassword" runat="server" class="loginTb" TextMode="Password"></asp:TextBox>
                <asp:Label ID="lblPasswordError" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="loginTable">&nbsp;</td>
            <td class="loginTable">
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" Class="loginBtn" CausesValidation="False" />
            </td>
        </tr>
        <tr>
            <td class="loginTable">
                <asp:Label ID="lblErrorMessages" runat="server"></asp:Label>
            </td>
            <td class="loginTable">&nbsp;</td>
        </tr>
        <tr>
            <td class="loginTable">&nbsp;</td>
            <td class="loginTable">
                &nbsp;</td>
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
        .auto-style6 {
            width: 346px;
            height: 29px;
        }
        .auto-style7 {
            width: 441px;
            height: 29px;
        }
        </style>
</asp:Content>

