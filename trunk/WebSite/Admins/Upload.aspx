<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Upload.aspx.cs" Inherits="WebSite.Admins.Upload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td>
                Name:
            </td>
            <td>
                <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Race:
            </td>
            <td>
                <asp:DropDownList ID="ddlRace" runat="server" DataSourceID="EntityDataSource1" 
                    DataTextField="Name" DataValueField="RaceId">
                </asp:DropDownList>
                <asp:EntityDataSource ID="EntityDataSource1" runat="server" 
                    ConnectionString="name=Entities" DefaultContainerName="Entities" 
                    EnableFlattening="False" EntitySetName="Races">
                </asp:EntityDataSource>
            </td>
        </tr>
        <tr>
            <td>
                Age:
            </td>
            <td>
                <asp:TextBox ID="tbAge" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Price:
            </td>
            <td>
                <asp:TextBox ID="tbPrice" runat="server"></asp:TextBox>
            &nbsp;EUR</td>
        </tr>
        <tr>
            <td>
                Img:
            </td>
            <td>
                <asp:FileUpload ID="fuImg" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
            </td>
        </tr>
    </table>
    <asp:Label ID="lMsg" runat="server" BackColor="#FF6A6A" Visible="False" 
        ForeColor="Black"></asp:Label>
</asp:Content>
