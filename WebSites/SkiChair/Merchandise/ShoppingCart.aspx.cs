using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI;

using Microsoft.Practices.ObjectBuilder;

using SkiChair.Data.Entities;

namespace SkiChair.Merchandise.Views
{
    public partial class ShoppingCart : Microsoft.Practices.CompositeWeb.Web.UI.Page, IShoppingCartView
    {
        private ShoppingCartPresenter _presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();
                if (Session["ShoppingCart"] != null)
                {
                    btnCheckOut.Visible = true;
                    gvShoppingCart.DataSource = (List<Inventory>)Session["ShoppingCart"];
                    gvShoppingCart.DataBind();
                }
                else
                {
                    btnCheckOut.Visible = false;
                    lblFeedback.Text = "You do not have any items in your cart at this time";
                }
            }
            this._presenter.OnViewLoaded();
        }

        [CreateNew]
        public ShoppingCartPresenter Presenter
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


        /// <summary>
        /// this method is called when a row is deleted from the product list
        /// </summary>
        protected void gvShoppingCart_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            List<Inventory> inventoryList = (List<Inventory>)Session["ShoppingCart"];
            if (e.CommandName == "Delete")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                inventoryList.RemoveAt(index);

                if (inventoryList.Count == 0)
                    Session.Remove("ShoppingCart");
            }
            Response.Redirect("ShoppingCart.aspx");
        }


        protected void gvShoppingCart_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            bool hasOttoman = false;
            double price = 0.0;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label productLabel = (Label)e.Row.FindControl("lblProduct");
                Label priceLabel = (Label)e.Row.FindControl("lblPrice");

                productLabel.Text = DataBinder.Eval(e.Row.DataItem, "InventoryName").ToString();
                price = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Price"));

                hasOttoman = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "HasOttoman"));
                if (hasOttoman)
                {
                    productLabel.Text += " with Ottoman";
                    priceLabel.Text = (price + Convert.ToDouble(ConfigurationManager.AppSettings.Get("OttomanPrice"))).ToString("c");
                }
                else
                {
                    productLabel.Text += " with out Ottoman";
                    priceLabel.Text = price.ToString("c");
                }
            }
        }


    }
}

