<%@ page language="C#" autoeventwireup="true" inherits="SkiChair.Merchandise.Views.ShoppingCart, App_Web_s9ahphuc" title="SkiChair.com - Shopping Cart" masterpagefile="~/Shared/SkiChairMaster.master" stylesheettheme="SkiChair" %>

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
    
    <asp:Button id="btnCheckOut" Text="Check Out" PostBackUrl="~/Merchandise/CheckOut.aspx" runat="server" />
        
</asp:Content>
