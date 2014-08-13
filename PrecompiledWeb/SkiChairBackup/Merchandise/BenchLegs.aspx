<%@ page title="SkiChair.com - Bench Legs" language="C#" masterpagefile="~/Shared/SkiChairMaster.master" autoeventwireup="true" inherits="Merchandise_BenchLegs, App_Web_ids11at7" stylesheettheme="SkiChair" %>

<asp:Content ID="headcontent" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" Runat="Server">
    <div class="PageHeader">
        <table><tr><td scope="row"><asp:Label ID="lblTitle" Text="Bench Legs" runat="server" ForeColor="White" Font-Bold="true" Font-Size="X-Large"></asp:Label></td></tr></table>
    </div>

    <table>
        <tr>
            <td>
                <br />
                Bench Legs are made from re-cycled plastic and are available in black only. All that is needed to create you own Bench, Table or Seat is some decking screws and washers that can be purchased at any hardware store. 
                <br /><br />
                A. Bench Legs - 60 lbs <br />
                B. Table Legs - 30 lb <br />
                C. Stainless Steel screws & washers 
                <br /><br />
                <asp:Button id="btnBenchLegs" Text="Click Here For Pricing" PostBackUrl="~/Merchandise/ProductMenu.aspx?pid=26" runat="server"></asp:Button>
                <br /><br />
                Benches are made entirely of recycled products and utilize recycled skis and boards. The legs are made from recycled plastics and weigh 30 lbs each or 60lbs/set.  These legs can take any of your old Skis, Boards and Sticks turning them into a piece of furniture you will have for decades to come.  The legs are so durable that the screws can be taken driven in and out countless times.  As for the weight of these legs, it's probably their biggest asset.  This keeps the bench from getting blown over or off your dock as well as from tipping up and over, should someone site on it's edge.   Bench Size:  Height 36", Width 4", Seat Height 18", total weight with two 30lb legs is 60lbs.  Note: For assembly purposes, the screws are driven into the center line of the legs and NOT the pre-drilled holes!!
                <br /><br />
                <img src="../images/benchlegs.jpg" alt="" />
            </td>
        </tr>
    </table>
</asp:Content>

