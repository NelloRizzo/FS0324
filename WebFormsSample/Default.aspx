<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsSample._Default" %>
<%--ATTENZIONE: Premere F7 per visualizzare il codice--%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblStatus" runat="server"></asp:Label>
    <hr />
    <asp:Label runat="server" ID="counter"></asp:Label>
    <asp:Label ID="Label1" runat="server" Text="Primo Operando"></asp:Label>
    <asp:TextBox ID="txtFirst" runat="server"></asp:TextBox>
    <asp:DropDownList ID="cbOperation" runat="server">
        <asp:ListItem>+</asp:ListItem>
        <asp:ListItem>-</asp:ListItem>
        <asp:ListItem>*</asp:ListItem>
        <asp:ListItem>/</asp:ListItem>
    </asp:DropDownList>
    <asp:Label ID="Label2" runat="server" Text="Secondo Operando"></asp:Label>
    <asp:TextBox ID="txtSecond" runat="server"></asp:TextBox><asp:Button ID="Button1" runat="server" Text="Esegui" OnClick="ExecuteOperation" /><asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
</asp:Content>
