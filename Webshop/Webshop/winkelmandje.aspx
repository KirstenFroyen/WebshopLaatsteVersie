<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="winkelmandje.aspx.cs" Inherits="Webshop.winkelmandje" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<link href="Stijlen/css/bootstrap.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Nosifer" rel="stylesheet"/> 
    <style type="text/css">
        .auto-style1 {
            height: 50px;
        }
    </style>
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

        <br />
        <div class="alert-dark">
        <br />
        <asp:GridView ID="gvMandje" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvMandje_SelectedIndexChanged" Width="80%" BorderStyle="None" GridLines="None">
            <Columns>
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/deleteknop.png" ShowSelectButton="True" >
                <ItemStyle Width="350px" />
                </asp:CommandField>
                <asp:ImageField DataImageUrlField="Foto" HeaderText="Foto">
                    <ControlStyle Width="150px" />
                    <ItemStyle Width="250px" />
                </asp:ImageField>
                <asp:BoundField DataField="ArtNr" HeaderText="ArtNr">
                <ItemStyle Width="75px" />
                </asp:BoundField>
                <asp:BoundField DataField="Naam" HeaderText="Naam">
                <ItemStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="Aantal" HeaderText="Aantal" >
                <ItemStyle Width="150px" />
                </asp:BoundField>
                <asp:BoundField DataField="Prijs" DataFormatString="{0:C}" HeaderText="Prijs">
                <ItemStyle Width="80px" />
                </asp:BoundField>
                <asp:BoundField DataField="Totaal" DataFormatString="{0:C}" HeaderText="Totaal">
                <ItemStyle Width="85px" />
                </asp:BoundField>
            </Columns>
            <EditRowStyle BorderStyle="None" />
        </asp:GridView>
        </div>
        <br />
        <br />
        <table class="table-hover table-bordered table-success "style="width:100%;"  >
            <tr>
                        <td class="auto-style4" >Totaal excl. BTW:</td>
                        <td class="auto-style4" >
                            <asp:Label ID="lblTotExBtw" runat="server"></asp:Label>
                        </td>
            </tr>
            <tr>
                        <td class="auto-style4">BTW:</td>
                        <td class="auto-style4">
                            <asp:Label ID="lblBtw" runat="server"></asp:Label>
                        </td>
            </tr>
            <tr>
                        <td >Totaal incl. BTW:</td>
                        <td >
                            <asp:Label ID="lblTotIncBtw" runat="server"></asp:Label>
                        </td>
            </tr>
        </table>
        <br />
        <br />
        <table class="auto-style3">
            <tr>
                <td>
        <asp:Button ID="btnBestellen" runat="server" OnClick="btnBestellen_Click" Text="Plaats bestelling ..." CssClass="btn btn-success" />
                    
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnTerug" runat="server" Text="Terug naar catalogus..." OnClick="btnTerug_Click" />
                </td>
            </tr>
        </table>
        <br />
    </form>
    <br />
    <br />
  

</body>
</html>
