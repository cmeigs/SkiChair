using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;

using SkiChair.Data.Entities;

namespace SkiChair.Merchandise.Views
{
    public class ProductDisplayPresenter : Presenter<IProductDisplayView>
    {
        private IMerchandiseController _controller;
        public ProductDisplayPresenter([CreateNew] IMerchandiseController controller)
        {
        	_controller = controller;
        }

        public override void OnViewLoaded()
        {
            GetProductInventory();
        }

        public override void OnViewInitialized()
        {
            GetProductInventory();
        }

        public Photograph GetFlickrPhotographByImageUID(string inventoryUID)
        {
            return _controller.GetFlickrPhotographByImageUID(inventoryUID);
        }

        private void GetProductInventory()
        {
            View.ProductInventory = _controller.GetInventoryByFlickrImageUID(View.FlickrImageID);
            View.ProductInventory.PhotographInfo = GetFlickrPhotographByImageUID(View.FlickrImageID);
        }

        public decimal GetShippingByProductUID(int productUID)
        {
            return _controller.GetShippingByProductUID(productUID);
        }


    }
}




