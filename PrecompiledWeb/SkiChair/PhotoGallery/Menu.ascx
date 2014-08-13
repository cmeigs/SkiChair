<%@ control language="C#" autoeventwireup="true" inherits="SkiChair.PhotoGallery.Views.Menu, App_Web_hgh2lmiv" %>

<h1>Photo Gallery Menu</h1>

<asp:Repeater ID="rptMenu" runat="server" OnItemDataBound="rptMenu_ItemDataBound">
    <ItemTemplate>
        <asp:Label ID="lblMenuItem" runat="server" EnableViewState="true"></asp:Label>
        &nbsp;
        <asp:Button ID="btnMenuItem" runat="server" EnableViewState="true" />
        <br />
    </ItemTemplate>
</asp:Repeater>
