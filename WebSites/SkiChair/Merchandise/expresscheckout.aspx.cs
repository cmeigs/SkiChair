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
            string amt = HttpContext.Current.Session["payment_amt"].ToString();

            bool ret = test.ShortcutExpressCheckout(amt, ref token, ref retMsg);
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