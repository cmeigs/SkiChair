<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/SkiChairMaster.master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="ContactUs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="DefaultContent" Runat="Server">

<div class="PageHeader">
    <table><tr><td scope="row"><asp:Label ID="lblTitle" runat="server" ForeColor="White" Font-Bold="true" Font-Size="X-Large" Text="Contact SkiChair"></asp:Label></td></tr></table>
</div>

<asp:panel id="panelSendEmail" runat="server">
    <table width="100%" border="0">
		<tr><td>&nbsp;</td></tr>
		<tr>
			<td>
				<h3>SkiChair is very interested in hearing from you!</h3>
				<h3>By Phone:</h3>
				508-335-2202 or 508-752-5997
				<h3>By Email:</h3>
				Please enter the information below to send us your message.
			</td>
		</tr>
		<tr><td>&nbsp;</td></tr>
		<tr>
		    <td>
		        <table>
		            <tr>
			            <td align="right"><b>Name:</b></td>
			            <td align="left"><asp:textbox id="txtName" runat="server"></asp:textbox></td>
		            </tr>
		            <tr>
			            <td align="right"><b>Email Address:</b></td>
			            <td align="left"><asp:textbox id="txtEmail" runat="server"></asp:textbox></td>
		            </tr>
		            <tr>
			            <td align="right"><b>Subject:</b></td>
			            <td align="left"><asp:textbox id="txtSubject" runat="server"></asp:textbox></td>
		            </tr>
		            <tr>
			            <td align="right" valign="top"><b>Message:</b></td>
			            <td align="left"><asp:textbox id="txtMessage" runat="server" Rows="10" Columns="40" TextMode="MultiLine"></asp:textbox></td>
		            </tr>
		            <tr>
		                <td>&nbsp;</td>
			            <td valign="middle" height="50">
				            <asp:button class="button" id="btnContactMe" runat="server" Text="Send Message" onclick="btnContactMe_Click"></asp:button>
				        </td>
		            </tr>
		        </table>
		    </td>
		</tr>
	</table>
</asp:panel>
<asp:panel id="panelMailSent" runat="server" Visible="False">
	<table height="125" width="100%" border="0">
		<tr>
			<td valign="middle" align="center">Your email has been sent.<br />
				<br />
				SkiChair.com will respond to you shortly.<br />
				<br />
				<b>- Chairman of the Boards</b>
			</td>
		</tr>
	</table>
</asp:panel>
</asp:Content>

