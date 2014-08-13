<%@ page language="C#" autoeventwireup="true" inherits="SkiChair.Merchandise.Views.ChooseProduct, App_Web_xove6fmj" title="SkiChair.com - Select Product" masterpagefile="~/Shared/SkiChairMaster.master" stylesheettheme="SkiChair" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxLibrary" %>

<asp:Content ID="headcontent" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

<asp:Content ID="content" ContentPlaceHolderID="DefaultContent" Runat="Server">
    <div class="ProductPageHead">
        <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblTitle" runat="server" ForeColor="White" Font-Bold="true" Font-Size="X-Large" Text="Select Product to Edit / Remove"></asp:Label>
    </div>
    <br /><br />
    <br /><br />
    <br /><br />
    <br /><br />

    <asp:Label ID="lblFeedback" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
    
    <asp:DropDownList ID="ddlProduct" runat="server" AutoPostBack="true" EnableViewState="true" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged"></asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="lblNoInventory" runat="server" ForeColor="Red"></asp:Label>

    <asp:DropDownList ID="ddlInventory" runat="server" AutoPostBack="true" EnableViewState="true" OnSelectedIndexChanged="ddlInventory_SelectedIndexChanged" Visible="false"></asp:DropDownList>
    <br />
    <br />
    
    <asp:Panel ID="pnlInventory" runat="server" Visible="false">
        <table border="0">
            <tr>
                <td align="right">Inventory Name:</td>
                <td><asp:TextBox ID="txtInventoryName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" valign="top">Description:</td>
                <td><asp:TextBox ID="txtDescription" runat="server" Height="90px" Width="300px" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">Price:</td>
                <td><asp:TextBox ID="txtPrice" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" valign="top">IsActive:</td>
                <td>
                    <asp:RadioButtonList ID="rdoIsActive" runat="server">
                        <asp:ListItem Value="1" Text="Enabled"></asp:ListItem>
                        <asp:ListItem Value="0" Text="Disabled"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td><asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" /></td>
                <td><asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" /></td>
            </tr>
        </table>
        <asp:HiddenField ID="txtInventoryUID" runat="server" />
        <asp:HiddenField ID="txtFlickrImageUID" runat="server" />
    </asp:Panel>

    <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" style="display:none" />  
    <ajaxLibrary:ModalPopupExtender ID="ModalPopupDeleteConfirmation" runat="server" 
        TargetControlID="hiddenTargetControlForModalPopup" 
        OkControlID="btn_Ok"
        OnOkScript="onOk()"
        CancelControlID="btn_Cancel" 
        PopupControlID="panel_Popup"
        BackgroundCssClass="modalBackground" />

    <asp:Panel ID="panel_Popup" runat="server" Width="500" Height="350" CssClass="modalpopup">
        <div class="popupcontainer">
            <div class="popupheader">
                Product Delete<br />
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="close" OnClientClick="$find('popup').hide(); return false;" />
            </div>
            <div class="popupbody">
                <asp:Label ID="Label1" runat="server" CssClass="msg" Text="Do you want to continue?" />
            </div>
            <div class="popupfooter">
                <asp:Button ID="btn_Ok" runat="server" Text="OK" />
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" />
            </div>
        </div>
    </asp:Panel>
    
    <asp:Button ID="btnConfirm" runat="server" OnClick="btnConfirm_Click" style="display:none" />
    <script type="text/javascript">
        function onOk() {
            document.getElementById('<%=btnConfirm.ClientID%>').click();
        }
    </script>
          
</asp:Content>

