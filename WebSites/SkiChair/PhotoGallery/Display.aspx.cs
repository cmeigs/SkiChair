using System;

using Microsoft.Practices.ObjectBuilder;

using SkiChair.Data.Entities;

namespace SkiChair.PhotoGallery.Views
{
    public partial class Display : Microsoft.Practices.CompositeWeb.Web.UI.Page, IDisplayView
    {
        private DisplayPresenter _presenter;

        #region Properties
        private string _setuid;
        public string SetUID
        {
            get { return _setuid; }
            set { _setuid = value; }
        }
        private string _photouid;
        public string PhotoUID
        {
            get { return _photouid; }
            set { _photouid = value; }
        }
        private Photograph _photo;
        public Photograph Photo
        {
            get { return _photo; }
            set { _photo = value; }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();
            }

            //get querystring varaibles
            SetUID = Request.QueryString["sid"].ToString();
            PhotoUID = Request.QueryString["pid"].ToString();

            this._presenter.OnViewLoaded();

            if (Photo != null)
            {
                lblPhotoTitle.Text = Photo.Title;
                imgPhotograph.ImageUrl = Photo.ImageURL;

                if (Photo.PreviousImageUID != null)
                {
                    imgPreviousPhoto.Visible = true;
                    imgPreviousPhoto.ImageUrl = Photo.PreviousThumbnailURL;
                    imgPreviousPhoto.PostBackUrl = "Display.aspx?pid=" + Photo.PreviousImageUID + "&sid=" + SetUID;
                }
                else
                    imgPreviousPhoto.Visible = false;

                if (Photo.NextImageUID != null)
                {
                    imgNextPhoto.Visible = true;
                    imgNextPhoto.ImageUrl = Photo.NextThumbnailURL;
                    imgNextPhoto.PostBackUrl = "Display.aspx?pid=" + Photo.NextImageUID + "&sid=" + SetUID;
                }
                else
                    imgNextPhoto.Visible = false;
            }

        }

        [CreateNew]
        public DisplayPresenter Presenter
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

        // TODO: Forward events to the presenter and show state to the user.
        // For examples of this, see the View-Presenter (with Application Controller) QuickStart:
        //		ms-help://MS.VSCC.v80/MS.VSIPCC.v80/ms.practices.wcsf.2007oct/wcsf/html/08da6294-8a4e-46b2-8bbe-ec94c06f1c30.html

    }
}

