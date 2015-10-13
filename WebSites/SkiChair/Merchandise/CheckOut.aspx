<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckOut.aspx.cs" Inherits="SkiChair.Merchandise.Views.CheckOut" %>
<%@ Register TagPrefix="SkiChair" TagName="Menu" Src="~/Shared/SkiChairMenu.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="Head" runat="server">
    <title>SkiChair.com :: Play in Style, Rest in Style</title>

    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <meta name="KEYWORDS" content="SkiChair.com, recycled furniture, skis, snowboards, wakeboards, wine racks, Adirondack chairs, rocking chairs" />
    <meta name="DESCRIPTION" content="SkiChair.com products reflect the passion and lifestyle of outdoor enthusiasts in their relaxation. SkiChair.com manufactures recycled sports furniture such as Adirondack chairs, benches and swings, by recycling blemished and used sports equipment." />

    <script type="text/javascript">
        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-2989715-3']);
        _gaq.push(['_trackPageview']);

        (function() {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();
    </script>
</head>

<body>
    <form id="mainForm" runat="server">
    
    <div id="container">
        <div id="container-inner">
            
            <div id="header">
                <div id="header-inner">
                    <div id="header-blocks">SkiChair.com products reflect the passion and lifestyle of outdoor enthusiasts in their relaxation. We manufacture <i>recycled</i> sports furniture such as Adirondack chairs, benches and swings, by recycling blemished and used sports equipment.</div>
                    <div id="logo"><a href="/"><asp:Image ID="imgSkiChairLogo" ImageUrl="~/images/SkiChair_Logo.png" runat="server" /></a></div>
                    <div class="clearfix"></div>
                </div> <!-- header-inner -->
            </div> <!-- header -->
            
            <!-- main menu -->
            <div class="mainmenu">
                <SkiChair:Menu ID="ucMenu" runat="server" />
            </div>   
            <div class="clearfix"></div>
            
            <!-- main -->
            <div id="main">
                <div id="main-inner">
                    <div id="content">
                        <div id="content-inner">
                            <div class='front-content'>
                
                                <table border="0" width="100%">
                                    <tr>
		                                <td>
		                                    Questions? We are just a phone call away <strong>call 1-508-335-2202 - ask for the Chairman of the Boards</strong>
		                                </td>
	                                </tr>
                                </table>
	                            <br />    
                            	    
	                            <asp:Label ID="lblFeedback" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                            	
                                <asp:Panel ID="pnlOrderInfo" runat="server">
                                <table border="0">
	                                <tr>
	                                    <td><b>Product Information:</b></td>
	                                    <td><asp:Label ID="lblInventory" runat="server"></asp:Label></td>
	                                </tr>
	                                <tr>
	                                    <td>Price:</td>
	                                    <td><asp:Label ID="lblPrice" runat="server"></asp:Label></td>
	                                </tr>
                                </table>
                                
                                <asp:DropDownList ID="ddlState" runat="server" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                <br />
                                
                                <table>
	                                <tr>
	                                    <td>Tax:</td>
	                                    <td><asp:Label ID="lblTax" runat="server"></asp:Label></td>
	                                </tr>
	                                <tr>
	                                    <td>Shipping:</td>
	                                    <td><asp:Label ID="lblShipping" runat="server"></asp:Label></td>
	                                </tr>
	                                <tr>
	                                    <td>Total:</td>
	                                    <td><asp:Label ID="lblTotal" runat="server"></asp:Label></td>
	                                </tr>
                                </table>
                                <br />
                                
                                
                                <asp:Panel ID="pnlPersonalInfoRequired" runat="server" Visible="false">
                                <table border="0">    	    
	                                <tr>
	                                    <td colspan="2">
	                                        <b>Personal Information:</b>
	                                    </td>
	                                </tr>
	                                <tr>
		                                <td align="right">Name:</td>
		                                <td><asp:TextBox ID="txtFullName" runat="server" class="required" /></td>
	                                </tr>
	                                <tr>
		                                <td align="right">Address:</td>
		                                <td><asp:TextBox ID="txtAddress" runat="server" class="required" /></td>
	                                </tr>
	                                <tr>
		                                <td align="right">City:</td>
		                                <td><asp:TextBox ID="txtCity" runat="server" class="required" /></td>
	                                </tr>
	                                <tr>
		                                <td align="right">Zip Code:</td>
		                                <td><asp:TextBox ID="txtZipCode" runat="server" class="required" /></td>
	                                </tr>
	                                <tr>
		                                <td align="right">Phone Number:</td>
		                                <td><asp:TextBox ID="txtPhone" runat="server" class="required" /></td>
	                                </tr>
	                                <tr>
		                                <td align="right">Email:</td>
		                                <td><asp:TextBox ID="txtEmail" runat="server" class="required" /></td>
	                                </tr>
	                                <tr>
		                                <td align="right">Comments / <br />Different Ship Address:</td>
		                                <td><asp:TextBox ID="txtComments" runat="server" Rows="4" TextMode="MultiLine" class="required" /></td>
	                                </tr>
                                    <tr><td>&nbsp;</td></tr>
	                                <tr>
	                                    <td colspan="2">
	                                        <b>Credit Card Information:</b>
	                                    </td>
	                                </tr>
	                                <tr>
		                                <td align="right">Credit Card Number:</td>
		                                <td><asp:TextBox ID="txtCreditCardNumb" runat="server" /></td>
	                                </tr>
	                                <tr>
		                                <td align="right">Expiration Date:</td>
		                                <td><asp:TextBox ID="txtExpDate" runat="server" /></td>
	                                </tr>
	                                <tr>
		                                <td align="right">CCV:</td>
		                                <td><asp:TextBox ID="txtCCV" runat="server" /></td>
	                                </tr>
                                    <tr>
	                                    <td colspan="2">
	                                        <asp:Label ID="lblPersonalInfoFeedback" Font-Bold="true" ForeColor="Red" runat="server"></asp:Label>
	                                    </td>
	                                </tr>
	                                <tr>
	                                    <td>&nbsp;</td>
	                                    <td><asp:Button ID="btnPersonalInfoSubmit" Text="Continue/Verify" runat="server" OnClick="btnPersonalInfoSubmit_Click" /></td>
	                                </tr>
	                            </table>
                                </asp:Panel>
                                                                
                                
                                <asp:Panel ID="pnlPersonalInfo" runat="server" Visible="false">
                                <table border="0">    	    
	                                <tr>
	                                    <td colspan="2">
	                                        <b>Billing Information:</b>
	                                        &nbsp;&nbsp;&nbsp;
	                                        <asp:LinkButton ID="btnEditInfo" runat="server" Text="Edit Info" OnClick="btnEditInfo_Click" ForeColor="Black"></asp:LinkButton>
	                                    </td>
	                                </tr>
	                                <tr>
		                                <td align="right">Name:</td>
		                                <td>
                                            <span id="spanName" runat="server"></span>
                                            <asp:Literal id="litName" runat="server" />
		                                </td>
	                                </tr>
                                    <tr>
                                        <td align="right">Address:</td>
                                        <td>
                                            <span id="spanAddress" runat="server"></span>
                                            <asp:Literal id="litAddress" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">City:</td>
                                        <td>
                                            <span id="spanCity" runat="server"></span>
                                            <asp:Literal id="litCity" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">State:</td>
                                        <td>
                                            <span id="spanState" runat="server"></span>
                                            <asp:Literal id="litState" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Zip Code:</td>
                                        <td>
                                            <span id="spanZipCode" runat="server"></span>
                                            <asp:Literal id="litZipCode" runat="server" />
                                        </td>
                                    </tr>
	                                <tr>
		                                <td align="right">Phone Number:</td>
		                                <td>
                                            <span id="spanPhone" runat="server"></span>
                                            <asp:Literal id="litPhone" runat="server" />
		                                </td>
	                                </tr>
	                                <tr>
		                                <td align="right">Email:</td>
		                                <td>
                                            <span id="spanEmail" runat="server"></span>
                                            <asp:Literal id="litEmail" runat="server" />		                                    
		                                </td>
	                                </tr>
	                                <tr>
		                                <td align="right">Different Shipping Address / Comments:</td>
		                                <td>
		                                    <span id="spanComments" runat="server" />
                                            <asp:Literal id="litComments" runat="server" />		                                    
		                                </td>
	                                </tr>
	                                <tr><td>&nbsp;</td></tr>
	                                <tr>
	                                    <td colspan="2">
	                                        <b>Credit Card Information:</b>
	                                    </td>
	                                </tr>
	                                <tr>
	                                    <td align="right">Credit Card Number:</td>
		                                <td>
                                            <span id="spanCCNumb" runat="server"></span>
                                            <asp:Literal id="litCCNumb" runat="server" />		                                    
		                                </td>
	                                </tr>
	                                <tr>
	                                    <td align="right">Expiration Date:</td>
		                                <td>
                                            <span id="spanExpDate" runat="server"></span>
                                            <asp:Literal id="litExpDate" runat="server" />		                                    
		                                </td>
	                                </tr>
	                                <tr>
	                                    <td align="right">CCV:</td>
		                                <td>
                                            <span id="spanCCV" runat="server"></span>
                                            <asp:Literal id="litCCV" runat="server" />		                                    
		                                </td>
	                                </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:Button ID="btnCheckout" Text="Checkout" runat="server" OnClick="btnCheckout_OnClick" />
                                        </td>
                                    </tr>
                                </table>
                                </asp:Panel>          
                                </asp:Panel>
                                    
                                <asp:HiddenField ID="hiddenProductUID" runat="server" EnableViewState="true" />
                                <asp:HiddenField ID="hiddenInventoryUID" runat="server" EnableViewState="true" />
                                
                                <input type="hidden" name="bcountry" value="US" />
                                <input type="hidden" name="txntype" value="sale" />
                                
                                <span id="spanStoreName" runat="server" />
                                <span id="spanChargeTotal" runat="server" />
                                <span id="spanSubChargeTotal" runat="server" />
                                <span id="spanShipping" runat="server" />
                                <span id="spanTax" runat="server" />
		                    </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                </div>
            </div>
            <div class="clearfix"></div>
        
            <!-- footer -->
            <div id="footer">
                <div id="footer-inner">
                    <p class="links">
                        <asp:LinkButton ID="LinkButton1" PostBackUrl="~/MissionStatement.aspx" class="white" runat="server" Text="Our Mission" /> | 
                        <asp:LinkButton ID="LinkButton2" PostBackUrl="~/Recycle.aspx" class="white" runat="server" Text="Recycle Commitment" /> | 
                        <asp:LinkButton ID="LinkButton3" PostBackUrl="~/Merchandise/WoodKitPlans.aspx" class="white" runat="server" Text="Ski Kits" /> | 
                        <asp:LinkButton ID="LinkButton4" PostBackUrl="~/Guarantee.aspx" class="white" runat="server" Text="100% Comfort Guarantee" /> | 
                        <asp:LinkButton ID="LinkButton5" PostBackUrl="~/TurnaroundTime.aspx" class="white" runat="server" Text="2-Week Turnaround, 5-Year Guarantee" />
                    </p>
                    <p class="address">
                    4 Abbot Place | Millbury, Massachusetts 01527 | 508-335-2202 | 508-752-5997 | mbellino@skichair.com</p>
                    <p class="credits">Design By: <a href="http://www.skiskisonproductions.com/" target="_blank">SkiSkiSon Productions</a> | Developed By: <a href="http://www.webgigz.com/" target="_blank">WebGigz</a></p>
                </div>
            </div>
            <!-- end footer -->

        </div>
    </div>
        
    </form>
</body>
</html>
