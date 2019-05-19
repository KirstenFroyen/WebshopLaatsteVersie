<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bestelbevestiging.aspx.cs" Inherits="Webshop.bestelbevestiging" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">


        .auto-style1 {
            font-size: large;
            text-decoration: underline;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <span class="auto-style1"><em><strong>Online GPU-shop</strong></em></span> - <em><strong>Bestelbevestiging<br />
            <br />
            Uw bestelling met ordernummer
            <asp:Label ID="lblOrderNr" runat="server"></asp:Label>
&nbsp;werd door ons goed ontvangen
            <br />
            Na betaling van
            <asp:Label ID="lblTotaal" runat="server"></asp:Label>
&nbsp;op rekeningnummer BE91 5612 1236 7859 zullen wij ovegaan tot de verzending van de grafische kaart(en).<br />
            Gelieve het ordernummer als betalingsreferentie mee te geven.<br />
            Bedankt voor uw vertrouwen!
            <br />
            <br />
            <asp:Button ID="btnTerugNaarCath" runat="server" Text="Terug naar catalogus..." OnClick="btnTerugNaarCath_Click" />
            <br />
            </strong></em>
        </div>
    </form>
</body>
</html>
