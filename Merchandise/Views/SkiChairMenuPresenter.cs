using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;

using SkiChair.Data.Entities;

namespace SkiChair.Merchandise
{
    public class SkiChairMenuPresenter : Presenter<Views.ISkiChairMenuView>
    {
        /*
        private IMerchandiseController _controller;
        public SkiChairMenuPresenter([CreateNew] IMerchandiseController controller)
        {
        	_controller = controller;
        }
        */

        public override void OnViewLoaded()
        {
            // TODO: Implement code that will be executed every time the view loads
        }

        public override void OnViewInitialized()
        {
            //List<Product> productList = _controller.GetAllProducts();
            //View.FurnitureRepeaterDataSet = null;
        }

        // TODO: Handle other view events and set state in the view
    }
}




