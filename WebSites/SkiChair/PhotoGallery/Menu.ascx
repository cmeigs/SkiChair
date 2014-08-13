<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu.ascx.cs" Inherits="SkiChair.PhotoGallery.Views.Menu" %>

<h1>Photo Gallery Menu</h1>

<asp:Repeater ID="rptMenu" runat="server" OnItemDataBound="rptMenu_ItemDataBound">
    <ItemTemplate>
        <asp:Label ID="lblMenuItem" runat="server" EnableViewState="true"></asp:Label>
        &nbsp;
        <asp:Button ID="btnMenuItem" runat="server" EnableViewState="true" />
        <br />
    </ItemTemplate>
</asp:Repeater>
