<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/SkiChairMaster.master" AutoEventWireup="true" CodeFile="PhotoGalleryTemp.aspx.cs" Inherits="PhotoGallery_PhotoGalleryTemp" %>
<%@ Register TagPrefix="SkiChair" TagName="PhotoGalleryMenu" Src="~/PhotoGallery/Menu.ascx" %>

<asp:Content ID="headcontent" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" Runat="Server">
    <SkiChair:PhotoGalleryMenu runat="server" id="PhotoGalleryMenu"></SkiChair:PhotoGalleryMenu>
</asp:Content>

