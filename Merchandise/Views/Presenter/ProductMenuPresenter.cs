using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;

using SkiChair.Shell;
using SkiChair.Data.Entities;

namespace SkiChair.Merchandise.Views
{
    public class ProductMenuPresenter : Presenter<IProductMenuView>
    {
        private IMerchandiseController _controller;
        public ProductMenuPresenter([CreateNew] IMerchandiseController controller)
        {
        	_controller = controller;
        }

        public override void OnViewLoaded()
        {
            View.ProductInventoryMenu = _controller.GetInventoryListByProductUID(View.ProductUID, false);
            View.PhotoInfoCollection = _controller.GetPhotoInfoCollectionByProductType((Utility.SkiChairProduct)View.ProductUID);
        }

        public override void OnViewInitialized()
        {
        }

        
        public List<Product> GetCrossSellProduct()
        {
            return _controller.GetCrossSellProduct(View.ProductUID);
        }
          
    }
}




