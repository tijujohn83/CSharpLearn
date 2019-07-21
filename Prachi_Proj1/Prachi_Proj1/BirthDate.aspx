<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BirthDate.aspx.vb" Inherits="Prachi_Proj1.BirthDate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Enter Birthdate (MM/dd/yyy)
        <asp:TextBox ID="txtBirthdate" runat="server"></asp:TextBox>
        <asp:Button ID="btnOutput" runat="server" Text="Output" />
        <br />
        <br />
        hi hello, plz enter your birthdate (dd/MM/yyyy)
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="Button1" runat="server" Text="click" />
    </div>
    </form>
</body>
</html>
