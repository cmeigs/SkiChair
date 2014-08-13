using System;
using System.Collections.Generic;
using System.Text;

namespace SkiChair.Data.Entities
{
    [Serializable]
    public class Photograph
    {
        private string _imageuid;
        private string _thumbnailurl;
        private string _imageurl;
        private string _title;
        private string _previousthumbnailurl;
        private string _previousimageuid;
        private string _nextthumbnailurl;
        private string _nextimageuid;

        public string ImageUID
        {
            get { return _imageuid; }
            set { _imageuid = value; }
        }
        public string ThumbnailURL
        {
            get { return _thumbnailurl; }
            set { _thumbnailurl = value; }
        }
        public string ImageURL
        {
            get { return _imageurl; }
            set { _imageurl = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string PreviousThumbnailURL
        {
            get { return _previousthumbnailurl; }
            set { _previousthumbnailurl = value; }
        }
        public string PreviousImageUID
        {
            get { return _previousimageuid; }
            set { _previousimageuid = value; }
        }
        public string NextThumbnailURL
        {
            get { return _nextthumbnailurl; }
            set { _nextthumbnailurl = value; }
        }
        public string NextImageUID
        {
            get { return _nextimageuid; }
            set { _nextimageuid = value; }
        }

        /// <summary>
        /// constructor
        /// </summary>
        public Photograph()
        {
        }


        /// <summary>
        /// overloaded constructor
        /// </summary>
        public Photograph(string imageUID, string thumbnailURL, string imageURL, string title)
        {
            ImageUID = imageUID;
            ThumbnailURL = thumbnailURL;
            ImageURL = imageURL;
            Title = title;
        }


        /// <summary>
        /// overloaded constructor including photograph context (previous and next URLs)
        /// </summary>
        public Photograph(string imageUID, string thumbnailURL, string imageURL, string title, string previousThumbnailURL, string nextThumbnailURL)
        {
            ImageUID = imageUID;
            ThumbnailURL = thumbnailURL;
            ImageURL = imageURL;
            Title = title;
            NextThumbnailURL = nextThumbnailURL;
            PreviousThumbnailURL = previousThumbnailURL;
        }


    }
}
