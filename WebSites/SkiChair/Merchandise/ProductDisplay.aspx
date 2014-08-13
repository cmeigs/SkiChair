<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductDisplay.aspx.cs" Inherits="SkiChair.Merchandise.Views.ProductDisplay"
    Title="SkiChair.com - Product Display" MasterPageFile="~/Shared/SkiChairMaster.master" %>

<asp:Content ID="headcontent" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

<asp:Content ID="content" ContentPlaceHolderID="DefaultContent" Runat="Server">
    <div class="PageHeader">
        <table><tr><td scope="row"><asp:Label ID="lblTitle" runat="server" ForeColor="White" Font-Bold="true" Font-Size="X-Large"></asp:Label></td></tr></table>
    </div>

    <table border="0" width="100%">
        <tr>
            <td valign="top">
                <asp:Image ID="imgInventory" runat="server" ImageAlign="Left" BorderWidth="5px" BorderColor="White" />
                <asp:Label ID="lblInventoryTitle" runat="server" Font-Bold="true"></asp:Label>
                <br />
                <br />
                <asp:Literal ID="litInventoryDescription" runat="server" />
            </td>
            <td valign="top">
                <br /><br /><br /><br />
                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click"></asp:Button>
                <br />
                <asp:Button ID="btnShoppingCart" runat="server" Text="Add to Shopping Cart" OnClick="btnShoppingCart_Click" /><br />
                <asp:CheckBox ID="chkOttoman" runat="server" Text="Include Ottoman?" Visible="true" /><br />
                <asp:Label ID="lblShoppingCart" runat="server" ForeColor="Red"></asp:Label>
                <asp:Button ID="btnCheckout" runat="server" Text="Continue to Checkout" PostBackUrl="~/Merchandise/ShoppingCart.aspx" Visible="false" />
                <asp:HiddenField ID="hiddenInventoryUID" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
