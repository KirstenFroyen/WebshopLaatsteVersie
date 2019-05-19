<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Webshop._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Catalogus</title>
    <link href="Stijlen/css/bootstrap.css" rel="stylesheet" />
  <link href="https://fonts.googleapis.com/css?family=Nosifer" rel="stylesheet"/> 
    <link href="Stijlen/css/background.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container-fluid">
               <div class="jumbotron" style ="border:1px solid #888; box-shadow:0px 2px 5px #ccc; color:#28a745; font-size:34px; font-family: 'Nosifer';" >   
                   <div class="foo">   
                       <span class="letter" data-letter="Online GPU-shop - Catalogus"><em><strong>Online GPU-shop - Catalogus</strong></em></span><br />
                   </div>
                   <br />
               </div>
            </div>
           <br />

            <div class="banner" >
                
                <script type="text/javascript">
                  var bannersnack_embed = {"hash":"bhi2t2y0n","width":160,"height":750,"t":1557685412,"userId":39180100,"type":"html5"};
                </script>
                <script type="text/javascript" src="//cdn.bannersnack.com/iframe/embed.js"></script>
                
           </div>

            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div class="panel panel-default">
                           <%-- <div class="panel-heading" style="align-content:space-around">Artikelen</div>--%>
                            <div class="panel-body">
                               <asp:GridView ID="gvProducten" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvProducten_SelectedIndexChanged" Width="100%" BorderStyle="None"  CssClass="table-responsive" GridLines="None" Overflow="auto">
                                 <Columns>
                                 <asp:BoundField DataField="ArtNr" HeaderText="ArtNr">
                                 <ItemStyle Width="80px" />
                                 </asp:BoundField>
                                 <asp:ImageField DataImageUrlField="Foto" HeaderText="Foto" ControlStyle-CssClass="image">
                                  <ControlStyle Width="150px" />
                                  <ItemStyle Width="185px" Height="160px" />
                                  </asp:ImageField>
                                  <asp:BoundField DataField="Naam" HeaderText="Naam">
                                  <ItemStyle Width="250px" />
                                  </asp:BoundField>
                                  <asp:BoundField DataField="Prijs" DataFormatString="€ {0}" HeaderText="Prijs">
                                  <ItemStyle Width="90px" />
                                  </asp:BoundField>
                                  <asp:BoundField DataField="Voorraad" HeaderText="Voorraad" >
                                  <ItemStyle Width="120px" />
                                  </asp:BoundField>
                                  <asp:CommandField SelectText="Voeg toe aan winkelmandje" ShowSelectButton="True" ControlStyle-ForeColor="WhiteSmoke" ControlStyle-CssClass="link" >
                                  <ItemStyle Width="180px" />
                                  </asp:CommandField>
                                  </Columns>
                                   <RowStyle BorderStyle="None" />
                               </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
         
            <br />

            <asp:Button ID="btnWinkelmandje" runat="server" OnClick="btnWinkelmandje_Click" Text="Bekijk de inhoud van het winkelmandje..." Width="60%" CssClass="btn btn-success" ForeColor="White" />
            <br />
         </div>
               
            
        </div>
    </form>
</body>
</html>
