<%@ page language="C#" autoeventwireup="true" inherits="SkiChair.PhotoGallery.Views.Set, App_Web_hgh2lmiv" title="SkiChair.com - Photo Gallery" masterpagefile="~/Shared/SkiChairMaster.master" stylesheettheme="SkiChair" %>

<asp:Content ID="headcontent" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

<asp:Content ID="content" ContentPlaceHolderID="DefaultContent" Runat="Server">
    <h1><asp:Label ID="lblSetTitle" runat="server"></asp:Label></h1>
    
    <asp:Repeater runat="server" ID="rptPhotoSet" OnItemDataBound="rptPhotoSet_OnItemDataBound">
        <ItemTemplate>
            <asp:ImageButton ID="imgbtnPhoto" runat="server" />
        </ItemTemplate>
    </asp:Repeater>
    
</asp:Content>
