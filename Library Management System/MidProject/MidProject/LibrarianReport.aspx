<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LibrarianReport.aspx.cs" Inherits="MidProject.LibrarianReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Report</title>
    <link rel="stylesheet" type="text/css" href="MyStyle.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div class="menu3">
    <a href="LibrarianAddBook.aspx"><span>Add Book</span></a>
    <a href="LibrarianIssueBook.aspx"><span>Issue Book</span></a>
    <a href="LibrarianReport.aspx" class="current"><span>Report</span></a>
    <a href="Search.aspx"><span>Search Book</span></a>
    <a href="Logout.aspx"><span>Logout</span></a>
</div>
    <div>
    <table cellspacing="10">
    <tr>
    <td width="50"><br /><p><b>Books Borrowed on Selected Date</b><asp:Calendar ID="Calendar1" 
            runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" 
            DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
            ForeColor="#663399" Height="105px" ShowGridLines="True" Width="48px">
        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
        <OtherMonthDayStyle ForeColor="#CC9966" />
        <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
        <SelectorStyle BackColor="#FFCC66" />
        <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" 
            ForeColor="#FFFFCC" />
        <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
        </asp:Calendar>
        </p>
        <asp:Button ID="Button1" runat="server" Text="Show" onclick="Button1_Click" /></td>
        
    <td width="50"><br /><p><b>Books Returned on Selected Date</b><asp:Calendar ID="Calendar2" 
            runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" 
            DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
            ForeColor="#663399" Height="156px" ShowGridLines="True" Width="127px">
        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
        <OtherMonthDayStyle ForeColor="#CC9966" />
        <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
        <SelectorStyle BackColor="#FFCC66" />
        <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" 
            ForeColor="#FFFFCC" />
        <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
        </asp:Calendar>
    </p>
        <asp:Button ID="Button2" runat="server" Text="Show" onclick="Button2_Click" /></td>
    <td width="100"><p><b>Books Borrowed This Week</b></p>
        <asp:Button ID="Button3" runat="server" Text="Show" onclick="Button3_Click" /></td>
    <td width="100"><p><b>Total Due Fine</b></p>
        <asp:Button ID="Button7" runat="server" Text="Show" onclick="Button7_Click" /></td>
    <td width="100"><p><b>Popular Books Borrowed</b></p>
        <asp:Button ID="Button5" runat="server" Text="Show" onclick="Button5_Click" /></td>
    <td width="100"><p><b>No of Books Which Are Outside the Library for Each Category</b></p>
        <asp:Button ID="Button4" runat="server" Text="Show" onclick="Button4_Click" /></td>
    <td width="300"><p><b>Books Borrowed by a Specific Student/Faculty Between Two Given Dates</b></p>
        <asp:DropDownList ID="MemberIDDDL" runat="server" 
            DataSourceID="SqlDataSource1" DataTextField="member_id" 
            DataValueField="member_id">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DBCS %>" 
            SelectCommand="SELECT [member_id] FROM [Members] ORDER BY [member_id]">
        </asp:SqlDataSource><br />
        <asp:TextBox ID="FromDateTB" runat="server"></asp:TextBox>&nbsp;
        <asp:Label ID="Label1" runat="server" Text="From"></asp:Label>
        <br />
        <asp:TextBox ID="ToDateTB"
            runat="server" Width="128px"></asp:TextBox>&nbsp;
        <asp:Label ID="Label2" runat="server" Text="To"></asp:Label>
        <br /><br />
        <asp:Button ID="Button6" runat="server" Text="Show" onclick="Button6_Click" />
    </td>
    </tr>
    <tr>
    <td colspan="5"><br /><br /><br />
            <asp:GridView ID="ReportGridView" runat="server" BackColor="#DEBA84" 
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
