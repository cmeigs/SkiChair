<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="SkiChair.Merchandise.Views.ShoppingCart"
    Title="SkiChair.com - Shopping Cart" MasterPageFile="~/Shared/SkiChairMaster.master" %>

<asp:Content ID="headcontent" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

<asp:Content ID="content" ContentPlaceHolderID="DefaultContent" Runat="Server">
    <h1>SkiChair.com Shopping Cart</h1>
    
    <asp:Label ID="lblFeedback" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>

    <asp:GridView ID="gvShoppingCart" runat="server" AutoGenerateColumns="False" 
        OnRowCommand="gvShoppingCart_RowCommand" 
        OnRowDataBound="gvShoppingCart_RowDataBound"
        BackColor="White" 
        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        GridLines="Horizontal">
        <Columns>
            <asp:BoundField DataField="InventoryUID" Visible="false" />
            <asp:BoundField DataField="HasOttoman" Visible="false" />
            <asp:BoundField DataField="InventoryName" Visible="false" />
            <asp:BoundField DataField="Price" Visible="false" DataFormatString="{0:c}" />
            <asp:TemplateField HeaderText="Product">
                <ItemTemplate>
                    <asp:Label ID="lblProduct" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price">
                <ItemTemplate>
                    <asp:Label ID="lblPrice" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Remove Item" />
        </Columns>
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="#FFFFFF" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <br />
    <asp:Label ID="lblPhoneNumber" Text="Phone Number (Required)" runat="server"></asp:Label>
    <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button id="btnCheckOut" OnClick="btnCheckout_OnClick" Text="Check Out" runat="server" />
    <!--
    Shopping Cart is not working at this time, please call The Chair Man at 508-335-2202 or email order to mbellino@resourcetp.com
    -->
        
</asp:Content>
