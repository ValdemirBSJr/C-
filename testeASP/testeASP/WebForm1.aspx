<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="testeASP.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Hello Word - Olá mundo!" Font-Size="32pt"></asp:Label>
        <asp:Button ID="btnBotao" runat="server" Text ="Olha o botão aí" OnClick="btnBotao_Click" />

    </div>
    </form>
</body>
</html>
