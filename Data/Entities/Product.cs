using System;
using System.Text;

namespace SkiChair.Data.Entities
{
    [Serializable]
    public class Product
    {
        //constructor
        public Product()
        {
        }

        //overloaded constructor
        public Product(int productUID, string productName, string flickrTagName, int crossSellProductUID)
        {
            ProductUID = productUID;
            ProductName = productName;
            FlickrTagName = flickrTagName;
            CrossSellProductUID = crossSellProductUID;
        }

        private int _productuid;
        private string _productname;
        private string _flickrtagname;
        private int _crosssellproductuid;

        public int ProductUID
        {
            get { return _productuid; }
            set { _productuid = value; }
        }
        public string ProductName
        {
            get { return _productname; }
            set { _productname = value; }
        }
        public string FlickrTagName
        {
            get { return _flickrtagname; }
            set { _flickrtagname = value; }
        }
        public int CrossSellProductUID
        {
            get { return _crosssellproductuid; }
            set { _crosssellproductuid = value; }
        }

    }
}
