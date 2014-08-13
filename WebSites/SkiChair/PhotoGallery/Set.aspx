<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Set.aspx.cs" Inherits="SkiChair.PhotoGallery.Views.Set"
    Title="SkiChair.com - Photo Gallery" MasterPageFile="~/Shared/SkiChairMaster.master" %>

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
