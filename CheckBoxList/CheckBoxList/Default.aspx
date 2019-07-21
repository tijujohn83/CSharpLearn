<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="CheckBoxList._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script type="text/javascript">
<!--
        function isChecked() {
            var tableBody = document.getElementById('<%= CheckBoxList1.ClientID %>').childNodes[0];

            for (var i = 0; i < tableBody.childNodes.length; i++) {
                var currentTd = tableBody.childNodes[i].childNodes[0];
                var listControl = currentTd.childNodes[0];

                if (listControl.checked)
                    alert('Checked: ' + currentTd.childNodes[1].innerHTML);
            }
        }
// -->
    </script>
    <table>
        <tr>
            <td>
                <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                    <asp:ListItem Value="1">Item 1</asp:ListItem>
                    <asp:ListItem Value="2">Item 2</asp:ListItem>
                    <asp:ListItem Value="3">Item 3</asp:ListItem>
                </asp:CheckBoxList>
            </td>
        </tr>
    </table>
</asp:Content>
