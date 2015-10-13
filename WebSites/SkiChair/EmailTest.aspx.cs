using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net;
using System.Net.Mail;

public partial class EmailTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnEmailTest_Click(object sender, EventArgs e)
    {
        /*
        MailMessage message = new MailMessage("jane@contoso.com","ben@contoso.com","Quarterly data report.","See the attached spreadsheet.");
        SmtpClient client = new SmtpClient(server);
        try
        {
            client.Send(message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception caught in CreateMessageWithAttachment(): {0}",
                        ex.ToString());
        }
        */

        MailMessage mail = new MailMessage("postmaster@skichair.com", "chad@skichair.com");
        SmtpClient client = new SmtpClient();
        client.Host = "mail.skichair.com";
        client.UseDefaultCredentials = false;

        NetworkCredential basicCredential = new NetworkCredential("postmaster@skichair.com", "PostM@ster10");
        client.Credentials = basicCredential;
        
        //client.Port = 25;
        //client.DeliveryMethod = SmtpDeliveryMethod.Network;
        
        mail.Subject = "This is a SkiChair Test Email.";
        mail.Body = "Test Email from SkiChair, hope this works...";
        try
        {
            client.Send(mail);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception caught in CreateMessageWithAttachment(): {0}", ex.ToString());
        }
    }


}
