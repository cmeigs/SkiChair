using System;
using System.Collections.Generic;
using Microsoft.Practices.ObjectBuilder;

using SkiChair.Shell;
using SkiChair.Data.Entities;

namespace SkiChair.Merchandise.Views
{
    public partial class ProductDisplay : Microsoft.Practices.CompositeWeb.Web.UI.Page, IProductDisplayView
    {
        private ProductDisplayPresenter _presenter;

        #region Properties
        public int ProductUID
        {
            get
            {
                if (Request.QueryString["pid"] != null && Request.QueryString["pid"].ToString() != "")
                    return Convert.ToInt16(Request.QueryString["pid"]);
                else
                    return 1;
            }
        }
        public string InventoryUID
        {
            get { return hiddenInventoryUID.Value; }
            set { hiddenInventoryUID.Value = value;}
        }
        public string FlickrImageID
        {
            get
            {
                if (Request.QueryString["fkrid"] != null && Request.QueryString["fkrid"].ToString() != "")
                    return Request.QueryString["fkrid"].ToString();
                else
                    return "";
            }
        }
        private Inventory _productinventory;
        public Inventory ProductInventory
        {
            get { return _productinventory; }
            set { _productinventory = value; }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();

                lblTitle.Text = Utility.GetProductName(((Utility.SkiChairProduct)ProductUID));

                lblInventoryTitle.Text = ProductInventory.InventoryName;
                imgInventory.ImageUrl = ProductInventory.PhotographInfo.ImageURL;
                litInventoryDescription.Text = ProductInventory.Description.Replace("\r\n", "<br>");
                InventoryUID = ProductInventory.InventoryUID.ToString();

                //if product is considered "Current Inventory" do not show "add to shopping" cart button
                if (ProductUID == Convert.ToInt32(Utility.SkiChairProduct.SnowSkiCurrentInventory) ||
                        ProductUID == Convert.ToInt32(Utility.SkiChairProduct.WaterSkiCurrentInventory) ||
                        ProductUID == Convert.ToInt32(Utility.SkiChairProduct.WakeBoardCurrentInventory) ||
                        ProductUID == Convert.ToInt32(Utility.SkiChairProduct.SnowBoardCurrentInventory))
                    btnShoppingCart.Visible = false;

                //if we have a chair, include ottoman button
                chkOttoman.Visible = (Utility.GetProductName((Utility.SkiChairProduct)ProductUID).ToLower().Contains("chair")) ? true : false;

                //if we have a product in the shopping cart, display checkout button
                btnCheckout.Visible = (Session["ShoppingCart"] != null) ? true : false;
            }
            this._presenter.OnViewLoaded();
        }

        [CreateNew]
        public ProductDisplayPresenter Presenter
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

        
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductMenu.aspx?pid=" + ProductUID);
        }


        /// <summary>
        /// this method will build our product inventory list and add it to session
        /// </summary>
        protected void btnShoppingCart_Click(object sender, EventArgs e)
        {
            List<Inventory> inventoryList = new List<Inventory>();

            //if chair includes ottoman, specify in Inventory object
            ProductInventory.HasOttoman = (chkOttoman.Checked) ? true : false;

            if (Session["ShoppingCart"] == null)
            {
                inventoryList.Add(ProductInventory);
            }
            else
            {
                List<Inventory> sessionList = (List<Inventory>)Session["ShoppingCart"];
                foreach (Inventory inv in sessionList)
                    inventoryList.Add(inv);
                inventoryList.Add(ProductInventory);
            }
            Session.Add("ShoppingCart", inventoryList);
            lblShoppingCart.Text = "Added to Cart";
            btnCheckout.Visible = true;
            //Response.Redirect("ProductDisplay.aspx?pid=" + ProductUID + "&fkrid=" + FlickrImageID);
        }


    }
}

