<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrainerDashbord.aspx.cs" Inherits="ADONETWebApp.TrainerDashbord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>All Trainers</h2>

            <asp:GridView ID="gvTrainers" runat="server"></asp:GridView>
            <asp:Label ID="lbMasaage" runat="server" ForeColor="red" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
