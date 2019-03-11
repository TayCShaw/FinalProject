<%@ Page Title="PLACEHOLDER" Language="C#" MasterPageFile="~/AllPagesMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="FinalProject.WebForm1" %>

<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <div class="div-table">
        <asp:Table ID="Table1" runat="server" Width="100%" Height="43px" GridLines="Both">
            <asp:TableHeaderRow HorizontalAlign="Center">
                <asp:TableHeaderCell Text="Forum" 
                    Scope="Column" 
                    BackColor="#6a0032"
                    ForeColor="#FFC82E"/>
                <asp:TableHeaderCell Text="Topics"
                    Scope="Column" 
                    BackColor="#6a0032"                   
                    ForeColor="#FFC82E"/>
                <asp:TableHeaderCell Text="Posts"
                    Scope="Column"
                    BackColor="#6a0032"
                    ForeColor="#FFC82E"/>
                <asp:TableHeaderCell Text="Last Post"
                    Scope="Column"
                    BackColor="#6a0032"
                    ForeColor="#FFC82E"/>
            </asp:TableHeaderRow>
            <%--So the actual C# code will have to handle adding more rows to the table.
                Not sure of the exact logic, or storage device.--%>
            <asp:TableRow>
                <asp:TableCell Text="forumTest" />
                <asp:TableCell Text="topicsTest" />
                <asp:TableCell Text="postsTest" />
                <asp:TableCell Text="lastpostTest" />
            </asp:TableRow>
    </asp:Table>
    </div>
    
    <div>
        <table>
            <%--FAQ/Stickied Posts??  --%>
        </table>
    </div>
    
</asp:Content>

