<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="LoggInn.aspx.cs" Inherits="Innsending1Admin.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Logg inn</h1>
    <table>
        <tr>
            <td>Brukernavn</td>
            <td><asp:TextBox ID="BrukernavnTextBox" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Passord</td>
            <td><asp:TextBox ID="PassordTextbox" runat="server"></asp:TextBox></td>
            
        </tr>
    </table>
    <asp:Button ID="LoggInnBrukerButton" runat="server" Text="Logg inn" OnClick="LoggInnBrukerButton_Click" />
    <asp:Literal ID="LoggInnStatus" runat="server"></asp:Literal>
</asp:Content>
