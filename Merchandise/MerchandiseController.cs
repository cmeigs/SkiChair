using System;
using System.Collections.Generic;
using System.Data;

using SkiChair.Data;
using SkiChair.Data.Entities;
using SkiChair.FlickrMod;
using SkiChair.Shell;

namespace SkiChair.Merchandise
{
    public class MerchandiseController : IMerchandiseController
    {
        public DataService SkiChairDataService
        {
            get { return new DataService(); }
        }

        public FlickrService SkiChairFlickrService
        {
            get { return new FlickrService(); }
        }


        public MerchandiseController()
        {
        }


        /// <summary>
        /// this method will return all SkiChair products
        /// </summary>
        /// <returns>DataSet containing products</returns>
        public List<Product> GetAllProducts()
        {
            return SkiChairDataService.GetAllProducts();
        }


        /// <summary>
        /// this method will get the product cross sell list of products given the specified product ID
        /// </summary>
        /// <param name="productUID">ID of the product to get the cross sell list for</param>
        /// <returns>Generic List of type Product</returns>
        public List<Product> GetCrossSellProduct(int productUID)
        {
            return SkiChairDataService.GetCrossSellProduct(productUID);
        }


        /// <summary>
        /// this method will select an inventory list given the unique product ID
        /// </summary>
        /// <param name="inventoryUID">unique inventory ID</param>
        /// <param name="includeDisabled">if true, it will return ALL inventory despite the value of IsActive </param>
        /// <returns>Generic list of type Inventory</returns>
        public List<Inventory> GetInventoryListByProductUID(int productUID, bool includeDisabled)
        {
            return SkiChairDataService.GetInventoryListByProductUID(productUID, includeDisabled);
        }


        /// <summary>
        /// this method will select inventory information given its unique Flickr Image ID
        /// </summary>
        /// <param name="flickrImageUID">Unique Flickr Image ID</param>
        /// <returns>Inventory Entity</returns>
        public Inventory GetInventoryByFlickrImageUID(string flickrImageUID)
        {
            return SkiChairDataService.GetInventoryByFlickrImageUID(flickrImageUID);
        }


        /// <summary>
        /// this method will select an inventory item given its unique inventory ID
        /// </summary>
        /// <param name="inventoryUID">ID of inventory item</param>
        /// <returns>Inventory Entity item</returns>
        public Inventory GetInventoryByInventoryUID(int inventoryUID)
        {
            return SkiChairDataService.GetInventoryByInventoryUID(inventoryUID);
        }


        /// <summary>
        /// this method will update an inventory item in the database
        /// </summary>
        /// <param name="inventoryItem">Inventory entity</param>
        /// <returns>true/false if successful</returns>
        public bool UpdateInventory(string flickrAuth, Inventory inventoryItem)
        {
            try
            {
                bool dataService = SkiChairDataService.UpdateInventory(inventoryItem);
                bool flickrService = SkiChairFlickrService.UpdatePhotographInfo(flickrAuth, inventoryItem.FlickrImageUID, inventoryItem.InventoryName, inventoryItem.Description);

                //we are only returning data service success because it is the most important, we don't "really" care about what Flickr respresents because the website display values are in our database
                return dataService;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        /// <summary>
        /// this method will delete an inventory item in the SkiChair database table
        /// </summary>
        /// <param name="inventoryItem">Inventory entity</param>
        /// <returns>true/false if successful</returns>
        public bool DeleteInventory(string flickrAuth, Inventory inventoryItem)
        {
            bool dataService =  SkiChairDataService.DeleteInventory(inventoryItem);
            bool flickrService = SkiChairFlickrService.DeletePhotograph(flickrAuth, inventoryItem.FlickrImageUID);

            //we are only returning data service success because it is the most important, we don't "really" care about what Flickr respresents because the website display values are in our database
            return dataService;
        }


        /// <summary>
        /// this method will get all photo information given a product id
        /// </summary>
        /// <param name="productType">ID of the product to select information from</param>
        /// <returns>Name value collection containing image information</returns>
        public List<Photograph> GetPhotoInfoCollectionByProductType(Utility.SkiChairProduct productType)
        {
            return SkiChairFlickrService.GetFlickrPhotographListByProductType(productType);
        }


        /// <summary>
        /// this method will get Flickr image information given its image ID
        /// </summary>
        /// <param name="inventoryUID">Flickr Image ID</param>
        /// <returns>Photograph Entity</returns>
        public Photograph GetFlickrPhotographByImageUID(string inventoryUID)
        {
            return SkiChairFlickrService.GetFlickrPhotographByImageUID(inventoryUID);
        }


        /// <summary>
        /// this method will upload a photograph to Flickr
        /// </summary>
        /// <param name="fileLocation">location of image to upload</param>
        /// <returns>string value of the Flickr image UID</returns>
        public string UploadPhotographToFlickr(string flickrAuth, string title, string description, string fileLocation, string tag)
        {
            return SkiChairFlickrService.UploadPhotographToFlickr(flickrAuth, title, description, fileLocation, tag);
        }


        /// <summary>
        /// this method will upload a given photograph to the Flickr API service 
        /// and will insert the appropriate photo information to the Inventory database table
        /// </summary>
        /// <param name="productInventory">Inventory Entity</param>
        /// <param name="fileLocation">location of photo to upload to flickr</param>
        /// <returns>Boolean</returns>
        public bool UploadPhotograph(string flickrAuth, Inventory productInventory, string fileLocation)
        {
            //upload photograph to Flickr
            string photoID = UploadPhotographToFlickr(flickrAuth, productInventory.InventoryName, productInventory.Description, fileLocation, ((Utility.SkiChairProduct)productInventory.ProductUID).ToString());

            if (photoID != null && photoID != "")
            {
                //add photograph information to database
                if (SkiChairDataService.InsertInventory(productInventory, photoID))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }


        /// <summary>
        /// this method will get the Flickr Frob
        /// </summary>
        /// <returns>string</returns>
        public string GetFlickrFrobURL()
        {
            return SkiChairFlickrService.GetFlickrFrobURL();
        }


        /// <summary>
        /// this method will get the Flickr Token string
        /// </summary>
        /// <param name="flickrFrob">string</param>
        /// <returns>string</returns>
        public string GetFlickrToken(string flickrFrob)
        {
            return SkiChairFlickrService.GetFlickrToken(flickrFrob);
        }


        /// <summary>
        /// this method will return shipping informtion for the given product UID
        /// </summary>
        public decimal GetShippingByProductUID(int productUID)
        {
            return SkiChairDataService.GetShippingByProductUID(productUID);
        }

    }
}
