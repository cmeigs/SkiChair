using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;

namespace SkiChair.PhotoGallery.Views
{
    public class DisplayPresenter : Presenter<IDisplayView>
    {
        private IPhotoGalleryController _controller;
        public DisplayPresenter([CreateNew] IPhotoGalleryController controller)
        {
        	_controller = controller;
        }

        public override void OnViewLoaded()
        {
            View.Photo = _controller.GetPhotoInfoContextByImageID(View.PhotoUID, View.SetUID);
        }

        public override void OnViewInitialized()
        {
        }


    }
}




