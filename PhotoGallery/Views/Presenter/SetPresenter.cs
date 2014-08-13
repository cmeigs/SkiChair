using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;

using SkiChair.Data.Entities;

namespace SkiChair.PhotoGallery.Views
{
    public class SetPresenter : Presenter<ISetView>
    {
        private IPhotoGalleryController _controller;
        public SetPresenter([CreateNew] IPhotoGalleryController controller)
        {
            _controller = controller;
        }

        public override void OnViewLoaded()
        {
            View.SetTitle = _controller.GetPhotoSetTitle(View.SetID);
            View.PhotoList = _controller.GetPhotoSetPhotoList(View.SetID);
        }

        public override void OnViewInitialized()
        {
        }


    
    }
}




