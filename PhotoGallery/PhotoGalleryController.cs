using System;
using System.Collections.Generic;

using SkiChair.Data.Entities;
using SkiChair.FlickrMod;

namespace SkiChair.PhotoGallery
{
    public class PhotoGalleryController : IPhotoGalleryController
    {
        public FlickrService SkiChairFlickrService
        {
            get { return new FlickrService(); }
        }

        /// <summary>
        /// constructor
        /// </summary>
        public PhotoGalleryController()
        {
        }


        /// <summary>
        /// this method will get a list of all the photograph gallerys associated with ski chair
        /// </summary>
        /// <returns>generic list of type string</returns>
        public List<string> GetPhotoGalleryMenu()
        {
            return SkiChairFlickrService.GetPhotoGalleryMenu();
        }


        /// <summary>
        /// this method will retun the photoset title given its unique set ID
        /// </summary>
        /// <param name="setID">ID of the photo set in question</param>
        /// <returns>title of photoset</returns>
        public string GetPhotoSetTitle(string setID)
        {
            return SkiChairFlickrService.GetPhotoSetTitle(setID);
        }


        /// <summary>
        /// this method will get all photos in a photoset
        /// </summary>
        /// <param name="setID">ID of the photoset in question</param>
        /// <returns>generic list of type Photograph</returns>
        public List<Photograph> GetPhotoSetPhotoList(string setID)
        {
            return SkiChairFlickrService.GetPhotoSetPhotoListBySetID(setID);
        }


        /// <summary>
        /// this method will return photograph information and it context (previous/next thumbnail URLs) given its unique ID
        /// </summary>
        /// <param name="imageUID">ID of photo in question</param>
        /// <param name="setUID">ID of set there photo is located</param>
        /// <returns>Photograph Entity</returns>
        public Photograph GetPhotoInfoContextByImageID(string imageUID, string setUID)
        {
            return SkiChairFlickrService.GetFlickrPhotoContextByImageUID(imageUID, setUID);
        }


    }
}
