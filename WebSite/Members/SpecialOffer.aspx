<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SpecialOffer.aspx.cs" Inherits="WebSite.Members.SpecialOffer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    Kedves érdeklődő!
    <br />
    Válaszd ki, milyen célra kívánsz magad mellé társat választani. A kattintásodat
    rendszerünk érzékeli és annak apró jeleiből felismerve személyiségedet, a számodra
    legmegfelelőbb társat fogja ajánlani.<br />
    <center>
        <asp:DropDownList ID="ddlTarget" runat="server" 
            onselectedindexchanged="ddlTarget_SelectedIndexChanged" 
            AutoPostBack="True">
            <asp:ListItem Text="Válassz!"></asp:ListItem>
            <asp:ListItem Text="Iskolába"></asp:ListItem>
            <asp:ListItem Text="Barlangtúrához"></asp:ListItem>
            <asp:ListItem Text="Moziba"></asp:ListItem>
            <asp:ListItem Text="Biciklizni"></asp:ListItem>
            <asp:ListItem Text="Jesszusom!"></asp:ListItem>
        </asp:DropDownList>
    </center>
    <br />
    <br />
    <asp:Panel ID="p" runat="server" Visible="False">
        <table width="100%">
            <tr>
                <td>
                    <table style="float: left; width: 280px; background-color: #D0D0D0; border: 1px solid white;">
                        <tr>
                            <td style="height: 100px; width: 160px; text-align: center">
                                <asp:Image ID="iJ1" runat="server" Style="max-width: 100%; max-height: 100%;" />
                            </td>
                            <td style="overflow: auto">
                                Name:
                                <asp:Label ID="lJ1Name" runat="server" />
                                <br />
                                Age:
                                <asp:Label ID="lJ1Age" runat="server" />
                                <br />
                                Price:
                                <asp:Label ID="lJ1Price" runat="server" />
                                <br />
                                Race:
                                <asp:Label ID="lJ1Race" runat="server" /><br />
                                <asp:HyperLink  id="aJ1" runat="server">Rent It!</asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <table style="float: left; width: 280px; background-color: #D0D0D0; border: 1px solid white;">
                        <tr>
                            <td style="height: 100px; width: 160px; text-align: center">
                                <asp:Image ID="iJ2" runat="server" Style="max-width: 100%; max-height: 100%;" />
                            </td>
                            <td style="overflow: auto">
                                Name:
                                <asp:Label ID="lJ2Name" runat="server" />
                                <br />
                                Age:
                                <asp:Label ID="lJ2Age" runat="server" />
                                <br />
                                Price:
                                <asp:Label ID="lJ2Price" runat="server" />
                                <br />
                                Race:
                                <asp:Label ID="lJ2Race" runat="server" /><br />
                                <asp:HyperLink id="aJ2" runat="server">Rent It!</asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <table style="float: left; width: 280px; background-color: #D0D0D0; border: 1px solid white;">
                        <tr>
                            <td style="height: 100px; width: 160px; text-align: center">
                                <asp:Image ID="iJ3" runat="server" Style="max-width: 100%; max-height: 100%;" />
                            </td>
                            <td style="overflow: auto">
                                Name:
                                <asp:Label ID="lJ3Name" runat="server" />
                                <br />
                                Age:
                                <asp:Label ID="lJ3Age" runat="server" />
                                <br />
                                Price:
                                <asp:Label ID="lJ3Price" runat="server" />
                                <br />
                                Race:
                                <asp:Label ID="lJ3Race" runat="server" /><br />
                                <asp:HyperLink id="aJ3" runat="server">Rent It!</asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
