<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LibrarianAddBook.aspx.cs" Inherits="MidProject.LibrarianHome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Books</title>
    <link rel="stylesheet" type="text/css" href="MyStyle.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div class="menu3">
    <a href="LibrarianAddBook.aspx" class="current"><span>Add Book</span></a>
    <a href="LibrarianIssueBook.aspx"><span>Issue Book</span></a>
    <a href="LibrarianReport.aspx"><span>Report</span></a>
    <a href="Search.aspx"><span>Search Book</span></a>
    <a href="Logout.aspx"><span>Logout</span></a>
</div>
    <div>
    <br />
    <br />
    <br />
    <br />
    <table align="center">
    <tr>
    <td colspan="2" align="center">
        <asp:Label ID="Label6" runat="server" Text="Add Book to Book Table"></asp:Label>
    </td>
    </tr>
    <tr>
    <td align="right">
        <asp:Label ID="Label1" runat="server" Text="Category Name"></asp:Label>    
    </td>
    <td align="left">
        <asp:TextBox ID="CategoryTB" runat="server" ValidationGroup="BookValidation"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="CategoryTB" ErrorMessage="* Value Requied" 
            ForeColor="#CC0000" ValidationGroup="BookValidation"></asp:RequiredFieldValidator>
    </td>
    </tr>
    <tr>
    <td align="right">
        <asp:Label ID="Label2" runat="server" Text="No of Copies"></asp:Label>    
    </td>
    <td align="left">
        <asp:TextBox ID="NoOfCopiesTB" runat="server" ValidationGroup="BookValidation"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="NoOfCopiesTB" ErrorMessage="* Value Requied" 
            ForeColor="#CC0000" ValidationGroup="BookValidation" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator1" runat="server" 
            ControlToValidate="NoOfCopiesTB" Display="Dynamic" 
            ErrorMessage="* Numaric Value Only" ForeColor="#CC0000" MaximumValue="20000" 
            MinimumValue="0" Type="Integer" ValidationGroup="BookValidation"></asp:RangeValidator>
    </td>
    </tr>
    <tr>
    <td align="right">
        <asp:Label ID="Label3" runat="server" Text="Book Title"></asp:Label>  
    </td>
    <td align="left">
        <asp:TextBox ID="BookTitleTB" runat="server" ValidationGroup="BookValidation"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ControlToValidate="BookTitleTB" ErrorMessage="* Value Requied" 
            ForeColor="#CC0000" ValidationGroup="BookValidation"></asp:RequiredFieldValidator>
    </td>
    </tr>
    <tr>
    <td align="right">
        <asp:Label ID="Label4" runat="server" Text="Book Edition"></asp:Label>  
    </td>
    <td align="left">
        <asp:TextBox ID="BookEditionTB" runat="server" ValidationGroup="BookValidation"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
            ControlToValidate="BookEditionTB" ErrorMessage="* Value Requied" 
            ForeColor="#CC0000" ValidationGroup="BookValidation"></asp:RequiredFieldValidator>
    </td>
    </tr>
    <tr>
    <td></td>
    <td align="left">
        <asp:Button ID="AddBookButton" runat="server" Text="Add Book" 
            onclick="AddBookButton_Click" ValidationGroup="BookValidation" />
    </td>
    </tr>
    <tr>
    <td colspan="2" align="center">
        <asp:Label ID="Label7" runat="server" Text="<br /><br />Add Author to Book Table"></asp:Label>
    </td>
    </tr>
    <tr>
    <td align="right">
        <asp:Label ID="Label5" runat="server" Text="Author Name"></asp:Label>
    </td>
    <td align="left">
        <asp:TextBox ID="AuthorTB" runat="server" ValidationGroup="AuthorValidation"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
            ControlToValidate="AuthorTB" ErrorMessage="* Value Requied" 
            ForeColor="#CC0000" ValidationGroup="AuthorValidation"></asp:RequiredFieldValidator>
    </td>
    </tr>
    <tr>
    <td></td>
    <td align="left">
        <asp:Button ID="AddAuthorButton" runat="server" Text="Add Author" 
            onclick="AddAuthorButton_Click" ValidationGroup="AuthorValidation" />
    </td>
    </tr>
    <tr>
    <td colspan="2" align="center">
        <asp:Label ID="Label8" runat="server" Text="<br /><br />Relate Author With Their Book Using Their ID"></asp:Label>
    </td>
    </tr>
    <tr>
    <td align="right">
        <asp:Label ID="Label10" runat="server" Text="Book ID"></asp:Label>
    </td>
    <td align="left">
        <asp:DropDownList ID="BookIdDDl" runat="server" DataSourceID="SqlDataSource1" 
            DataTextField="book_title" DataValueField="book_id">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DBCS %>" 
            SelectCommand="SELECT [book_id], [book_title] FROM [Books] ORDER BY [book_title]">
        </asp:SqlDataSource>
    </td>
    </tr>
    <tr>
    <td align="right">
        <asp:Label ID="Label9" runat="server" Text="Author ID"></asp:Label>
    </td>
    <td align="left">
        <asp:DropDownList ID="AuthorIdDDl" runat="server" DataSourceID="SqlDataSource2" 
            DataTextField="name" DataValueField="author_id">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DBCS %>" 
            SelectCommand="SELECT [author_id], [name] FROM [Authors] ORDER BY [name]">
        </asp:SqlDataSource>
    </td>
    </tr>
    <tr>
    <td></td>
    <td>
        <asp:Button ID="RelateButton" runat="server" Text="Relate Books & Author" 
            onclick="RelateButton_Click" ValidationGroup="BookAuthorValidation" />
    </td>
    </tr>
    <tr>
    <td>
    <br />
    <br />
        <asp:GridView ID="AuthorGridView" runat="server" BackColor="#DEBA84" 
            BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            CellSpacing="2">
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
        </asp:GridView>
    </td>
    <td>
    <br />
    <br />
        <asp:GridView ID="BookAuthorGridView" runat="server" BackColor="#DEBA84" 
            BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            CellSpacing="2">
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
        </asp:GridView>
    </td>
    </tr>
    <tr>
    <td colspan="2">
    <br />
        <asp:GridView ID="BookGridView" runat="server" BackColor="#DEBA84" 
            BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            CellSpacing="2">
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
        </asp:GridView>
    </td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
