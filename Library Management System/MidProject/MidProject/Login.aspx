<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MidProject.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="right">
        <tr>
        <td>
            <asp:TextBox ID="SearchTB" runat="server"></asp:TextBox></td>
            <td>
                <asp:Button ID="SearchButton" runat="server" Text="Search" 
                    onclick="SearchButton_Click" /></td>
        </tr>
        <tr>
        <td colspan="2">
            <asp:HyperLink ID="HyperLink2" NavigateUrl="~/Search.aspx" runat="server">Click Here for Advanced Search</asp:HyperLink></td>
        </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
    <table align="center" cellspacing="25">
    <tr>
    <td colspan="2">
        <asp:Label ID="MsgLabel" runat="server" Text=""></asp:Label>
    </td>
    </tr>
    <tr>
    <td>
        <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label></td>
    <td>
        <asp:TextBox ID="UsernameTB" runat="server" Width="200px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="UsernameTB" ErrorMessage="* Value Requied" ForeColor="#CC0000"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
    <td>
        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label></td>
    <td>
        <asp:TextBox ID="PasswordTB" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="PasswordTB" ErrorMessage="* Password Required" 
            ForeColor="#CC0000"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
    <td colspan="2">
        <div>Click 
            <asp:HyperLink NavigateUrl="~/Registration.aspx" ID="HyperLink1" runat="server">Here</asp:HyperLink> to Get Registered</div>
    </td>
    </tr>
    <tr>
    <td></td>    
    <td >
        <asp:Button ID="LoginButton" runat="server" Text="LogIn" Width="200px" 
            onclick="LoginButton_Click" /></td>
    </tr>
    </table>
    
    </div>
    </form>
</body>
</html>
