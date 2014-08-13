using System;
using System.Collections.Generic;
using System.Data;

using SkiChair.Data.Entities;
using SkiChair.Shell;

namespace SkiChair.Merchandise
{
    public interface IMerchandiseController
    {
        //product entity methods
        List<Product> GetAllProducts();
        List<Product> GetCrossSellProduct(int productUID);

        //inventory entity methods
        List<Inventory> GetInventoryListByProductUID(int productUID, bool includeDisabled);
        Inventory GetInventoryByFlickrImageUID(string flickrImageUID);
        Inventory GetInventoryByInventoryUID(int inventoryUID);
        bool UpdateInventory(string flickrAuth, Inventory inventoryItem);
        bool DeleteInventory(string flickrAuth, Inventory inventoryItem);
        
        //photograph entity methods
        List<Photograph> GetPhotoInfoCollectionByProductType(Utility.SkiChairProduct productType);
        Photograph GetFlickrPhotographByImageUID(string inventoryUID);
        bool UploadPhotograph(string flickrAuth, Inventory productInventory, string fileLocation);

        //Flickr Service calls
        string GetFlickrFrobURL();
        string GetFlickrToken(string flickrFrob);

        //misc return values
        decimal GetShippingByProductUID(int productUID);
    }
}
