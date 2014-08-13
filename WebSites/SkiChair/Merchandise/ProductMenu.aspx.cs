using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web;

using Microsoft.Practices.ObjectBuilder;

using SkiChair.Data.Entities;
using SkiChair.Flickr;
using SkiChair.Shell;

namespace SkiChair.Merchandise.Views
{
    public partial class ProductMenu : Microsoft.Practices.CompositeWeb.Web.UI.Page, IProductMenuView
    {
        private ProductMenuPresenter _presenter;
        protected int counter = 0;
        protected int columnCount = 3;

        #region Properties
        public int ProductUID
        {
            get
            {
                if (Request.QueryString["pid"] != null && Request.QueryString["pid"].ToString() != "")
                    return Convert.ToInt16(Request.QueryString["pid"]);
                else
                    return 0;
            }
        }
        private List<Inventory> _productinventorymenu;
        public List<Inventory> ProductInventoryMenu
        {
            get { return _productinventorymenu; }
            set { _productinventorymenu = value; }
        }
        private List<Photograph> _photoinfocollection;
        public List<Photograph> PhotoInfoCollection
        {
            get { return _photoinfocollection; }
            set { _photoinfocollection = value; }
        }
        #endregion
        
        protected void Page_Load(object sender, EventArgs e)
        {
            lblFeedback.Text = "";

            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();
            }
            this._presenter.OnViewLoaded();

            //populate page title
            lblTitle.Text = Utility.GetProductName(((Utility.SkiChairProduct)ProductUID));

            if (ProductInventoryMenu != null && ProductInventoryMenu.Count > 0)
            {
                rptProductMenu.Visible = true;
                rptProductMenu.DataSource = ProductInventoryMenu;
                rptProductMenu.DataBind();
            }
            else
            {
                rptProductMenu.Visible = false;
                lblFeedback.Text = Utility.GetProductName(((Utility.SkiChairProduct)ProductUID)) + " is not available at this time, please try back again soon";
            }

            //populae the cross sell repeter in the master page
            Master.CrossSellRepeater = _presenter.GetCrossSellProduct();

            //display current inventory button if we have a product that has current inventory
            DisplayCurrentInventoryButton();
        }

        [CreateNew]
        public ProductMenuPresenter Presenter
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
        /// repeater control item data bound, will populate inventory information
        /// </summary>
        protected void rptProductMenu_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
        {
            //do not show the separator item until we want a new row of the table
            if (e.Item.ItemType == ListItemType.Separator)
                if ((++counter % columnCount) != 0)
                    e.Item.Visible = false;

            //show product item info
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string flickrImageUID = ((HiddenField)e.Item.FindControl("hiddenFlickrImageUID")).Value;
                foreach (Photograph photo in PhotoInfoCollection)
                    if (photo.ImageUID == flickrImageUID)
                    {
                        ImageButton productDisplay = (ImageButton)e.Item.FindControl("lnkbtnProductDisplay");
                        productDisplay.PostBackUrl = "ProductDisplay.aspx?pid=" + ProductUID + "&fkrid=" + photo.ImageUID;
                        productDisplay.ImageUrl = photo.ThumbnailURL;
                        break;
                    }
            }
        }


        //display current inventory button if we have a product that has current inventory
        private void DisplayCurrentInventoryButton()
        { 
            if (ProductUID == (int)Utility.SkiChairProduct.SnowSkiChair ||
                ProductUID == (int)Utility.SkiChairProduct.SnowSkiBench ||
                ProductUID == (int)Utility.SkiChairProduct.WaterSkiChair ||
                ProductUID == (int)Utility.SkiChairProduct.WaterSkiBench ||
                ProductUID == (int)Utility.SkiChairProduct.WakeBoardChair ||
                ProductUID == (int)Utility.SkiChairProduct.WakeBoardBench ||
                ProductUID == (int)Utility.SkiChairProduct.SnowBoardChair ||
                ProductUID == (int)Utility.SkiChairProduct.SnowBoardBench)
            {
                btnCurrentInventory.Visible = true;
                switch (ProductUID)
                {
                    case (int)Utility.SkiChairProduct.SnowSkiChair:
                    case (int)Utility.SkiChairProduct.SnowSkiBench:
                        btnCurrentInventory.PostBackUrl = "ProductMenu.aspx?pid=" + (int)Utility.SkiChairProduct.SnowSkiCurrentInventory;
                        break;
                    case (int)Utility.SkiChairProduct.WaterSkiChair:
                    case (int)Utility.SkiChairProduct.WaterSkiBench:
                        btnCurrentInventory.PostBackUrl = "ProductMenu.aspx?pid=" + (int)Utility.SkiChairProduct.WaterSkiCurrentInventory;
                        break;
                    case (int)Utility.SkiChairProduct.WakeBoardChair:
                    case (int)Utility.SkiChairProduct.WakeBoardBench:
                        btnCurrentInventory.PostBackUrl = "ProductMenu.aspx?pid=" + (int)Utility.SkiChairProduct.WakeBoardCurrentInventory;
                        break;
                    case (int)Utility.SkiChairProduct.SnowBoardChair:
                    case (int)Utility.SkiChairProduct.SnowBoardBench:
                        btnCurrentInventory.PostBackUrl = "ProductMenu.aspx?pid=" + (int)Utility.SkiChairProduct.SnowBoardCurrentInventory;
                        break;
                }
            }
            else
                btnCurrentInventory.Visible = false;
        }

    }
}

