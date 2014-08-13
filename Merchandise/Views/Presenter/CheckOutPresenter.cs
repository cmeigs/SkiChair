using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;

namespace SkiChair.Merchandise.Views
{
    public class CheckOutPresenter : Presenter<ICheckOutView>
    {
        private IMerchandiseController _controller;
        public CheckOutPresenter([CreateNew] IMerchandiseController controller)
        {
        	_controller = controller;
        }

        public override void OnViewLoaded()
        {
        }

        public override void OnViewInitialized()
        {
        }


        public decimal GetShippingByProductUID(int productUID)
        {
            return _controller.GetShippingByProductUID(productUID);
        }

    }
}




