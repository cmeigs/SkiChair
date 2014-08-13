<%@ page title="" language="C#" masterpagefile="~/Shared/SkiChairMaster.master" autoeventwireup="true" inherits="PhotoGallery_PhotoGalleryTemp, App_Web_skprajrr" stylesheettheme="SkiChair" %>
<%@ Register TagPrefix="SkiChair" TagName="PhotoGalleryMenu" Src="~/PhotoGallery/Menu.ascx" %>

<asp:Content ID="headcontent" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" Runat="Server">
    <SkiChair:PhotoGalleryMenu runat="server" id="PhotoGalleryMenu"></SkiChair:PhotoGalleryMenu>
</asp:Content>

