using System;
using System.Collections.Generic;
using System.Text;

namespace SkiChair.Data.Entities
{
    [Serializable]
    public class Inventory
    {
        //constructor
        public Inventory()
        {
        }

        //overloaded constructor
        public Inventory(int inventoryUID, int productUID, string inventoryName, string description, decimal price, DateTime createDate, string flickrImageUID, bool isActive)
        {
            InventoryUID = inventoryUID;
            ProductUID = productUID;
            InventoryName = inventoryName;
            Description = description;
            Price = price;
            CreateDate = createDate;
            FlickrImageUID = flickrImageUID;
            IsActive = isActive;
        }

        private int _inventoryuid;
        private int _productuid;
        private string _inventoryname;
        private string _description;
        private decimal _price;
        private decimal _shipping;
        private DateTime _createdate;
        private string _flickrimageuid;
        private bool _isactive;
        private Photograph _photographinfo;
        private bool _hasottoman;

        public int InventoryUID
        {
            get { return _inventoryuid; }
            set { _inventoryuid = value; }
        }
        public int ProductUID
        {
            get { return _productuid; }
            set { _productuid = value; }
        }
        public string InventoryName
        {
            get { return _inventoryname; }
            set { _inventoryname = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public decimal Shipping
        {
            get { return _shipping; }
            set { _shipping = value; }
        }
        public DateTime CreateDate
        {
            get { return _createdate; }
            set { _createdate = value; }
        }
        public string FlickrImageUID
        {
            get { return _flickrimageuid; }
            set { _flickrimageuid = value; }
        }
        public bool IsActive
        {
            get { return _isactive; }
            set { _isactive = value; }
        }
        public Photograph PhotographInfo
        {
            get { return _photographinfo; }
            set { _photographinfo = value; }
        }
        public bool HasOttoman
        {
            get { return _hasottoman; }
            set { _hasottoman = value; }
        }
    }
}
