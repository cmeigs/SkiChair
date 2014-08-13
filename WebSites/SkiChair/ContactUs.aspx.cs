using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ContactUs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnContactMe_Click(object sender, System.EventArgs e)
    {
        MailMessage eMail = new MailMessage();
        eMail.To.Add(ConfigurationManager.AppSettings["SMTPEmail"]);
        if (txtSubject.Text == "")
            eMail.Subject = "SkiChair.com Inquiry";
        else
            eMail.Subject = txtSubject.Text;
        eMail.Body = DateTime.Now + " - Contact us from SkiChair.com <br /><br />" + txtMessage.Text;
        eMail.From = new MailAddress(txtEmail.Text, txtName.Text);
        eMail.IsBodyHtml = true;

        SmtpClient smtp = new SmtpClient(ConfigurationManager.AppSettings["SMTPHost"]);
        smtp.Send(eMail);

        panelSendEmail.Visible = false;
        panelMailSent.Visible = true;
    }

}
