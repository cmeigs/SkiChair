<%@ page title="SkiChair.com - Wood Kit Plans" language="C#" masterpagefile="~/Shared/SkiChairMaster.master" autoeventwireup="true" inherits="Product_WoodKitPlans, App_Web_ids11at7" stylesheettheme="SkiChair" %>

<asp:Content ID="headcontent" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" Runat="Server">
    <div class="PageHeader">
        <table><tr><td scope="row"><asp:Label ID="lblTitle" Text="Wood Kit Plans" runat="server" ForeColor="White" Font-Bold="true" Font-Size="X-Large"></asp:Label></td></tr></table>
    </div>

    <table>
        <tr>
            <td valign="top">
                <b>Plans for a Skichair and Ottoman</b> 
                <asp:Button id="btnPlans" Text="Click Here For Pricing" PostBackUrl="~/Merchandise/ProductMenu.aspx?pid=25" runat="server"></asp:Button>
                <br /><br />
                Now you can make your own skichair and ottoman with this booklet and blue print the Skichair and ottoman direct from the masters at Skichair.com 
                <br /><br />
                The Plan explains how to make a Skichair and Ottoman out of your own Snow Skis, Water Skis, Wake Boards, Snow Boards, Baseball Bats, Hockey Sticks and Golf Clubs. Plans include a 3ft. by 4ft. actual, to size, drawing of the Skichair and Ottoman's wooden pieces as well as a detailed description on how to cut and drill the wooden pieces and your sports equipment, as well as detailed assembly instructions.
                <br /><br /><br />

                <b>Wood Kit for a Skichair and Ottoman</b>
                <asp:Button id="btnWoodKit" Text="Click Here For Pricing" PostBackUrl="~/Merchandise/ProductMenu.aspx?pid=25" runat="server"></asp:Button>
                <br /><br />
                Now you can make your own skichair and ottoman with this booklet, screws and all the wooden pieces needed direct from the masters at Skichair.com
                <br /><br />
                A wood kit includes everything needed for the assembly of a Skichair and Ottoman except your sports equipment. It includes detailed directions to cut and drill the Snow Skis, Water Skis, Wake Boards, Snow Boards, Baseball Bats, Hockey Sticks and Golf Clubs and how to assemble the Skichair and Ottoman as well as all the stainless steel screws and wood, Port Oford Cedar, which is cut, drilled and routered!
                <br /><br /><br />
                
                <b>Wood Kits for all the log furniture</b>
                <asp:Button id="btnLogFurniture" Text="Click Here For Pricing" PostBackUrl="~/Merchandise/ProductMenu.aspx?pid=25" runat="server"></asp:Button>
                <br /><br />
                A wood kit includes everything needed for the assembly of a Log skichair or swing except your sports equipment. It includes detailed directions to cut and drill the Snow Skis, Water Skis, Wake Boards, Snow Boards, Baseball Bats, Hockey Sticks and Golf Clubs and how to assemble the log Skichair or swing as well as all the stainless steel screws and log pieces to complete the project!  You supply the time and have some fun!
                <br /><br /><br />
                 
                <!--
                <b>Children's Chair</b>
                <br />
                <table>
                    <tr>
                        <td>Log Chair</td>
                        <td>$179.95</td>
                    </tr>
                    <tr>
                        <td>Log Rocker</td>
                        <td>$199.95</td>
                    </tr>
                    <tr>
                        <td>4' Swing Kit w/Frame</td>
                        <td>$399.95</td>
                    </tr>
                    <tr>
                        <td>Log Bench 4'</td>
                        <td>$299.95</td>
                    </tr>
                    <tr>
                        <td>Log Bench 6'</td>
                        <td>$399.95</td>
                    </tr>
                    <tr>
                        <td>3 Piece Bistro Set<br />(2 Bar Stools & 32' table)</td>
                        <td>$599.95</td>
                    </tr>
                    <tr>
                        <td>5 Piece Bistro Set<br />(4 Bar Stools & 32' Table)</td>
                        <td>$899.95</td>
                    </tr>
                    <tr>
                        <td>Bar Stool</td>
                        <td>$199.95</td>
                    </tr>
                </table>
                <br /><br />	
                 
                <b>Shipping</b>
                <br />
                Plans...............$5.95<br />
                All other log Wood Kits and Skichair and ottoman wood kits..............$29.95<br />
                Log Swing with Cradle............$59.95            
                -->
            </td>
            <td valign="top">
                <asp:Image ID="imgWoodKit" runat="server" ImageUrl="../images/woodplans.jpg" />
                <br />
                <br />
                <asp:Image ID="imgSkiPlans" runat="server" ImageUrl="../images/skiplans.jpg" />
            </td>
        </tr>
    </table>
    
</asp:Content>