using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Merchandise_DoExpressCheckout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        NVPAPICaller payPalAPI = new NVPAPICaller();
        decimal finalAmountDec = Convert.ToDecimal(HttpContext.Current.Session["payment_amt"]);
        decimal shipping = Convert.ToDecimal(HttpContext.Current.Session["shipping_amt"]);
        string finalAmount = (finalAmountDec + shipping).ToString("#.##");
        string productDescription = HttpContext.Current.Session["product_description"].ToString();
        //string token = HttpContext.Current.Session["token"].ToString();
        string token = HttpContext.Current.Request.QueryString["token"].ToString();
        string payerID = HttpContext.Current.Request.QueryString["PayerID"].ToString();
        string retMsg = "Transaction was a success, enjoy your SkiChair product!";
        NVPCodec nvpCodec = new NVPCodec();

        bool ret = payPalAPI.ConfirmPayment(finalAmount, productDescription, token, payerID, ref nvpCodec, ref retMsg);
        if (ret) {
            // send order success email
            MailMessage eMail = new MailMessage();
            eMail.To.Add(ConfigurationManager.AppSettings["SMTPEmail"]);
            eMail.Subject = "SkiChair.com Order";
            eMail.Body = DateTime.Now + " - Order from SkiChair.com <br /><br />" + productDescription + "<br /><br />Phone Number: <br />" + HttpContext.Current.Session["PhoneNumber"];
            //eMail.From = new MailAddress(txtEmail.Text, txtName.Text);
            eMail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient(ConfigurationManager.AppSettings["SMTPHost"]);
            smtp.Send(eMail);

            //Response.Redirect("OrderSuccess.aspx&msg=" + retMsg);
            Response.Redirect("OrderSuccess.aspx");
        } else {
            //Response.Redirect("OrderError.aspx&msg=" + retMsg);
            Response.Redirect("OrderError.aspx");
        }
    }
}
