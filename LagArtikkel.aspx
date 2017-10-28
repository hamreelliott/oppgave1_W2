<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="LagArtikkel.aspx.cs" Inherits="Innsending1Admin.LagArtikkel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section id="NyArtikkel">
        <h1>Lag ny artikkel</h1>
        <table>
            <tr>
                <td>Tittel</td>
                <td><asp:TextBox ID="TittelTextBox" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Tekst</td>
                <td><asp:TextBox ID="TekstTextBox" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Bilde</td>
                <td><asp:FileUpload ID="BildeFileUpload" runat="server" /></td>
            </tr>
        </table>
        <asp:Button ID="RegistrerArtikkel" runat="server" Text="Registrer artikkel" OnClick="RegistrerArtikkel_Click" />
        <asp:Literal ID="RegistreringstatusLiteral" runat="server"></asp:Literal>
    </section>
    
    <section id="RedigerArtikkel">
        <h1>Rediger artikkel</h1>
        <table>
             
            <tr>
                <td>Id</td>
                <td><asp:TextBox ID="IdTextBox" runat="server"></asp:TextBox></td>
                <td><asp:Button ID="HentButton" runat="server" Text="Hent" OnClick="HentButton_Click" /></td>
            </tr>
            <tr>
                <td>Tittel</td>
                <td><asp:TextBox ID="RedigerTittelTextBox" runat="server"></asp:TextBox></td>
            </tr>
        </table>
        <asp:Button ID="OppdaterArtikkelButton" runat="server" Text="Oppdater artikkel" OnClick="OppdaterArtikkelButton_Click" />
        <asp:Button ID="SlettArtikkelButton" runat="server" Text="Slett" OnClick="SlettArtikkelButton_Click" />
    </section>
</asp:Content>
