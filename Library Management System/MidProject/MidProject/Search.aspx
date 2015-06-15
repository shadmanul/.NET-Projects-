<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="MidProject.Search" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Search Books</title>
    <link rel="stylesheet" type="text/css" href="MyStyle.css"/>
</head>
<body>
    <%if (Session["status"] != null)
      {
          if (!Session["status"].ToString().Equals("Librarian"))
          {%>
        <div class="menu3">
        <a href="MemberHome.aspx"><span>Home</span></a>
        <a href="Search.aspx" class="current"><span>Search Book</span></a>
        <a href="Logout.aspx"><span>Logout</span></a>
        </div>
       <%   
}
          else
          {%>
          <div class="menu3">
    <a href="LibrarianAddBook.aspx"><span>Add Book</span></a>
    <a href="LibrarianIssueBook.aspx"><span>Issue Book</span></a>
    <a href="LibrarianReport.aspx"><span>Report</span></a>
    <a href="Search.aspx" class="current"><span>Search Book</span></a>
    <a href="Logout.aspx"><span>Logout</span></a>
</div><%}
      }%>
    <form id="form1" runat="server">
    <div>
        <table align="left" cellspacing="25">
        <tr>
        <td>
            <asp:DropDownList ID="CategoryDDL" runat="server" DataSourceID="SqlDataSource1" 
                DataTextField="category_name" DataValueField="category_name">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:DBCS %>" 
                SelectCommand="SELECT DISTINCT [category_name] FROM [Books]">
            </asp:SqlDataSource>
        </td>
            <td>
                <asp:Button ID="CategoryButton" runat="server" Text="Search by Category" 
                    onclick="CategoryButton_Click" Width="200px" /></td>
        </tr>
        <tr>
        <td>
            <asp:TextBox ID="NameTB" runat="server"></asp:TextBox></td>
            <td>
                <asp:Button ID="NameButton" runat="server" Text="Search by Name" 
                    onclick="NameButton_Click" Width="200px" /></td>
        </tr>
        <tr>
        <td>
            <asp:TextBox ID="AuthorTB" runat="server"></asp:TextBox></td>
            <td>
                <asp:Button ID="AuthorButton" runat="server" Text="Search by Author" 
                    onclick="AuthorButton_Click" Width="200px" /></td>
        </tr>
        <tr>
        <td>
            <asp:DropDownList ID="MemberIDDDL" runat="server" DataSourceID="SqlDataSource2" 
                DataTextField="member_id" DataValueField="member_id">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:DBCS %>" 
                SelectCommand="SELECT [member_id] FROM [Members] ORDER BY [member_id]">
            </asp:SqlDataSource>
        </td>
            <td>
                <asp:Button ID="MemberButton" runat="server" Text="Search by Member ID" 
                    onclick="MemberButton_Click" Width="200px" /></td>
        </tr>
        </table>
    </div>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
        <p>
        &nbsp;</p>
        <table align="left" cellspacing="25"><tr><td>
            <asp:GridView ID="GridView1" 
                runat="server" CellPadding="3" BackColor="#DEBA84" BorderColor="#DEBA84" 
        BorderStyle="None" BorderWidth="1px" CellSpacing="2">
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FFF1D4" />
        <SortedAscendingHeaderStyle BackColor="#B95C30" />
        <SortedDescendingCellStyle BackColor="#F1E5CE" />
        <SortedDescendingHeaderStyle BackColor="#93451F" />
    </asp:GridView></td></tr></table>
    
    </form>
</body>
</html>
