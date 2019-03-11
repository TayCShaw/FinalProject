<%@ Page Title="" Language="C#" MasterPageFile="~/AllPagesMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="FinalProject.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <style type="text/css">
        .auto-style4 {
            width: 298px;
        }
        .auto-style5 {
            width: 100%;
            height: 64px;
        }
        .auto-style6 {
            width: 298px;
            height: 32px;
        }
        .auto-style7 {
            height: 32px;
        }
        .auto-style8 {
            height: 32px;
            width: 400px;
        }
        .auto-style9 {
            width: 400px;
        }
        .auto-style10 {
            height: 214px;
        }
    </style>



</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <div>
        <asp:Table ID="Table1" runat="server" Width="100%">
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableHeaderCell 
                    Scope="Column" 
                    BackColor="#6a0032"
                    Text="Forum"
                    ForeColor="#FFC82E">
                </asp:TableHeaderCell>
                <asp:TableHeaderCell 
                    Scope="Column" 
                    BackColor="#6a0032"
                    Text="Topics"
                    ForeColor="#FFC82E">
                </asp:TableHeaderCell>
                <asp:TableHeaderCell
                    Scope="Column"
                    BackColor="#6a0032"
                    Text="Topics"
                    ForeColor="#FFC82E">
                </asp:TableHeaderCell>
                <asp:TableHeaderCell
                    Scope="Column"
                    BackColor="#6a0032"
                    Text="Last Post"
                    ForeColor="#FFC82E">
                </asp:TableHeaderCell>
            </asp:TableRow>
            <%--So the actual C# code will have to handle adding more rows to the table.
                Not sure of the exact logic, or storage device.--%>
    </asp:Table>
    </div>
    
    <div>
        <table>
            <%--FAQ/Stickied Posts??  --%>
        </table>
    </div>
    
</asp:Content>

