<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Webshop.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="Stijlen/css/background.css" rel="stylesheet" />
<link href="Stijlen/css/bootstrap.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Nosifer" rel="stylesheet"/> 
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container-fluid">
                <div class="jumbotron" style ="border:1px solid #888; box-shadow:0px 2px 5px #ccc; color:#28a745; font-size:28px; font-family: 'Nosifer', cursive; width:100%;">
                     <span ><em><strong>Online GPU-shop</strong></em></span> - <strong><em>Login</em> </strong><br />
                     <br />
                </div>

            </div>
            <br />
            <table class="auto-style1">
                <tr>
                    <td>Gebruikersnaam:</td>
                    <td>
                        <asp:TextBox ID="txtbGebrNaam" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvGebrNaam" runat="server" ControlToValidate="txtbGebrNaam" ErrorMessage="Gebruikersnaam is verplicht!" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Wachtwoord:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtbWachtwoord" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <asp:RequiredFieldValidator ID="rfvWw" runat="server" ControlToValidate="txtbWachtwoord" ErrorMessage="Wachtwoord is verplicht!" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" Font-Bold="True" ForeColor="Red" />
                        <br />
                        <asp:Button ID="btnAanmelden" runat="server" Text="Aanmelden" OnCLick="btnAanmelden_Click"/>
                    </td>
                </tr>
            </table>
            <asp:Label ID="lblFout" runat="server"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
