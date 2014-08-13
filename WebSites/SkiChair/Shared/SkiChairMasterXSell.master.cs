using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using Microsoft.Practices.ObjectBuilder;

using SkiChair.Data.Entities;

namespace SkiChair.Shell.MasterPages
{
    public partial class SkiChairMasterXSell : Microsoft.Practices.CompositeWeb.Web.UI.MasterPage, ISkiChairMasterView
    {
        private SkiChairMasterPresenter _presenter;

        #region Properties
        public List<Product> CrossSellRepeater
        {
            set
            {
                rptCrossSell.DataSource = value;
                rptCrossSell.DataBind();
            }
        }
        #endregion

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


        protected void btnWoodKitPlans_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~\Merchandise\WoodKitPlans.aspx");
        }


        protected void btnBenchLegs_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~\Merchandise\BenchLegs.aspx");
        }


        protected void rptCrossSell_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                int productUID = Convert.ToInt32(((HiddenField)e.Item.FindControl("lblCrossSellProductUID")).Value);
                //ImageButton lnkbtnRedirect = (ImageButton)e.Item.FindControl("btnCrossSell");
                LinkButton lnkbtnRedirect = (LinkButton)e.Item.FindControl("btnCrossSell");
                //Button lnkbtnRedirect = (Button)e.Item.FindControl("btnCrossSell");
    
                lnkbtnRedirect.PostBackUrl = "~/Merchandise/ProductMenu.aspx?pid=" + productUID;
                
                //depending on which product we have for cross sell, show a particuar image
                switch (productUID)
                {
                    case (int)Utility.SkiChairProduct.GolfClubChair:
                        lnkbtnRedirect.CssClass = "GolfButton";
                        break;

                    case (int)Utility.SkiChairProduct.HockeyStickChair:
                        lnkbtnRedirect.CssClass = "HockeyButton";
                        break;

                    case (int)Utility.SkiChairProduct.SkateBoardBench:
                    case (int)Utility.SkiChairProduct.SkateBoardChair:
                        lnkbtnRedirect.CssClass = "SkateBoardButton";
                        break;
                    
                    case (int)Utility.SkiChairProduct.SnowSkiChair:
                    case (int)Utility.SkiChairProduct.BaseBallBatChair:
                    case (int)Utility.SkiChairProduct.LogCollection:
                    case (int)Utility.SkiChairProduct.ChildrenChair:
                    default:
                        lnkbtnRedirect.CssClass = "SnowSkiChairButton";
                        break;

                    case (int)Utility.SkiChairProduct.SnowSkiBench:
                        lnkbtnRedirect.CssClass = "SnowSkiBenchButton";
                        break;

                    case (int)Utility.SkiChairProduct.CoatRack:
                        lnkbtnRedirect.CssClass = "CoatRackButton";
                        break;

                    case (int)Utility.SkiChairProduct.SnowBoardBench:
                        lnkbtnRedirect.CssClass = "SnowBoardBenchButton";
                        break;

                    case (int)Utility.SkiChairProduct.SnowBoardChair:
                        lnkbtnRedirect.CssClass = "SnowBoardChairButton";
                        break;

                    case (int)Utility.SkiChairProduct.WaterSkiChair:
                        lnkbtnRedirect.CssClass = "WaterSkiChairButton";
                        break;

                    case (int)Utility.SkiChairProduct.WaterSkiBench:
                        lnkbtnRedirect.CssClass = "WaterSkiBenchButton";
                        break;

                    case (int)Utility.SkiChairProduct.WakeBoardBench:
                        lnkbtnRedirect.CssClass = "WakeBoardBenchButton";
                        break;

                    case (int)Utility.SkiChairProduct.WakeBoardChair:
                        lnkbtnRedirect.CssClass = "WakeBoardChairButton";
                        break;

                    case (int)Utility.SkiChairProduct.WineRack:
                        lnkbtnRedirect.CssClass = "WineButton";
                        break;
                }
            }
        }


    }
}
