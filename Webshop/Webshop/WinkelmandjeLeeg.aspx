<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WinkelmandjeLeeg.aspx.cs" Inherits="Webshop.WinkelmandjeLeeg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Stijlen/css/bootstrap.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Nosifer" rel="stylesheet"/> 
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container-fluid">
                <div class="jumbotron" style ="border:1px solid #888; box-shadow:0px 2px 5px #ccc; color:#28a745; font-size:28px; font-family: 'Nosifer', cursive; width:100%;">
                     <span ><em><strong>Online GPU-shop</strong></em></span> - <strong><em>Winkelmandje</em> </strong><br />
                     <br />
                </div>

            </div>
            <br />
                <div>
           
            <table class="table-hover" style="  width:100%">
                <tr>
                    <td>Klantnummer:</td>
                    <td>
                        <asp:Label ID="lblKlantNr" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Naam:</td>
                    <td>
                        <asp:Label ID="lblNaam" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Adres:</td>
                    <td class="auto-style1">
                        <asp:Label ID="lblAdres" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="lblPC" runat="server"></asp:Label>
                  &nbsp;<asp:Label ID="lblGemeente" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Besteldatum:</td>
                    <td>
                        <asp:Label ID="lblDatum" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
           
        </div>
            <div class="font-weight-bold">
                <br />
                    Het winkelmandje is leeg. Klik op de knop om terug te keren naar de catalogus.
                <br />
            </div>
            <br />
            <asp:Button ID="btnTerug" runat="server" OnClick="btnTerug_Click" Text="Terug naar catalogus..." />
            <%--</em></strong>--%>
        </div>
    </form>
</body>
</html>
