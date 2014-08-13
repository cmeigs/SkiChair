using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;

using SkiChair.Data.Entities;

namespace SkiChair.Merchandise.Views
{
    public class ChooseProductPresenter : Presenter<IChooseProductView>
    {
        private IMerchandiseController _controller;
        public ChooseProductPresenter([CreateNew] IMerchandiseController controller)
        {
        	_controller = controller;
        }

        public override void OnViewLoaded()
        {
        }

        public override void OnViewInitialized()
        {
            View.ProductList = _controller.GetAllProducts();
        }


        public List<Inventory> GetInventoryListByProductUID(int productUID)
        {
            return _controller.GetInventoryListByProductUID(productUID, true);
        }


        public Inventory GetInventoryByInventoryUID(int inventoryUID)
        {
            return _controller.GetInventoryByInventoryUID(inventoryUID);
        }


        public bool UpdateInventory(string flickrAuth, Inventory inventoryItem)
        {
            return _controller.UpdateInventory(flickrAuth, inventoryItem);
        }


        public bool DeleteInventory(string flickrAuth, Inventory inventoryItem)
        {
            return _controller.DeleteInventory(flickrAuth, inventoryItem);
        }

    }
}




