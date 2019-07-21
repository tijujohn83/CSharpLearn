<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="bday.aspx.vb" Inherits="Prachi_Proj1.bday" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Enter birthdate (MM/dd/yyyy):
    <asp:textbox runat="server" id="txtBday">
</asp:textbox>

        <asp:Button ID="btnClick" runat="server" Text="Click" />
    </div>
    </form>
</body>
</html>
