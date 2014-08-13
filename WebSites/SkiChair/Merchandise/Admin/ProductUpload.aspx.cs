using System;
using System.Text;
using System.Web;

using Microsoft.Practices.ObjectBuilder;

using SkiChair.Data.Entities;
using SkiChair.Shell;

namespace SkiChair.Merchandise.Views
{
    public partial class ProductUpload : Microsoft.Practices.CompositeWeb.Web.UI.Page, IProductUploadView
    {
        private ProductUploadPresenter _presenter;

        #region Properties
        private Inventory _productinventory;
        public Inventory ProductInventory
        {
            get { return _productinventory; }
            set { _productinventory = value; }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //are we authenticated?
            if (Cache["FlickrAuth"] == null || Cache["FlickrAuth"].ToString() == "")
                Response.Redirect("AdminMenu.aspx");

            if (!this.IsPostBack)
            {           
                this._presenter.OnViewInitialized();

                //populate product drop down list
                ddlProductType.DataSource = _presenter.GetAllProducts();
                ddlProductType.DataTextField = "ProductName";
                ddlProductType.DataValueField = "ProductUID";
                ddlProductType.DataBind();
            }
            this._presenter.OnViewLoaded();

        }

        [CreateNew]
        public ProductUploadPresenter Presenter
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
        /// this method will handle the upload button click
        /// </summary>
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string fileLocation = "";
            if (ProductInventory == null) ProductInventory = new Inventory();

            if (btnFileUpload.HasFile)
            {
                btnFileUpload.SaveAs(System.Configuration.ConfigurationManager.AppSettings["TempFileLocalPath"].ToString());

                ProductInventory.InventoryName = txtProductName.Text.Trim();
                ProductInventory.Price = Convert.ToDecimal(Utility.StripNonNumeric(txtProductPrice.Text.Trim()));
                ProductInventory.ProductUID = Convert.ToInt32(ddlProductType.SelectedValue);
                ProductInventory.Description = Utility.RemoveSpecialCharacters(txtProductDescription.Text.Trim());

                fileLocation = btnFileUpload.PostedFile.FileName.Trim();

                if (_presenter.UploadPhotograph(Cache["FlickrAuth"].ToString(), fileLocation))
                    lblFeedback.Text = "Inventory successfully created";
                else
                    lblFeedback.Text = "Error creating inventory, please try again";
            }
            else
                lblFeedback.Text = "You need to select a file before uploading";
        }


    }
}

