<%@ page language="C#" autoeventwireup="true" inherits="SkiChair.Merchandise.Views.ProductUpload, App_Web_xove6fmj" title="SkiChair.com - Inventory Upload" masterpagefile="~/Shared/SkiChairMaster.master" stylesheettheme="SkiChair" %>

<asp:Content ID="headcontent" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

<asp:Content ID="content" ContentPlaceHolderID="DefaultContent" Runat="Server">
    <div class="ProductPageHead">
        <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblTitle" runat="server" ForeColor="White" Font-Bold="true" Font-Size="X-Large" Text="Inventory Upload"></asp:Label>
    </div>
    <br /><br />
    <br /><br />
	<table border="0" cellpadding="5" cellspacing="5">
	    <tr>
	        <td colspan="2">
	        	<asp:Label ID="lblFeedback" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
            </td>
	    </tr>
	    <tr>
	        <td align="right" valign="top">Name:</td>
            <td><asp:TextBox ID="txtProductName" runat="server"></asp:TextBox></td>
	    </tr>
	    <tr>
	        <td align="right" valign="top">Price:</td>
            <td><asp:TextBox ID="txtProductPrice" runat="server"></asp:TextBox></td>
	    </tr>
	    <tr>
	        <td align="right" valign="top">Type:</td>
            <td><asp:DropDownList id="ddlProductType" runat="server"></asp:DropDownList></td>
	    </tr>
	    <tr>
	        <td align="right" valign="top">Description:</td>
            <td><asp:TextBox id="txtProductDescription" runat="server" Height="90px" Width="300px" TextMode="MultiLine"></asp:TextBox></td>
	    </tr>
	    <tr>
	        <td colspan="2"><asp:FileUpload ID="btnFileUpload" runat="server" Width="450px" /></td>
	    </tr>
	    <tr>
	        <td>&nbsp;</td>
	        <td><asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" /></td>
	    </tr>
	</table>    
</asp:Content>
