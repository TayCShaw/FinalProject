<%@ Page Title="" Language="C#" MasterPageFile="~/AllPagesMaster.Master" AutoEventWireup="true" CodeBehind="Posting.aspx.cs" Inherits="FinalProject.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 77px;
        }
        .auto-style5 {
            height: 26px;
        }
        .auto-style6 {
            width: 939px;
            height: 113px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100">
        <tr>
            <td>
                <asp:Label ID="lblThreadname" runat="server" Text="[THREAD/TOPIC NAME]"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table class="w-100">
                    <tr>
                        <td class="auto-style4">
                            <asp:Label ID="lblSubject" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSubject" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                <textarea id="txtareaMessage" class="auto-style6" name="S1"></textarea></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
                <asp:Button ID="btnSaveDraft" runat="server" Text="Save Draft" />
            </td>
        </tr>
    </table>
</asp:Content>
