using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;

namespace SkiChair.Merchandise.Views
{
    public class AdminMenuPresenter : Presenter<IAdminMenuView>
    {

        private IMerchandiseController _controller;
        public AdminMenuPresenter([CreateNew] IMerchandiseController controller)
        {
        	_controller = controller;
        }

        public override void OnViewLoaded()
        {
        }

        public override void OnViewInitialized()
        {
        }


        /// <summary>
        /// this method will get the Flickr Frob URL to redirect
        /// </summary>
        public string GetFlickrFrobURL()
        {
            return _controller.GetFlickrFrobURL();
        }


        public string GetFlickrToken(string flickrFrob)
        {
            return _controller.GetFlickrToken(flickrFrob);
        }


    }
}




