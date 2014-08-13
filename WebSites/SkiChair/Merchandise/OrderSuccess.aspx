<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderSuccess.aspx.cs" Inherits="SkiChair.Merchandise.Views.OrderSuccess"
    Title="OrderSuccess" MasterPageFile="~/Shared/SkiChairMaster.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="DefaultContent" Runat="Server">
    <h3>Thank You for your Business!</h3>
    Your Order for <asp:Label ID="lblInventory" runat="server" /> has been successfully processed and will ship in 2-5 business days. 
    <br /> If you have any questions you can call/email (508) 752-5997 or <a href='mailto:mbellino@SkiChair.com'><font color='black'>mbellino@SkiChair.com</font></a>
    <br />
    <br />
    Thank You!<br />
    - SkiChair.com
</asp:Content>

