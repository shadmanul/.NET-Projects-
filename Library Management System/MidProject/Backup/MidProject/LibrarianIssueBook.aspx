<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LibrarianIssueBook.aspx.cs" Inherits="MidProject.LibrarianIssueBook" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Issue Books</title>
    <link rel="stylesheet" type="text/css" href="MyStyle.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div class="menu3">
    <a href="LibrarianAddBook.aspx"><span>Add Book</span></a>
    <a href="LibrarianIssueBook.aspx" class="current"><span>Issue Book</span></a>
    <a href="LibrarianReport.aspx"><span>Report</span></a>
    <a href="Search.aspx"><span>Search Book</span></a>
    <a href="Logout.aspx"><span>Logout</span></a>
</div>
    <div>
    <br />
    <br />
        <br />
        <table>
        <tr><td colspan="2">
            <asp:Label ID="Msglabel" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label><br /><br /></td>
         <td>
        <asp:Button ID="SaveDatabaseButton" runat="server" 
            onclick="SaveDatabaseButton_Click" Text="Save Data" />
        </td>
        <td>
        <asp:Button ID="ClearCacheButton" runat="server" 
            onclick="ClearCacheButton_Click" Text="Clear Cache" />
        </td>    
        </tr>
        <tr>
        <td>
            <asp:Label ID="BookIDButton" runat="server" Text="Book Title"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="BookIDDDL" runat="server" DataSourceID="SqlDataSource1" 
                DataTextField="book_title" DataValueField="book_id">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:DBCS %>" 
                SelectCommand="SELECT [book_id], [book_title] FROM [Books]">
            </asp:SqlDataSource>
        </td>
        <td colspan="3" rowspan="100">
        <asp:GridView ID="BooksOutOnLoanGridView" runat="server" 
            AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" 
            BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" 
            DataKeyNames="book_borrowing_id" 
            onrowcancelingedit="BooksOutOnLoanGridView_RowCancelingEdit" 
            onrowdeleting="BooksOutOnLoanGridView_RowDeleting" 
            onrowediting="BooksOutOnLoanGridView_RowEditing" 
            onrowupdating="BooksOutOnLoanGridView_RowUpdating">
            <Columns>
                <asp:BoundField DataField="book_id" HeaderText="Book ID" ReadOnly="True" />
                <asp:BoundField DataField="member_id" HeaderText="Member ID" ReadOnly="True" />
                <asp:BoundField DataField="date_issued" HeaderText="Date Issued" 
                    ReadOnly="True" />
                <asp:TemplateField HeaderText="Date Returned">
                    <EditItemTemplate>
                        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
                            BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" 
                            Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" 
                            Width="200px">
                            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                            <NextPrevStyle VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#808080" />
                            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                            <SelectorStyle BackColor="#CCCCCC" />
                            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <WeekendDayStyle BackColor="#FFFFCC" />
                        </asp:Calendar>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("date_returned") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="total_fine" HeaderText="Total Fine" 
                    ReadOnly="True" />
                <asp:TemplateField HeaderText="Paid">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("paid") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" 
                    ShowEditButton="True" />
            </Columns>
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
        <td>
            <asp:Label ID="Label1" runat="server" Text="Member ID"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="MemberIDDDL" runat="server" DataSourceID="SqlDataSource2" 
                DataTextField="member_id" DataValueField="member_id">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:DBCS %>" 
                SelectCommand="SELECT [member_id] FROM [Members] ORDER BY [member_id]">
            </asp:SqlDataSource><br />
            <asp:TextBox ID="MemberIDTB" runat="server"></asp:TextBox>
        </td>
        <td>
            
        </td>
        </tr>

        <tr>
        <td>
            <asp:Label ID="DateIssued" runat="server" Text="Date Issued"></asp:Label>
        </td>
        <td>
            <asp:Calendar ID="IssueCalendar" runat="server" BackColor="#FFFFCC" 
                BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" 
                Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" 
                ShowGridLines="True" Width="220px">
                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                <OtherMonthDayStyle ForeColor="#CC9966" />
                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                <SelectorStyle BackColor="#FFCC66" />
                <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" 
                    ForeColor="#FFFFCC" />
                <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
            </asp:Calendar>
        </td>
        <td>
        </td>
        </tr>

        <tr>
        <td>
        </td>
        <td>
            <asp:Button ID="AddIssueButton" runat="server" Text="Add New Issued Book" 
                onclick="AddIssueButton_Click" />
        </td>
        <td>
        </td>
        </tr>





    

        
        </table>
        
        
    
    </div>
    </form>
</body>
</html>
