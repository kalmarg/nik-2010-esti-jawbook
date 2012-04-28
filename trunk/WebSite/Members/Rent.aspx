<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Rent.aspx.cs" Inherits="WebSite.Members.Rent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <div style="text-align: left; width: 550px">
            <table style="float: left; width: 550px; background-color: #D0D0D0; border: 1px solid white;">
                <tr>
                    <td style="height: 200px; width: 320px; text-align: center">
                        <asp:Image ID="PictureLabel" runat="server" Style="max-width: 100%; max-height: 100%;" />
                    </td>
                    <td>
                        Name:
                        <asp:Label ID="NameLabel" runat="server" />
                        <br />
                        Age:
                        <asp:Label ID="AgeLabel" runat="server" />
                        <br />
                        Price:
                        <asp:Label ID="PriceLabel" runat="server" />
                        <br />
                        Race:
                        <asp:Label ID="RaceLabel" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <div style="text-align: left; width: 800px">
            <table width="100%">
                <tr>
                    <th style="width: 38px;">
                    </th>
                    <th style="width: 38px;">
                    </th>
                    <th style="width: 38px;">
                    </th>
                    <th style="width: 38px;">
                    </th>
                    <th style="width: 38px;">
                    </th>
                </tr>
                <tr>
                    <td>
                        Vezeték név:<br />
                        <asp:TextBox ID="tb1" runat="server" Width="90%"></asp:TextBox>
                    </td>
                    <td>
                        Keresztnév:<br />
                        <asp:TextBox ID="tb2" runat="server" Width="90%"></asp:TextBox>
                    </td>
                    <td>
                        Leánykori név:<br />
                        <asp:TextBox ID="tb3" runat="server" Width="90%"></asp:TextBox>
                    </td>
                    <td colspan="2">
                        Anyja neve:<br />
                        <asp:TextBox ID="tb4" runat="server" Width="90%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        Lakcím:<br />
                        <asp:TextBox ID="tb5" runat="server" Width="90%"></asp:TextBox>
                    </td>
                    <td>
                        Születési dátum:<br />
                        <asp:TextBox ID="tb6" runat="server" Width="90%"></asp:TextBox>
                    </td>
                    <td>
                        Kor:<br />
                        <asp:TextBox ID="tb7" runat="server" Width="90%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Anyja lakcíme:<br />
                        <asp:TextBox ID="tb8" runat="server" Width="90%"></asp:TextBox>
                    </td>
                    <td colspan="2">
                        Leánykori születési dátum:<br />
                        <asp:TextBox ID="tb9" runat="server" Width="90%"></asp:TextBox>
                    </td>
                    <td colspan="2">
                        Leánykori kor:<br />
                        <asp:TextBox ID="tb10" runat="server" Width="90%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        Születési anyja neve:<br />
                        <asp:TextBox ID="tb12" runat="server" Width="90%"></asp:TextBox>
                    </td>
                    <td>
                        Üres marad!<br />
                        <asp:TextBox ID="tb11" runat="server" Width="90%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Anyja születési kora:<br />
                        <asp:TextBox ID="tb13" runat="server" Width="90%"></asp:TextBox>
                    </td>
                    <td>
                        Postás:<br />
                        <asp:TextBox ID="tb14" runat="server" Width="90%"></asp:TextBox>
                    </td>
                    <td colspan="2">
                        Apja vezetékneve:<br />
                        <asp:TextBox ID="tb15" runat="server" Width="90%"></asp:TextBox>
                    </td>
                    <td>
                        Pontos idő:<br />
                        <asp:TextBox ID="tb16" runat="server" Width="90%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        Mikortól:<asp:Calendar ID="cStart" runat="server"></asp:Calendar>
                    </td>
                    <td>
                    </td>
                    <td colspan="2">
                        Meddig:</asp:Label><asp:Calendar ID="cEnd" runat="server"></asp:Calendar>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <asp:Button ID="btnRent" runat="server" Text="Megrendelem" OnClick="btnRent_Click" />
    </center>
    <br />
    <br />
    <asp:Button ID="btnHelp" runat="server" Text="Segítsetek kitölteni" OnClick="btnHelp_Click" />
</asp:Content>
