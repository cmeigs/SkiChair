using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;

namespace SkiChair.Merchandise.Views
{
    public class OrderSuccessPresenter : Presenter<IOrderSuccessView>
    {
        private IMerchandiseController _controller;
        public OrderSuccessPresenter([CreateNew] IMerchandiseController controller)
        {
        	_controller = controller;
        }

        public override void OnViewLoaded()
        {
        }

        public override void OnViewInitialized()
        {
        }

    }
}




