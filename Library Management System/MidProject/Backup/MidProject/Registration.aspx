<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="MidProject.Registration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="center" cellspacing="25">
        <tr>
        <td colspan="2">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                BorderStyle="Ridge" ForeColor="#CC0000" />
        </td>
        </tr>
        <tr>
        <td colspan="2">
            <asp:Label ID="labelMsg" runat="server" ForeColor="#CC0000"></asp:Label>
        </td>
        </tr>
        <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Member ID"></asp:Label></td>
        <td>
            <asp:TextBox ID="MemberidTB" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="Value Required" ControlToValidate="MemberidTB" 
                Display="Dynamic" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
        <td>
            <asp:Label ID="Label11" runat="server" Text="Status"></asp:Label></td>
        <td>
            <asp:DropDownList ID="StatusDDL" runat="server">
                <asp:ListItem>Faculty</asp:ListItem>
                <asp:ListItem>Student</asp:ListItem>
                <asp:ListItem>Librarian</asp:ListItem>
            </asp:DropDownList>
        </tr>
        <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label></td>
        <td>
            <asp:TextBox ID="PasswordTB" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ErrorMessage="Value Required" ControlToValidate="PasswordTB" 
                Display="Dynamic" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
        <td>
            <asp:Label ID="Label3" runat="server" Text="Re-Password"></asp:Label></td>
        <td>
            <asp:TextBox ID="RepasswordTB" runat="server" TextMode="Password"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                ControlToCompare="PasswordTB" ControlToValidate="RepasswordTB" 
                Display="Dynamic" ErrorMessage="Password Didn't match" ForeColor="#CC0000">*</asp:CompareValidator>
            </td>
        </tr>
        <tr>
        <td>
            <asp:Label ID="Label4" runat="server" Text="First Name"></asp:Label></td>
        <td>
            <asp:TextBox ID="FirstnameTB" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ErrorMessage="Value Required" ControlToValidate="FirstnameTB" 
                Display="Dynamic" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
        <td>
            <asp:Label ID="Label5" runat="server" Text="Middle Name"></asp:Label></td>
        <td>
            <asp:TextBox ID="MiddlenameTB" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
        <td>
            <asp:Label ID="Label6" runat="server" Text="Last Name"></asp:Label></td>
        <td>
            <asp:TextBox ID="LastnameTB" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                ErrorMessage="Value Required" ControlToValidate="LastnameTB" 
                Display="Dynamic" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
        <td>
            <asp:Label ID="Label7" runat="server" Text="Gender"></asp:Label></td>
        <td>
            <asp:DropDownList ID="GenderDDL" runat="server">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:DropDownList>
        </td>
        </tr>
        <tr>
        <td>
            <asp:Label ID="Label8" runat="server" Text="Address"></asp:Label></td>
        <td>
            <asp:TextBox ID="AddressTB" runat="server" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                ErrorMessage="Value Required" ControlToValidate="AddressTB" 
                Display="Dynamic" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
        <td>
            <asp:Label ID="Label9" runat="server" Text="Phone No"></asp:Label></td>
        <td>
            <asp:TextBox ID="PhoneTB" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                ErrorMessage="Value Required" ControlToValidate="PhoneTB" 
                Display="Dynamic" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
        <td>
            <asp:Label ID="Label10" runat="server" Text="Email"></asp:Label></td>
        <td>
            <asp:TextBox ID="EmailTB" runat="server" TextMode="Email"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="EmailTB" Display="Dynamic" 
                ErrorMessage="Invalid Mail Address" ForeColor="#CC0000" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                ErrorMessage="Value Required" ControlToValidate="EmailTB" 
                Display="Dynamic" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
        <td><td>
            <asp:Button ID="RegButton" runat="server" Text="Register" 
                onclick="RegButton_Click" /></td>
        </tr>
        </table>
    </div>
    </form>
</body>
</html>
