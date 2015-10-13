using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI;

using Microsoft.Practices.ObjectBuilder;

using SkiChair.Data.Entities;

namespace SkiChair.Merchandise.Views
{

    public partial class CheckOut : Microsoft.Practices.CompositeWeb.Web.UI.Page, ICheckOutView
    {
        private CheckOutPresenter _presenter;

        #region Properties
        public string ProductUID
        {
            get { return hiddenProductUID.Value; }
            set { hiddenProductUID.Value = value; }
        }
        public string InventoryUID
        {
            get { return hiddenInventoryUID.Value; }
            set { hiddenInventoryUID.Value = value; }
        }
        public Inventory ProductInventory { get; set; }
        public decimal TotalPrice { get; set; }
        public string InventoryText { get; set; }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InventoryText = "";
                
            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();

                //poulate state drop down lists
                PopulateStateDropDownList(ddlState);
            }
            this._presenter.OnViewLoaded();

            if (Session["ShoppingCart"] != null)
            {
                lblFeedback.Text = "";
                lblInventory.Text = "";
                foreach (Inventory inv in (List<Inventory>)Session["ShoppingCart"])
                {
                    InventoryText += (SkiChair.Shell.Utility.SkiChairProduct)inv.ProductUID + ": " + inv.InventoryName + ", ";
                    TotalPrice += inv.Price;

                    //if ottoman is part of order, add the price of it to total
                    if (inv.HasOttoman)
                        TotalPrice += Convert.ToDecimal(ConfigurationManager.AppSettings.Get("OttomanPrice"));
                }
                lblPrice.Text = TotalPrice.ToString("c");

                // set paypal session amount for processing within App_Code/paypalfunctions.cs
                decimal shipping = 0;
                decimal tax = 0;
                CalculateTaxShipping(ref shipping, ref tax);
                Session["payment_amt"] = TotalPrice;
                Session["shipping_amt"] = shipping;

                InventoryText = InventoryText.Substring(0, InventoryText.Length - 2); //drop last two digits of product string
                Session["product_description"] = InventoryText;

            }
            else
            {
                lblFeedback.Text = "Your shopping cart is empty, please choose a product before continuing";
                pnlPersonalInfoRequired.Visible = false;
                pnlOrderInfo.Visible = false;
                pnlPersonalInfo.Visible = false;
            }

            //add FirstData postbackurl to submit button from config file
            //btnSubmit.PostBackUrl = ConfigurationManager.AppSettings.Get("FirstDataURL");
            //btnSubmit.PostBackUrl = ConfigurationManager.AppSettings.Get("PayPalEndpointURL");
            //Response.Redirect("expresscheckout.aspx");

            //add store name to form for FirstData from config file
            //spanStoreName.InnerHtml = "<input type='hidden' name='storename' value='" + ConfigurationManager.AppSettings.Get("FirstDataStoreNumber") + "' />";

