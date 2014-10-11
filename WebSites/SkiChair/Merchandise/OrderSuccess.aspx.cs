using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Mail;

using Microsoft.Practices.ObjectBuilder;

using SkiChair.Data.Entities;

namespace SkiChair.Merchandise.Views
{
    public partial class OrderSuccess : Microsoft.Practices.CompositeWeb.Web.UI.Page, IOrderSuccessView
    {
        private OrderSuccessPresenter _presenter;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();
            }

            string inventoryText = "";
            if (Session["ShoppingCart"] != null)
                foreach (Inventory inv in (List<Inventory>)Session["ShoppingCart"])
                    inventoryText += inv.InventoryName + " ";

            lblInventory.Text = inventoryText;
            Session.Remove("ShoppingCart");

            CreateInventoryEmail(inventoryText);

            this._presenter.OnViewLoaded();
        }

        [CreateNew]
        public OrderSuccessPresenter Presenter
        {
            get
            {
                return this._presenter;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                this._presenter = value;
                this._presenter.View = this;
            }
        }


        private void CreateInventoryEmail(string inventoryText)
        {
            try
            {
                SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["SMTPHost"]);
                MailAddress from = new MailAddress("info@skichair.com");
                MailAddress to = new MailAddress(ConfigurationManager.AppSettings["OrderFormEmail"]);
                MailMessage message = new MailMessage(from, to);
                message.Body = "SkiChair Product Order " + DateTime.Now + Environment.NewLine + Environment.NewLine + inventoryText;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.Subject = "SkiChair Order";
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                client.Send(message);
            }
            catch
            {
            }
        }


    }
}

