<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Browse.aspx.cs" Inherits="WebSite.Members.Browse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-left: 64px">
        <asp:DataList ID="DataList1" runat="server" DataKeyField="JawId" DataSourceID="SqlDataSource1"
            RepeatDirection="Horizontal" RepeatLayout="Flow" ShowHeader="False">
            <ItemTemplate>
                <table style="float: left; width: 280px; background-color: #D0D0D0; border: 1px solid white;">
                    <tr>
                        <td style="height: 100px; width: 160px; text-align: center">
                            <asp:Image ID="PictureLabel" runat="server" ImageUrl='<%# "../getPic.ashx?id=" + Eval("JawId") %>'
                                Style="max-width: 100%; max-height: 100%;" />
                        </td>
                        <td style="overflow: auto">
                            Name:
                            <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                            <br />
                            Age:
                            <asp:Label ID="AgeLabel" runat="server" Text='<%# Eval("Age") %>' />
                            <br />
                            Price:
                            <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price") +" Ft"%>' />
                            <br />
                            Race:
                            <asp:Label ID="RaceLabel" runat="server" Text='<%# Eval("Race_Name")%>' /><br />
                            <a href='<%# "Rent.aspx?Id=" + Eval("JawId") %>'>Rent It!</a>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:JawBook.DbConnectionString %>"
            OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT JawId, Jaws.Name AS Name, Age, Price, Races.Name AS Race_Name  FROM [Jaws] INNER JOIN [Races] ON Jaws.Race_RaceId = Races.RaceId">
        </asp:SqlDataSource>
        <div style="clear: both">
        </div>
    </div>
</asp:Content>
