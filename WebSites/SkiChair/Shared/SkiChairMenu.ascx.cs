using System;
using System.Collections.Generic;
using System.Data;

using Microsoft.Practices.ObjectBuilder;

using SkiChair.Data.Entities;

namespace SkiChair.Merchandise.Views
{
    public partial class SkiChairMenu : Microsoft.Practices.CompositeWeb.Web.UI.UserControl //, ISkiChairMenuView
    {
        //private SkiChairMenuPresenter _presenter;

        /*
        public List<Product> FurnitureRepeaterDataSet
        {
            set
            {
                rptFurniture.DataSource = value;
                rptFurniture.DataBind();
            }
        }
        */

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Session["ShoppingCart"] != null)
                    lnkShippingCart.Text = "Shopping Cart (" + ((List<Inventory>)Session["ShoppingCart"]).Count + ")";

                //this._presenter.OnViewInitialized();
                //Shell.Controls.MenuItems menu = new SkiChair.Shell.Controls.MenuItems();
                 
            }
            //this._presenter.OnViewLoaded();
        }

        /*
        [CreateNew]
        public SkiChairMenuPresenter Presenter
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
        */
    
    }
}

