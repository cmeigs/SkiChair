<%@ page language="C#" autoeventwireup="true" inherits="SkiChair.PhotoGallery.Views.Display, App_Web_lchytzko" title="SkiChair.com - Photo Gallery" masterpagefile="~/Shared/SkiChairMaster.master" stylesheettheme="SkiChair" %>

<asp:Content ID="content" ContentPlaceHolderID="DefaultContent" Runat="Server">
    <table border="0" cellpadding="3" cellspacing="5">
        <tr>
            <td valign="top"><asp:ImageButton ID="imgPreviousPhoto" runat="server" /></td>
            <td align="center" valign="top">
                <asp:Label ID="lblPhotoTitle" runat="server" Font-Bold="true" Font-Size="Large" />
                <br />
                <asp:Image ID="imgPhotograph" runat="server" />
            </td>
            <td valign="top"><asp:ImageButton ID="imgNextPhoto" runat="server" /></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td align="center">
                <asp:Repeater ID="rptComments" runat="server">
                    <HeaderTemplate>
                        <table border="1" cellpadding="5" cellspacing="0">                    
                        <tr>
                            <td><b>User</b></td>
                            <td valign="top"><b>Comment</b></td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%#DataBinder.Eval(Container.DataItem, "AuthorUserName")%>
                                <br />
                                <asp:Label ID="lblDateCreated" runat="server" Text="<%# Bind('DateCreated', '{0:M/d/yyyy}')%>"></asp:Label>
                            </td>
                            <td><%#DataBinder.Eval(Container.DataItem, "CommentHtml")%></td>
                        </tr>                        
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>

</asp:Content>
