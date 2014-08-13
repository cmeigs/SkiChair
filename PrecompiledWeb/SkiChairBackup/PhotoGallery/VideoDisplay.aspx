<%@ page language="C#" autoeventwireup="true" inherits="SkiChair.PhotoGallery.Views.VideoDisplay, App_Web_lchytzko" title="VideoDisplay" masterpagefile="~/Shared/SkiChairMaster.master" stylesheettheme="SkiChair" %>

<asp:Content ID="content" ContentPlaceHolderID="DefaultContent" Runat="Server">
    <table border="1" cellpadding="3" cellspacing="5">
        <tr>
            <td align="center" valign="top">
                <asp:Label ID="lblPhotoTitle" runat="server" Font-Bold="true" Font-Size="Large" />
                <br />
                <object type="application/x-shockwave-flash" width="300" height="400" 
                        data="http://www.flickr.com/photos/skichair/6185349090/"
                        classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000"> 
                    <param name="flashvars" value="intl_lang=en-us&photo_secret=9c868ce0a8&photo_id=4583206312" />
                    <param name="movie" value="http://www.flickr.com/photos/skichair/6185349090/" />
                    <param name="bgcolor" value="#000000" /> 
                    <param name="allowFullScreen" value="true" />
                    <embed type="application/x-shockwave-flash" src="http://www.flickr.com/photos/skichair/6185349090/"
                            bgcolor="#000000" allowfullscreen="true"
                            flashvars="intl_lang=en-us&photo_secret=9c868ce0a8&photo_id=4583206312"
                            height="400" width="300">
                    </embed>
                </object>
            </td>
        </tr>
    </table>

</asp:Content>
