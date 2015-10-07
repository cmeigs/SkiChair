using System;
using System.Web;

public partial class PayPalEC : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        NVPAPICaller test = new NVPAPICaller();
        string retMsg = "";
        string token = "";
        
        if ( HttpContext.Current.Session["payment_amt"] != null)
        {
            //string amt = HttpContext.Current.Session["payment_amt"].ToString();
            //string shipping = HttpContext.Current.Session["shipping_amt"].ToString();
            //string productDescription = HttpContext.Current.Session["product_description"].ToString();

            bool ret = test.ShortcutExpressCheckout(ref token, ref retMsg);
            if (ret)
            {
				HttpContext.Current.Session["token"] = token;
                Response.Redirect( retMsg );
            }
            else
            {
                Response.Redirect("APIError.aspx?" + retMsg);
            }
        }
        else
        {
            Response.Redirect( "APIError.aspx?ErrorCode=AmtMissing" );
        }
    }
}