<%@ control language="C#" autoeventwireup="true" inherits="SkiChair.Merchandise.Views.SkiChairMenu, App_Web_buqlozfz" %>

<div id="nav">
    <div id="nav-inner">
        <ul id="primary" class="dropdown dropdown-horizontal">
            <li><asp:LinkButton ID="LinkButton32" PostBackUrl="~/Default.aspx" runat="server">Home</asp:LinkButton></li>
            <li><asp:LinkButton ID="LinkButton27" PostBackUrl="~/Merchandise/ProductMenu.aspx?pid=1" runat="server">Chairs</asp:LinkButton>
                <ul>
                    <li><asp:LinkButton ID="LinkButton1" PostBackUrl="~/Merchandise/ProductMenu.aspx?pid=1" runat="server">Snow Ski Chair</asp:LinkButton></li>
                    <li><asp:LinkButton ID="LinkButton2" PostBackUrl="~/Merchandise/ProductMenu.aspx?pid=2" runat="server">Water Ski Chair</asp:LinkButton></li>
                    <li><asp:LinkButton ID="LinkButton3" PostBackUrl="~/Merchandise/ProductMenu.aspx?pid=10" runat="server">Snow Board Chair</asp:LinkButton></li>
                    <li><asp:LinkButton ID="LinkButton4" PostBackUrl="~/Merchandise/ProductMenu.aspx?pid=12" runat="server">Wake Board Chair</asp:LinkButton></li>
                    <li><asp:LinkButton ID="LinkButton5" PostBackUrl="~/Merchandise/ProductMenu.aspx?pid=13" runat="server">Skate Board Chair</asp:LinkButton></li>
                    <li><asp:LinkButton ID="LinkButton6" PostBackUrl="~/Merchandise/ProductMenu.aspx?pid=3" runat="server">Hockey Stick Chair</asp:LinkButton></li>
                    <li><asp:LinkButton ID="LinkButton7" PostBackUrl="~/Merchandise/ProductMenu.aspx?pid=9" runat="server">Base Ball Bat Chair</asp:LinkButton></li>
                    <li><asp:LinkButton ID="LinkButton8" PostBackUrl="~/Merchandise/ProductMenu.aspx?pid=4" runat="server">Golf Club Chair</asp:LinkButton></li>
                </ul>
            </li>
            <li><asp:LinkButton ID="LinkButton28" PostBackUrl="~/Merchandise/ProductMenu.aspx?pid=8" runat="server">Benches</asp:LinkButton>
                <ul>
                    <li><asp:LinkButton ID="LinkButton9" PostBackUrl="~/Merchandise/ProductMenu.aspx?pid=8" runat="server">Snow Ski Bench</asp:LinkButton></li>
                    <li><asp:LinkButton ID="LinkButton10" PostBackUrl="~/Merchandise/ProductMenu.aspx?pid=11" runat="server">Water Ski Bench</asp:LinkButton></li>
                    <li><asp:LinkButton ID="LinkButton11" PostBackUrl="~/Merchandise/ProductMenu.aspx?pid=6" runat="server">Snow Board Bench</asp:LinkButton></li>
                    <li><asp:LinkButton ID="LinkButton12" PostBackUrl="~/Merchandise/ProductMenu.aspx?pid=5" runat="server">Wake Board Bench</asp:LinkButton></li>
                    <li><asp:LinkButton ID="LinkButton13" PostBackUrl="~/Merchandise/ProductMenu.aspx?pid=7" runat="server">Skate Board Bench</asp:LinkButton></li>
                </ul>
            </li>
            <li><asp:LinkButton ID="LinkButton29" PostBackUrl="~/Merchandise/ProductMenu.aspx?pid=15" runat="server">Products</asp:LinkButton>
                <ul>
                    <li><asp:LinkButton ID="LinkButton14" PostBackUrl="~/Merchandise/ProductMenu.aspx?pid=14" runat="server">Log Collection</asp:LinkButton></li>
                    <li><asp:LinkButton ID="LinkButton15" PostBackUrl="~/Merchandise/ProductMenu.aspx?pid=15" runat="server">Coat Racks & Ski Racks</asp:LinkButton></li>
                    <li><asp:LinkButton ID="LinkButton30" PostBackUrl="~/Merchandise/WoodKitPlans.aspx" runat="server">Plans & Wood Kits</asp:LinkButton>
                        <ul>
                            <li><asp:LinkButton ID="LinkButton16" PostBackUrl="~/Merchandise/WoodKitPlans.aspx" runat="server">Ski Plans</asp:LinkButton></li>
                            <li><asp:LinkButton ID="LinkButton17" PostBackUrl="~/Merchandise/WoodKitPlans.aspx" runat="server">Wood Kits</asp:LinkButton></li>
                        </ul>
                    </li>
                    <li><asp:LinkButton ID="LinkButton18" PostBackUrl="~/Merchandise/BenchLegs.aspx" runat="server">Bench Legs</asp:LinkButton></li>
                    <li><asp:LinkButton ID="LinkButton19" PostBackUrl="~/Merchandise/ProductMenu.aspx?pid=17" runat="server">Children's Chairs</asp:LinkButton></li>
                    <li><asp:LinkButton ID="LinkButton20" PostBackUrl="~/Merchandise/ProductMenu.aspx?pid=16" runat="server">Wine Racks</asp:LinkButton></li>
                    <li><asp:LinkButton ID="LinkButton21" PostBackUrl="~/Merchandise/ProductMenu.aspx?pid=24" runat="server">Shot Ski</asp:LinkButton></li>
                    <li><asp:LinkButton ID="LinkButton22" PostBackUrl="~/Merchandise/ProductMenu.aspx?pid=22" runat="server">Other Products</asp:LinkButton></li>
                    <li><asp:LinkButton ID="LinkButton31" PostBackUrl="~/OldSkis.aspx" runat="server">Custom Furniture</asp:LinkButton></li>
                    <li><asp:LinkButton ID="LinkButton23" PostBackUrl="~/Merchandise/ProductMenu.aspx?pid=23" runat="server">Other Furniture</asp:LinkButton></li>
                </ul>
            </li>
            <li><a href="#" class="MenuBarItemSubmenu">Info</a>
                <ul>
                    <li><asp:LinkButton ID="LinkButton24" PostBackUrl="~/Assembly.aspx" runat="server">Assembly</asp:LinkButton></li>
                    <li><asp:LinkButton ID="LinkButton25" PostBackUrl="~/Mountains.aspx" runat="server">Mountains</asp:LinkButton></li>
                    <li><asp:LinkButton ID="LinkButton26" PostBackUrl="~/Directions.aspx" runat="server">Directions</asp:LinkButton></li>
                    <li><asp:LinkButton ID="LinkButton33" PostBackUrl="~/ContactUs.aspx" runat="server">Contact Us</asp:LinkButton></li>
                </ul>
            </li>
            <li><a href="#" class="MenuBarItemSubmenu">Media</a>
                <ul>
                    <li><asp:LinkButton ID="LinkButton36" PostBackUrl="~/PhotoGallery/Set.aspx?sid=72157627603388675" runat="server">Custom Chairs</asp:LinkButton></li>
                    <li><asp:LinkButton ID="LinkButton34" PostBackUrl="~/PhotoGallery/Set.aspx?sid=72157625670296063" runat="server">Lifestyle Photos</asp:LinkButton></li>
                    <li><asp:LinkButton ID="LinkButton35" PostBackUrl="~/PhotoGallery/Set.aspx?sid=72157623891815406" runat="server">Pet Gallery</asp:LinkButton></li>
                    <li><asp:LinkButton ID="LinkButton37" PostBackUrl="~/PhotoGallery/Set.aspx?sid=72157627756803040" runat="server">Videos</asp:LinkButton></li>
                </ul>
            </li>
            <li><asp:LinkButton ID="lnkShippingCart" PostBackUrl="~/Merchandise/ShoppingCart.aspx" Text="Shopping Cart" runat="server" /></li>
        </ul>
        <div class="clearfix"></div>
    </div>
</div>
<div class="clearfix"></div>