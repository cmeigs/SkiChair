using System;
using System.Web;

using Microsoft.Practices.ObjectBuilder;

namespace SkiChair.Merchandise.Views
{
    public partial class AdminMenu : Microsoft.Practices.CompositeWeb.Web.UI.Page, IAdminMenuView
    {
        private AdminMenuPresenter _presenter;

        #region Properties
        private string _flickrfrob;
        public string FlickrFrob
        {
            get { return _flickrfrob; }
            set { _flickrfrob = value; }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //is user authenticated?
            if (Cache["FlickrAuth"] == null || Cache["FlickrAuth"].ToString() == "")
            {
                if (HttpContext.Current.Request.QueryString["frob"] != null)
                    FlickrFrob = HttpContext.Current.Request.QueryString["frob"];

                if (FlickrFrob == null)
                    Response.Redirect(_presenter.GetFlickrFrobURL());
                else
                    Cache.Insert("FlickrAuth", _presenter.GetFlickrToken(FlickrFrob));
            }

            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();
            }
            this._presenter.OnViewLoaded();
        }

        [CreateNew]
        public AdminMenuPresenter Presenter
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


    }
}

