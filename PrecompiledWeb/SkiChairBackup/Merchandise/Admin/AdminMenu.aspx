<%@ page language="C#" autoeventwireup="true" inherits="SkiChair.Merchandise.Views.AdminMenu, App_Web_v02uxza0" title="SkiChair.com - Administrative Menu" masterpagefile="~/Shared/SkiChairMaster.master" stylesheettheme="SkiChair" %>

<asp:Content ID="headcontent" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

<asp:Content ID="content" ContentPlaceHolderID="DefaultContent" Runat="Server">
    <div class="ProductPageHead">
        <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblTitle" runat="server" ForeColor="White" Font-Bold="true" Font-Size="X-Large" Text="Administrative Menu"></asp:Label>
    </div>
    <br /><br />
    <br /><br />
    <br /><br />
    <br /><br />
    <asp:LinkButton ID="btnUpload" runat="server" Text="Upload Inventory" Font-Bold="true" ForeColor="Black" Font-Underline="true" PostBackUrl="~/Merchandise/Admin/ProductUpload.aspx"></asp:LinkButton>
    <br />
    <br />
    <asp:LinkButton ID="btnEditDelete" runat="server" Text="Edit/Delete Inventory" Font-Bold="true" ForeColor="Black" Font-Underline="true" PostBackUrl="~/Merchandise/Admin/ChooseProduct.aspx"></asp:LinkButton>
    <br />
    <br />
    <br />
    <br />
    <br />    
        
</asp:Content>
