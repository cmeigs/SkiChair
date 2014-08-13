using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using Microsoft.Practices.ObjectBuilder;

namespace SkiChair.PhotoGallery.Views
{
    public partial class Menu : Microsoft.Practices.CompositeWeb.Web.UI.UserControl, IMenuView
    {
        private MenuPresenter _presenter;


        #region Properties
        public List<string> PhotoGalleryMenu
        {
            set
            {
                rptMenu.DataSource = value;
                rptMenu.DataBind();
            }
        } 
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();
            }
            this._presenter.OnViewLoaded();
        }

        [CreateNew]
        public MenuPresenter Presenter
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
        /// this method is called when data is being bound to the repeater control
        /// </summary>
        protected void rptMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string menuItemString = e.Item.DataItem.ToString();
                Label lbl = (Label)e.Item.FindControl("lblMenuItem");
                lbl.Text = menuItemString;

                Button btn = (Button)e.Item.FindControl("btnMenuItem");
                btn.Text = menuItemString.Substring(0, menuItemString.IndexOf(":"));
                btn.PostBackUrl = "Set.aspx?sid=" + menuItemString.Substring(menuItemString.IndexOf(":") + 1);
            }
        }


    }
}

