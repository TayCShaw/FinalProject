<%@ Page Title="PLACEHOLDER" Language="C#" MasterPageFile="~/AllPagesMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="FinalProject.WebForm1" %>

<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <div class="div-table">
        <asp:Table ID="tblStatic" runat="server" Width="100%" Height="43px" GridLines="Both">
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
    
    <asp:Label ID="lblTest" runat="server"></asp:Label>
    <br />
    <asp:GridView ID="GridView1" Class="div-table" BorderWidth="2px" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Width="492px">
        <Columns>
            <asp:HyperLinkField DataTextField="Subject" 
                DataNavigateUrlFields="threadID"
                DataNavigateUrlFormatString= "~\Viewing.aspx?threadID={0}"
                HeaderText="Subject" 
                SortExpression="Subject" />
            <asp:BoundField DataField="Replies" HeaderText="Replies" SortExpression="Replies" />
            <asp:BoundField DataField="Views" HeaderText="Views" SortExpression="Views" />
            <asp:BoundField DataField="Creator" HeaderText="Creator" SortExpression="Creator" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:UserConnectionString %>" SelectCommand="SELECT Threads.threadSubject AS Subject, Threads.threadReplies AS Replies, Threads.threadViews AS Views, Threads.threadID, Users.userName AS Creator FROM Threads INNER JOIN Users ON Threads.userID = Users.userID"></asp:SqlDataSource>
    
    <asp:Button ID="btnNewThread" runat="server" OnClick="btnNewThread_Click" Text="New Thread" />
    
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
</asp:Content>


