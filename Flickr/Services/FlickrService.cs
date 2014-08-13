using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Text;

using FlickrNet;

using SkiChair.Data.Entities;
using SkiChair.Data.Factories;
using SkiChair.Shell;

namespace SkiChair.FlickrMod
{
    public class FlickrService
    {
        FlickrNet.Flickr flickr;

        public FlickrService()
        {
            flickr = new FlickrNet.Flickr(Utility.FlickrAPIKey, Utility.FlickrSharedSecret);   
        }


        /// <summary>
        /// this method will get our Flickr Frob URL
        /// </summary>
        /// <returns></returns>
        public string GetFlickrFrobURL()
        {
            string auth_url = flickr.AuthCalcWebUrl(AuthLevel.Write);
            return auth_url;
        }


        /// <summary>
        /// this method will get our Flickr Token and return it as an object
        /// </summary>
        /// <param name="flickrFrob">string</param>
        /// <returns>Flickr Token as an Object</returns>
        public string GetFlickrToken(string flickrFrob)
        {
            try
            {
                Auth auth = flickr.AuthGetToken(flickrFrob);
                flickr.AuthToken = auth.Token;
                return auth.Token;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /*
        public bool SetFlickrAuthentication(string flickrAuth)
        {
            try
            {
                flickr.AuthToken = flickrAuth;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        */

        /// <summary>
        /// this method will populate a generic list of type photograph given a product ID
        /// </summary>
        /// <param name="productType"></param>
        /// <returns>Generic list of type Photograph</returns>
        public List<Photograph> GetFlickrPhotographListByProductType(Utility.SkiChairProduct productType)
        {
            try
            {
                List<Photograph> flickrImageInfoList = new List<Photograph>();

                PhotoSearchOptions searchOptions = new PhotoSearchOptions();
                //searchOptions.GroupId = Utility.FlickrGroupID;
                searchOptions.UserId = Utility.FlickrUserID;
                searchOptions.Extras = PhotoSearchExtras.Tags;
                searchOptions.Tags = productType.ToString();
                searchOptions.SortOrder = PhotoSearchSortOrder.DatePostedDescending;
                PhotoCollection photoCollection = flickr.PhotosSearch(searchOptions);

                foreach (Photo photo in photoCollection)
                    flickrImageInfoList.Add(new Photograph(photo.PhotoId, photo.ThumbnailUrl, photo.MediumUrl, photo.Title));

                return flickrImageInfoList;
            }
            catch (Exception ex)
            {
                System.IO.StreamWriter sw = System.IO.File.AppendText(ConfigurationManager.AppSettings["ErrorLogPath"].ToString() + "SkiChairErrorLogFile.txt");
                try
                {
                    string logLine = System.String.Format("{0:G}: {1}.", System.DateTime.Now, "Error: " + ex.Message);
                    sw.WriteLine(logLine);
                }
                finally
                {
                    sw.Close();
                }
                return null;
            }
        }


        /// <summary>
        /// this method will update flickr photograph information
        /// </summary>
        /// <param name="flickrAuth">authentication string</param>
        /// <param name="imageUID">image id</param>
        /// <param name="title">title of phtograph</param>
        /// <param name="description">description of photograph</param>
        /// <returns>true if success, false if error/fail</returns>
        public bool UpdatePhotographInfo(string flickrAuth, string imageUID, string title, string description)
        {
            try
            {
                flickr.AuthToken = flickrAuth;
                flickr.PhotosSetMeta(imageUID, title, description);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        /// <summary>
        /// this method will delete a flickr photograph given its id
        /// </summary>
        /// <param name="flickrAuth">authentication string</param>
        /// <param name="imageUID">id of image</param>
        /// <returns>true if success, false if error/fail</returns>
        public bool DeletePhotograph(string flickrAuth, string imageUID)
        {
            try
            {
                flickr.AuthToken = flickrAuth;
                flickr.PhotosDelete(imageUID);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        
        /// <summary>
        /// this method will select photograph information given its unique ID
        /// </summary>
        /// <param name="imageUID">unique ID of the photograph in question</param>
        /// <returns>Photograph Entity</returns>
        public Photograph GetFlickrPhotographByImageUID(string imageUID)
        {
            try
            {
                PhotoInfo imageInfo = flickr.PhotosGetInfo(imageUID);
                Photograph photo = new Photograph(imageUID, imageInfo.ThumbnailUrl, imageInfo.MediumUrl, imageInfo.Title);
                return photo;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// this method will get photograph info and context information (previous/next thumbnail URLs) given its unique image ID
        /// </summary>
        /// <param name="imageUID">unique ID of image</param>
        /// <param name="setUID">unique ID of set</param>
        /// <returns>Photograph Entity</returns>
        public Photograph GetFlickrPhotoContextByImageUID(string imageUID, string setUID)
        {
            try
            {
                Photograph photo = new Photograph();

                //HACK NOTE: for some reaon GetFlickrPhotographByImageUID wasn't working here so I decided to get the whole set
                List<Photograph> photoList = GetPhotoSetPhotoListBySetID(setUID);

                //get the correct photo out of the collection
                foreach (Photograph p in photoList)
                    if (p.ImageUID == imageUID)
                    {
                        //photo = GetFlickrPhotographByImageUID(imageUID);
                        photo = p;
                        break;
                    }
                    
                //add attributes to photo meta data
                Context photosetContext = flickr.PhotosetsGetContext(imageUID, setUID);
                if (photosetContext.PreviousPhoto.PhotoId != "0")
                {
                    photo.PreviousThumbnailURL = photosetContext.PreviousPhoto.ThumbnailUrl;
                    photo.PreviousImageUID = photosetContext.PreviousPhoto.PhotoId;
                }
                if (photosetContext.NextPhoto.PhotoId != "0")
                {
                    photo.NextThumbnailURL = photosetContext.NextPhoto.ThumbnailUrl;
                    photo.NextImageUID = photosetContext.NextPhoto.PhotoId;
                }
                return photo;
            }
            catch (Exception ex)
            {
                System.IO.StreamWriter sw = System.IO.File.AppendText(ConfigurationManager.AppSettings["ErrorLogPath"].ToString() + "SkiChairErrorLogFile.txt");
                try
                {
                    string logLine = System.String.Format("{0:G}: {1}.", System.DateTime.Now, "Error: " + ex.Message);
                    sw.WriteLine(logLine);
                }
                finally
                {
                    sw.Close();
                }
                return null;
            }
        }

        
        public string UploadPhotographToFlickr(string flickrAuth, string title, string description, string path, string tag)
        {
            try
            {
                flickr.AuthToken = flickrAuth;

                bool uploadAsPublic = true;

                string photoId = flickr.UploadPicture(ConfigurationManager.AppSettings["TempFileLocalPath"].ToString(), title, description, tag, uploadAsPublic, false, false);
                if (photoId != null && photoId != "")
                {
                    bool setFlag = false;

                    // Get list of users sets 
                    PhotosetCollection sets = flickr.PhotosetsGetList();

                    //add photo to appropriate skichair photoset
                    foreach (Photoset set in sets)
                        if (set.Title.Equals(tag))
                        {
                            setFlag = true;
                            //add the photo to that set
                            AddPhotoToPhotoset(set.PhotosetId, photoId);
                            break;
                        }

                    //if photoset didn't exist create it
                    if (!setFlag)
                    {
                        //create photoset and add photo to it
                        CreateFlickrPhotoSet(tag, photoId);
                        flickr.GroupsPoolsAdd(photoId, Utility.FlickrGroupID);
                    }

                    return photoId;
                }
                else
                    return "";
            }
            catch (Exception ex)
            {
                System.IO.StreamWriter sw = System.IO.File.AppendText(ConfigurationManager.AppSettings["ErrorLogPath"].ToString() + "SkiChairErrorLogFile.txt");
                try
                {
                    string logLine = System.String.Format("{0:G}: {1}.", System.DateTime.Now, "Error: " + ex.Message);
                    sw.WriteLine(logLine);
                }
                finally
                {
                    sw.Close();
                }
                return "";
            }
        }


        /// <summary>
        /// this method will create a flickr photoset and add the specified photo to it as well
        /// </summary>
        /// <param name="setName">the name of the new photoset to be created</param>
        /// <param name="photoId">the id of the primary photo in the new set</param>
        private void CreateFlickrPhotoSet(string setName, string photoId)
        {
            flickr.PhotosetsCreate(setName, photoId);
        }


        /// <summary>
        /// this method will add a given photograph to the specificed photoset
        /// </summary>
        /// <param name="photoSetId">ID of the photoset</param>
        /// <param name="photoId">ID of the photo</param>
        private void AddPhotoToPhotoset(string photoSetId, string photoId)
        {
            flickr.PhotosetsAddPhoto(photoSetId, photoId);
            flickr.GroupsPoolsAdd(photoId, Utility.FlickrGroupID);
        }

        
        /// <summary>
        /// this method will get a list of all the photograph gallerys associated with ski chair
        /// </summary>
        /// <returns>generic list of strings</returns>
        public List<string> GetPhotoGalleryMenu()
        {
            List<string> photoGalleryMenu = new List<string>();
            
            //will only select photographs for the signed in user
            PhotosetCollection photoSets = flickr.PhotosetsGetList(Utility.FlickrUserID);

            foreach (Photoset photoSet in photoSets)
            {
                photoGalleryMenu.Add(photoSet.Title + ":" + photoSet.PhotosetId);
            }

            return photoGalleryMenu;
        }


        /// <summary>
        /// this method will retun the photoset title given its unique set ID
        /// </summary>
        /// <param name="setID">ID of the photo set in question</param>
        /// <returns>title of photoset</returns>
        public string GetPhotoSetTitle(string setID)
        {
            try
            {
                Photoset ps = flickr.PhotosetsGetInfo(setID);
                return ps.Title;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// this method will get all photos belonging to a particular set given its unique set ID
        /// </summary>
        /// <param name="setID">ID of the photo set</param>
        /// <returns>Generic list of type Photograph</returns>
        public List<Photograph> GetPhotoSetPhotoListBySetID(string setID)
        {
            try
            {
                List<Photograph> photoList = new List<Photograph>();
                PhotosetPhotoCollection photos = flickr.PhotosetsGetPhotos(setID);

                foreach (Photo photo in photos)
                    photoList.Add(new Photograph(photo.PhotoId, photo.ThumbnailUrl, photo.MediumUrl, photo.Title));

                return photoList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
