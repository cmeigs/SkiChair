using System;
using System.Collections.Generic;

using Microsoft.Practices.ObjectBuilder;

using SkiChair.Data.Entities;
using SkiChair.Shell;

namespace SkiChair.Merchandise.Views
{
    public partial class ChooseProduct : Microsoft.Practices.CompositeWeb.Web.UI.Page, IChooseProductView
    {
        private ChooseProductPresenter _presenter;

        #region Properties
        private List<Product> _productlist;
        public List<Product> ProductList
        {
            get { return _productlist; }
            set { _productlist = value; }
        }
        public string FeedbackLabel
        {
            set { lblFeedback.Text = value; }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            FeedbackLabel = "";
            lblNoInventory.Text = "";

            //are we authenticated?
            if (Cache["FlickrAuth"] == null || Cache["FlickrAuth"].ToString() == "")
                Response.Redirect("AdminMenu.aspx");

            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();

                PopulateProductDropDownList();
            }
            this._presenter.OnViewLoaded();
        }

        [CreateNew]
        public ChooseProductPresenter Presenter
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
        /// this method will populate a drop down list with the available products
        /// </summary>
        private void PopulateProductDropDownList()
        {
            ProductList.Insert(0, new Product(0, " -- Select Product -- ", "", 0));
            ddlProduct.DataSource = ProductList;
            ddlProduct.DataValueField = "ProductUID";
            ddlProduct.DataTextField = "ProductName";
            ddlProduct.DataBind();
        }


        /// <summary>
        /// this method will populate a drop down list containing product inventory
        /// </summary>
        /// <param name="productUID">ID of the product to display its inventory</param>
        private void PopulateInventoryDropDownList(int productUID)
        {
            List<Inventory> inventoryList = _presenter.GetInventoryListByProductUID(productUID);

            if (inventoryList.Count > 0)
            {
                inventoryList.Insert(0, new Inventory(0, 0, " -- Select Inventory -- ", "", 0, DateTime.Now.Date, "", true));
                ddlInventory.DataSource = inventoryList;
                ddlInventory.DataValueField = "InventoryUID";
                ddlInventory.DataTextField = "InventoryName";
                ddlInventory.DataBind();
                ddlInventory.Visible = true;
            }
            else
                lblNoInventory.Text = Utility.GetProductName((Utility.SkiChairProduct)productUID) + " contains no inventory at this time, click <a href='ProductUpload.aspx'>here</a> to add inventory";
        }


        /// <summary>
        /// this method will populate the inventory information table
        /// </summary>
        /// <param name="inventoryUID"></param>
        private void PopulateInventoryInformation(int inventoryUID)
        {
            Inventory inventoryItem = _presenter.GetInventoryByInventoryUID(inventoryUID);

            txtInventoryUID.Value = inventoryItem.InventoryUID.ToString();
            txtFlickrImageUID.Value = inventoryItem.FlickrImageUID;

            txtInventoryName.Text = inventoryItem.InventoryName;
            txtDescription.Text = inventoryItem.Description;
            txtPrice.Text = inventoryItem.Price.ToString();
            rdoIsActive.SelectedValue = (inventoryItem.IsActive) ? "1" : "0";

            pnlInventory.Visible = true;
        }


        /// <summary>
        /// this method will handle product drop down list changing values
        /// </summary>
        protected void ddlProduct_SelectedIndexChanged(Object sender, EventArgs e)
        {
            ddlInventory.Visible = false;
            pnlInventory.Visible = false;

            int selectedProductIndex = Convert.ToInt16(ddlProduct.SelectedValue);
            if (selectedProductIndex != 0)
                PopulateInventoryDropDownList(selectedProductIndex);
            else
                FeedbackLabel = "You must choose a product before continuing<br /><br />";
        }


        /// <summary>
        /// this method will handle inventory drop down list changing values
        /// </summary>
        protected void ddlInventory_SelectedIndexChanged(Object sender, EventArgs e)
        {
            pnlInventory.Visible = false;

            int selectedInventoryIndex = Convert.ToInt32(ddlInventory.SelectedValue);
            if (selectedInventoryIndex != 0)
                PopulateInventoryInformation(selectedInventoryIndex);
            else
                FeedbackLabel = "You must choose an inventory item before continuing<br /><br />";

        }


        protected void btnUpdate_Click(Object sender, EventArgs e)
        {
            Inventory inventoryItem = new Inventory(Convert.ToInt32(txtInventoryUID.Value), Convert.ToInt32(ddlProduct.SelectedValue), txtInventoryName.Text, Utility.RemoveSpecialCharacters(txtDescription.Text), Convert.ToDecimal(txtPrice.Text), DateTime.Now.Date, txtFlickrImageUID.Value, (rdoIsActive.SelectedValue == "1") ? true : false);
            if (_presenter.UpdateInventory(Cache["FlickrAuth"].ToString(), inventoryItem))
            {
                FeedbackLabel = "Inventory Successfully Updated<br /><br />";
                ddlProduct.SelectedIndex = 0;
                ddlInventory.Visible = false;
                pnlInventory.Visible = false;
            }
            else
                FeedbackLabel = "Error Updating Inventory, Please Try Again<br /><br />";
        }


        protected void btnDelete_Click(Object sender, EventArgs e)
        {
            ModalPopupDeleteConfirmation.Show();
        }

        protected void btnConfirm_Click(Object sender, EventArgs e)
        {
            Inventory inventoryItem = new Inventory(Convert.ToInt32(txtInventoryUID.Value), Convert.ToInt32(ddlProduct.SelectedValue), txtInventoryName.Text, txtDescription.Text, Convert.ToDecimal(txtPrice.Text), DateTime.Now.Date, "", (rdoIsActive.SelectedValue == "1") ? true : false);
            if (_presenter.DeleteInventory(Cache["FlickrAuth"].ToString(), inventoryItem))
            {
                FeedbackLabel = "Inventory Successfully Deleted<br /><br />";
                ddlProduct.SelectedIndex = 0;
                ddlInventory.Visible = false;
                pnlInventory.Visible = false;
            }
            else
                FeedbackLabel = "Error Deleting Inventory, Please Try Again<br /><br />";
        }

    
    }
}

