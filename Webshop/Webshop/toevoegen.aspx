<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="toevoegen.aspx.cs" Inherits="Webshop.toevoegen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<link href="Stijlen/css/bootstrap.css" rel="stylesheet" />
    <link href="Stijlen/css/background.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Nosifer" rel="stylesheet"/> 
   
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container-fluid">
                <div class="jumbotron" style ="border:1px solid #888; box-shadow:0px 2px 5px #ccc; color:#28a745; font-size:28px; font-family: 'Nosifer', cursive;">
                    <span><em><strong>Online GPU-shop</strong></em></span> - <em><strong>Artikel&nbsp; aan mandje toevoegen</strong> </em><br />
                    <br />
                </div>
            </div>
            <br />
            <table class="table-hover " style="border-collapse:collapse; width:100%;" >
                <tr>
                    <td rowspan="4">
                        <asp:Image ID="imgFoto" runat="server" Width="175px" />
                    </td>
                    <td class="auto-style3">ArtNr:</td>
                    <td class="auto-style3">
                        <asp:Label ID="lblArtNr" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Naam:</td>
                    <td>
                        <asp:Label ID="lblNaam" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Prijs:</td>
                    <td>
                        <asp:Label ID="lblPrijs" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Voorraad:</td>
                    <td>
                        <asp:Label ID="lblVoorraad" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <asp:Label ID="lblWaarschuwing" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
            <br />
            Aantal te bestellen exemplaren van dit item:<asp:TextBox ID="txtbAantal" runat="server" CssClass="form-control" Width="80%" Wrap="False"></asp:TextBox>
            <br />
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnToevoegenAanMand" runat="server" OnClick="btnToevoegenAanMand_Click" Text="Voeg toe aan mandje..." CssClass="btn btn-success" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnTerug" runat="server" Text="Terug naar catalogus..." OnClick="btnTerug_Click" />
                    </td>
                </tr>
            </table>
            <br />
            <br />
            
        </div>
    </form>
</body>
</html>
