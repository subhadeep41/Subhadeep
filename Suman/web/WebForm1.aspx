<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="web.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h4>Select a file to upload:</h4>
            <asp:FileUpload ID="FileUpload1" runat="server"></asp:FileUpload>
            <br />
            <br />
            <asp:Button ID="ShowButton" Text="Show output" OnClick="ShowButton_Click" runat="server"></asp:Button>

            <asp:Label ID="Label1" style="display:none" runat="server" Text="Label"></asp:Label>

        </div>
        <div id="gridid">
            <asp:GridView ID="grdViewCustomers" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
