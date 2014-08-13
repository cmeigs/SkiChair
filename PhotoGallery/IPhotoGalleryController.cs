using System;
using System.Collections.Generic;

using SkiChair.Data.Entities;

namespace SkiChair.PhotoGallery
{
    public interface IPhotoGalleryController
    {
        List<string> GetPhotoGalleryMenu();
        string GetPhotoSetTitle(string setID);
        List<Photograph> GetPhotoSetPhotoList(string setID);
        Photograph GetPhotoInfoContextByImageID(string imageUID, string setUID);
    }
}