            lblInventory.Text = InventoryText;
        }


        [CreateNew]
        public CheckOutPresenter Presenter
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


        private void CalculateTaxShipping(ref decimal shipping, ref decimal tax)
        {
            decimal chargeTotal = 0;
            decimal subTotal = 0;
            //decimal tax = 0;
            //decimal shipping = 0;

            //calculate tax (only for MA)
            if (ddlState.SelectedValue == "MA")
            {
                decimal totalTaxPrice = 0;
                foreach (Inventory inv in (List<Inventory>)Session["ShoppingCart"])
                    totalTaxPrice += inv.Price;

                tax = totalTaxPrice * Convert.ToDecimal(ConfigurationManager.AppSettings.Get("MASalesTax"));
                chargeTotal += tax;
            }

            //calculate shipping and total price
            foreach (Inventory inv in (List<Inventory>)Session["ShoppingCart"])
            {
                // ***********************
                // WARNING: TOTAL HACK!!!
                // ***********************
                //  if inventory contains the word "plans" do not charge shipping
                if (!inv.InventoryName.ToLower().Contains("plans") && !inv.InventoryName.ToLower().Contains("screw"))
                    shipping += _presenter.GetShippingByProductUID(inv.ProductUID);
                
                chargeTotal += inv.Price;
                subTotal += inv.Price;

                //if ottoman is part of order, add the price of it to total
                if (inv.HasOttoman)
                {
                    chargeTotal += Convert.ToDecimal(ConfigurationManager.AppSettings.Get("OttomanPrice"));
                    subTotal += Convert.ToDecimal(ConfigurationManager.AppSettings.Get("OttomanPrice"));
                }
            }
            chargeTotal += shipping;

            //populate form data with new calcuations
            lblTax.Text = "$" + tax.ToString("N2");
            lblShipping.Text = "$" + shipping.ToString("N2");
            lblTotal.Text = "$" + chargeTotal.ToString("N2");
            
            spanChargeTotal.InnerHtml = "<input type='hidden' name='chargetotal' value='" + chargeTotal.ToString("N2") + "' />";
            spanSubChargeTotal.InnerHtml = "<input type='hidden' name='subtotal' value='" + subTotal.ToString("N2") + "' />";
            spanShipping.InnerHtml = "<input type='hidden' name='shipping' value='" + shipping.ToString("N2") + "' />";
            spanTax.InnerHtml = "<input type='hidden' name='tax' value='" + tax.ToString("N2") + "' />";

            //*****************************************************************************************
            // TESTING PURPOSES ONLY
            //*****************************************************************************************
            //spanChargeTotal.InnerHtml = "<input type='hidden' name='chargetotal' value='5' />";
            //spanSubChargeTotal.InnerHtml = "<input type='hidden' name='subtotal' value='3' />";
            //spanShipping.InnerHtml = "<input type='hidden' name='shipping' value='1' />";
            //spanTax.InnerHtml = "<input type='hidden' name='tax' value='1' />";
            //*****************************************************************************************
        }


        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal shipping = 0;
            decimal tax = 0;
            CalculateTaxShipping(ref shipping, ref tax);
            spanState.InnerHtml = "<input type='hidden' name='bstate' value='" + ddlState.SelectedValue.ToString() + "' />";
            litState.Text = ddlState.SelectedItem.Text;
            
            switch (ddlState.SelectedValue)
            {
                case "0":
                    pnlPersonalInfo.Visible = false;
                    pnlPersonalInfoRequired.Visible = false;
                    break;
                default:
                    pnlPersonalInfo.Visible = false;
                    pnlPersonalInfoRequired.Visible = true;
                    break;
            }
        }


        private void PopulateStateDropDownList(DropDownList ddl)
        {
            ddl.Items.Add(new ListItem(" -- Choose State -- ", "0"));
            ddl.Items.Add(new ListItem("Alabama", "AL"));
            ddl.Items.Add(new ListItem("Alaska", "AK"));
            ddl.Items.Add(new ListItem("Arizona", "AZ"));
            ddl.Items.Add(new ListItem("Arkansas", "AR"));
            ddl.Items.Add(new ListItem("California", "CA"));
            ddl.Items.Add(new ListItem("Colorado", "CO"));
            ddl.Items.Add(new ListItem("Connecticut", "CT"));
            ddl.Items.Add(new ListItem("District of Columbia", "DC"));
            ddl.Items.Add(new ListItem("Delaware", "DE"));
            ddl.Items.Add(new ListItem("Florida", "FL"));
            ddl.Items.Add(new ListItem("Georgia", "GA"));
            ddl.Items.Add(new ListItem("Hawaii", "HI"));
            ddl.Items.Add(new ListItem("Idaho", "ID"));
            ddl.Items.Add(new ListItem("Illinois", "IL"));
            ddl.Items.Add(new ListItem("Indiana", "IN"));
            ddl.Items.Add(new ListItem("Iowa", "IA"));
            ddl.Items.Add(new ListItem("Kansas", "KS"));
            ddl.Items.Add(new ListItem("Kentucky", "KY"));
            ddl.Items.Add(new ListItem("Louisiana", "LA"));
            ddl.Items.Add(new ListItem("Maine", "ME"));
            ddl.Items.Add(new ListItem("Maryland", "MD"));
            ddl.Items.Add(new ListItem("Massachusetts", "MA"));
            ddl.Items.Add(new ListItem("Michigan", "MI"));
            ddl.Items.Add(new ListItem("Minnesota", "MN"));
            ddl.Items.Add(new ListItem("Mississippi", "MS"));
            ddl.Items.Add(new ListItem("Missouri", "MO"));
            ddl.Items.Add(new ListItem("Montana", "MT"));
            ddl.Items.Add(new ListItem("Nebraska", "NE"));
            ddl.Items.Add(new ListItem("Nevada", "NV"));
            ddl.Items.Add(new ListItem("New Hampshire", "NH"));
            ddl.Items.Add(new ListItem("New Jersey", "NJ"));
            ddl.Items.Add(new ListItem("New Mexico", "NM"));
            ddl.Items.Add(new ListItem("New York", "NY"));
            ddl.Items.Add(new ListItem("North Carolina", "NC"));
            ddl.Items.Add(new ListItem("North Dakota", "ND"));
            ddl.Items.Add(new ListItem("Ohio", "OH"));
            ddl.Items.Add(new ListItem("Oklahoma", "OK"));
            ddl.Items.Add(new ListItem("Oregon", "OR"));
            ddl.Items.Add(new ListItem("Pennsylvania", "PA"));
            ddl.Items.Add(new ListItem("Rhode Island", "RI"));
            ddl.Items.Add(new ListItem("South Carolina", "SC"));
            ddl.Items.Add(new ListItem("South Dakota", "SD"));
            ddl.Items.Add(new ListItem("Tennessee", "TN"));
            ddl.Items.Add(new ListItem("Texas", "TX"));
            ddl.Items.Add(new ListItem("Utah", "UT"));
            ddl.Items.Add(new ListItem("Vermont", "VT"));
            ddl.Items.Add(new ListItem("Virginia", "VA"));
            ddl.Items.Add(new ListItem("Washington", "WA"));
            ddl.Items.Add(new ListItem("West Virginia", "WV"));
            ddl.Items.Add(new ListItem("Wisconsin", "WI"));
            ddl.Items.Add(new ListItem("Wyoming", "WY"));
        }


        protected void btnCheckout_OnClick(object sender, EventArgs e)
        {
            try
            {
                MailMessage eMail = new MailMessage();
                eMail.To.Add(ConfigurationManager.AppSettings["OrderFormEmail"]);
                eMail.From = new MailAddress("postmaster@skichair.com");
                eMail.Subject = "SkiChair.com Order";
                eMail.Body = DateTime.Now + "<br>" +
                    "Product(s): " + Session["product_description"] + "<br>" +
                    "Payment Amount: " + Session["payment_amt"] + "<br>" +
                    "Shipping Amount: " + Session["shipping_amt"] + "<br><br>" +
                    "Name: " + txtFullName.Text + "<br>" +
                    "Billing: " + txtAddress.Text + " " + txtCity.Text + " " + ddlState.Text + " " + txtZipCode.Text + "<br>" +
                    "Phone: " + txtPhone.Text + "<br>" +
                    "Email: " + txtEmail.Text + "<br>" +
                    "Notes/Shipping: " + txtComments.Text + "<br><br>" +
                    "Credit Card Number: " + txtCreditCardNumb.Text + "<br>" +
                    "Expiration Date: " + txtExpDate.Text + "<br>" +
                    "Billing Zip: " + txtZipCode.Text + "<br>" +
                    "CCV: " + txtCCV.Text;
                eMail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["SMTPHost"];
                smtp.UseDefaultCredentials = false;

                NetworkCredential basicCredential = new NetworkCredential("postmaster@skichair.com", "PostM@ster10");
                smtp.Credentials = basicCredential;

                try
                {
                    smtp.Send(eMail);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception caught in CreateMessageWithAttachment(): {0}", ex.ToString());
                }



                Response.Redirect("OrderSuccess.aspx");
            }
            catch (Exception ex)
            {

            }
        }


        protected void btnPersonalInfoSubmit_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            lblPersonalInfoFeedback.Text = "";

            if (string.IsNullOrEmpty(txtFullName.Text))
            {
                lblPersonalInfoFeedback.Text = "Name is a required field, please fill it out before continuing<br />";
                isValid = false;
            }
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                lblPersonalInfoFeedback.Text += "Address is a required field, please fill it out before continuing<br />";
                isValid = false;
            }
            if (string.IsNullOrEmpty(txtCity.Text))
            {    lblPersonalInfoFeedback.Text += "City is a required field, please fill it out before continuing<br />";
                isValid = false;
            }
            if (string.IsNullOrEmpty(txtZipCode.Text))
            {
                lblPersonalInfoFeedback.Text += "Zip Code is a required field, please fill it out before continuing<br />";
                isValid = false;
            }
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                lblPersonalInfoFeedback.Text += "Phone Number is a required field, please fill it out before continuing<br />";
                isValid = false;
            }
            if (string.IsNullOrEmpty(txtCreditCardNumb.Text))
            {
                lblPersonalInfoFeedback.Text += "Credit Card Number is a required field, please fill it out before continuing<br />";
                isValid = false;
            }
            if (string.IsNullOrEmpty(txtExpDate.Text))
            {
                lblPersonalInfoFeedback.Text += "Credit Card Expiration Date is a required field, please fill it out before continuing<br />";
                isValid = false;
            }
            if (string.IsNullOrEmpty(txtCCV.Text))
            {
                lblPersonalInfoFeedback.Text += "CCV is a required field, please fill it out before continuing<br />";
                isValid = false;
            }            
            
            //if form is valid, populate FirstData static hidden HTML controls
            if (isValid)
            {
                spanName.InnerHtml = "<input type='hidden' name='bname' value='" + txtFullName.Text + "' />";
                spanAddress.InnerHtml = "<input type='hidden' name='baddr1' value='" + txtAddress.Text + "' />";
                spanCity.InnerHtml = "<input type='hidden' name='bcity' value='" + txtCity.Text + "' />";
                spanZipCode.InnerHtml = "<input type='hidden' name='bzip' value='" + txtZipCode.Text + "' />";
                spanPhone.InnerHtml = "<input type='hidden' name='phone' value='" + txtPhone.Text + "' />";
                spanEmail.InnerHtml = "<input type='hidden' name='email' value='" + txtEmail.Text + "' />";
                spanComments.InnerHtml = "<input type='hidden' name='comments' value='" + InventoryText + ", User Comments: " + txtComments.Text + "' />";
                //spanCCNumb

                litName.Text = txtFullName.Text;
                litAddress.Text = txtAddress.Text;
                litCity.Text = txtCity.Text;
                litZipCode.Text = txtZipCode.Text;
                litPhone.Text = txtPhone.Text;
                litEmail.Text = txtEmail.Text;
                litComments.Text = txtComments.Text;
                litCCNumb.Text = txtCreditCardNumb.Text;
                litExpDate.Text = txtExpDate.Text;
                litCCV.Text = txtCCV.Text;

                pnlPersonalInfoRequired.Visible = false;
                pnlPersonalInfo.Visible = true;
            }
        }


        protected void btnEditInfo_Click(object sender, EventArgs e)
        {
            pnlPersonalInfo.Visible = false;
            pnlPersonalInfoRequired.Visible = true;
        }


    }
}