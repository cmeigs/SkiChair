using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using Microsoft.Practices.ObjectBuilder;

using SkiChair.Data.Entities;

namespace SkiChair.PhotoGallery.Views
{
    public partial class Set : Microsoft.Practices.CompositeWeb.Web.UI.Page, ISetView
    {
        private SetPresenter _presenter;

        #region Properties
        private string _setid;
        public string SetID
        {
            get { return _setid; }
            set { _setid = value; }
        }
        public string SetTitle
        {
            get { return lblSetTitle.Text; }
            set { lblSetTitle.Text = value; }
        }
        private List<Photograph> _photolist;
        public List<Photograph> PhotoList
        {
            get { return _photolist; }
            set { _photolist = value; }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                SetID = Request.QueryString["sid"].ToString();

                this._presenter.OnViewInitialized();
            }
            this._presenter.OnViewLoaded();

            rptPhotoSet.DataSource = PhotoList;
            rptPhotoSet.DataBind();
        }

        [CreateNew]
        public SetPresenter Presenter
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
        /// this method handles the repeater on item data bound
        /// </summary>
        protected void rptPhotoSet_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ImageButton photoImageButton = e.Item.FindControl("imgbtnPhoto") as ImageButton;
                photoImageButton.ImageUrl = PhotoList[e.Item.ItemIndex].ThumbnailURL;
                if (SetID == "72157627756803040")
                    //photoImageButton.PostBackUrl = "VideoDisplay.aspx?vid=" + PhotoList[e.Item.ItemIndex].ImageUID + "&sid=" + SetID;
                    photoImageButton.PostBackUrl = "http://www.flickr.com/photos/skichair/" + PhotoList[e.Item.ItemIndex].ImageUID + "/";
                else
                    photoImageButton.PostBackUrl = "Display.aspx?pid=" + PhotoList[e.Item.ItemIndex].ImageUID + "&sid=" + SetID;
                photoImageButton.AlternateText = PhotoList[e.Item.ItemIndex].Title;
            }
        }


    }
}

