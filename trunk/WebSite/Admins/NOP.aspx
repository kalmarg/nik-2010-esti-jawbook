<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="NOP.aspx.cs" Inherits="WebSite.Admins.NOP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <asp:Button ID="btnNOP" runat="server" Text="nop" onclick="btnNOP_Click" /></center>
</asp:Content>
