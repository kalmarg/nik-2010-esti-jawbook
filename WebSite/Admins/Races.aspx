<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Races.aspx.cs" Inherits="WebSite.Admins.Races1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="gv" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" DataKeyNames="RaceId" 
        onpageindexchanged="GridView1_PageIndexChanged" 
        onpageindexchanging="GridView1_PageIndexChanging" 
        onrowcancelingedit="GridView1_RowCancelingEdit" 
        onrowdeleted="GridView1_RowDeleted" onrowdeleting="GridView1_RowDeleting" 
        onrowediting="GridView1_RowEditing" onrowupdated="GridView1_RowUpdated" 
        onrowupdating="GridView1_RowUpdating" onsorted="GridView1_Sorted" 
        onsorting="GridView1_Sorting" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                        Text="Update"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                        Text="Cancel"></asp:LinkButton>
                </EditItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                        Text="Edit"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                        Text="Delete"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="RaceId" SortExpression="RaceId" Visible="False">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("RaceId") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("RaceId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name" SortExpression="Name">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConflictDetection="CompareAllValues" 
        ConnectionString="<%$ ConnectionStrings:JawBook.DbConnectionString %>" 
        DeleteCommand="DELETE FROM [Races] WHERE [RaceId] = @original_RaceId AND (([Name] = @original_Name) OR ([Name] IS NULL AND @original_Name IS NULL))" 
        InsertCommand="INSERT INTO [Races] ([RaceId], [Name]) VALUES (@RaceId, @Name)" 
        OldValuesParameterFormatString="original_{0}" 
        SelectCommand="SELECT * FROM [Races]" 
        UpdateCommand="UPDATE [Races] SET [Name] = @Name WHERE [RaceId] = @original_RaceId AND (([Name] = @original_Name) OR ([Name] IS NULL AND @original_Name IS NULL))">
        <DeleteParameters>
            <asp:Parameter Name="original_RaceId" Type="Object" />
            <asp:Parameter Name="original_Name" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="RaceId" Type="Object" />
            <asp:Parameter Name="Name" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="original_RaceId" Type="Object" />
            <asp:Parameter Name="original_Name" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:LinkButton ID="btnNew" Text="New" runat="server" OnClick="btnNew_Click"></asp:LinkButton>
</asp:Content>
