using System;
using Microsoft.Practices.ObjectBuilder;

namespace SkiChair.Shell.MasterPages
{
    public partial class SkiChairMaster : Microsoft.Practices.CompositeWeb.Web.UI.MasterPage, ISkiChairMasterView
    {
        private SkiChairMasterPresenter _presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();
            }
            _presenter.OnViewLoaded();
        }

        [CreateNew]
        public SkiChairMasterPresenter Presenter
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
