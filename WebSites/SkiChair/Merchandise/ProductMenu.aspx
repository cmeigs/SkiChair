<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductMenu.aspx.cs" Inherits="SkiChair.Merchandise.Views.ProductMenu"
    Title="ProductMenu" MasterPageFile="~/Shared/SkiChairMasterXSell.master" EnableEventValidation="false"%>
<%@ MasterType VirtualPath="~/Shared/SkiChairMasterXSell.master" %>

<asp:Content ID="headcontent" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

<asp:Content ID="content" ContentPlaceHolderID="DefaultContent" Runat="Server">
    <div class="PageHeader">
        <table><tr><td scope="row"><asp:Label ID="lblTitle" runat="server" ForeColor="White" Font-Bold="true" Font-Size="X-Large"></asp:Label></td></tr></table>
    </div>
    
    <div style="text-align:right">
        <asp:Button ID="btnCurrentInventory" runat="server" Text="See Current Inventory" Visible="false" />    
    </div> 
    <br />

    <asp:Repeater ID="rptProductMenu" runat="server" OnItemDataBound="rptProductMenu_ItemDataBound">
        <HeaderTemplate>
            <table border="0">
                <tr>
        </HeaderTemplate>
        <ItemTemplate>
                    <td valign="top" align="right">
                        <b><%# DataBinder.Eval(Container.DataItem, "InventoryName") %></b>
                        <br />
                        <%# DataBinder.Eval(Container.DataItem, "Price", "{0:c}")%>
                    </td>
                    <td align="left">
                        <asp:ImageButton ID="lnkbtnProductDisplay" runat="server"></asp:ImageButton>
                        <asp:HiddenField ID="hiddenFlickrImageUID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "FlickrImageUID") %>' />
                    </td>
        </ItemTemplate>
        <SeparatorTemplate>
                <tr></tr>
        </SeparatorTemplate>
        <FooterTemplate>
                </tr>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Label ID="lblFeedback" runat="server" Font-Bold="true"></asp:Label>
</asp:Content>
