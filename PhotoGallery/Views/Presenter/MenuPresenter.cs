using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;

namespace SkiChair.PhotoGallery.Views
{
    public class MenuPresenter : Presenter<IMenuView>
    {
        private IPhotoGalleryController _controller;
        public MenuPresenter([CreateNew] IPhotoGalleryController controller)
        {
        	_controller = controller;
        }

        public override void OnViewLoaded()
        {
        }

        public override void OnViewInitialized()
        {
            View.PhotoGalleryMenu = _controller.GetPhotoGalleryMenu();
        }

    }
}




