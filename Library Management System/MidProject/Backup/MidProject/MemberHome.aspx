<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberHome.aspx.cs" Inherits="MidProject.MemberHome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Member's Home</title>
    <link rel="stylesheet" type="text/css" href="MyStyle.css"/>
</head>
<body>
<form id="form1" runat="server">
<div class="menu3">
    <a href="MemberHome.aspx" class="current"><span>Home</span></a>
    <a href="Search.aspx"><span>Search Book</span></a>
    <a href="Logout.aspx"><span>Logout</span></a>
</div>
<br />
<br />
<br />
<br />
    
    <div>
        <asp:Label ID="BorrowedMsgLabel" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <asp:GridView ID="BorrowedBooksGridView" runat="server" BackColor="#DEBA84" 
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
    </div>
    <br />
    <br />
    <div>
     <table align="left">
        <tr>
        <td colspan="2">
            <asp:HyperLink ID="HyperLink2" NavigateUrl="~/Search.aspx" runat="server">Click Here for Advanced Search</asp:HyperLink></td>
        </tr>
        </table>
    </div>
    <br />
    <br />
    <div>
        <div>All The Book's Names Are Given Below.<br />Ask The Librarian to Issue Book for You If You Want to Borrow.</div>
        <br />
        <br />
        <asp:GridView ID="AllBooksGridView" runat="server" BackColor="#DEBA84" 
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
    </div>
    </form>
    </body>
</html>
