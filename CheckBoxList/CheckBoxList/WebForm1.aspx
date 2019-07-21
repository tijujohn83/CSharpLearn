<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CheckBoxList.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Test</title>
    <script type="text/javascript">

        function GetSelectedItem() {

            var CHK = document.getElementById("<%=CheckBoxList1.ClientID%>");

            var checkbox = CHK.getElementsByTagName("input");

            var label = CHK.getElementsByTagName("label");

            for (var i = 0; i < checkbox.length; i++) {

                if (checkbox[i].checked) {

                    alert("Selected = " + label[i].innerHTML);

                }

            }

            return false;

        }


    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:CheckBoxList ID="CheckBoxList1" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged" runat="server" AutoPostBack="True">
            <asp:ListItem Value="1">Item 1</asp:ListItem>
            <asp:ListItem Value="2">Item 2</asp:ListItem>
            <asp:ListItem Value="3">Item 3</asp:ListItem>
        </asp:CheckBoxList>
    </div>
    </form>
</body>
</html>
