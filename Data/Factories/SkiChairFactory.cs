using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using SkiChair.Data.Entities;

namespace SkiChair.Data.Factories
{
    public class SkiChairFactory
    {

        #region Single Entities

        #region CreateProduct
        /// <summary>
        /// this method will create an instance of the Product entity
        /// </summary>
        /// <param name="rdr">IDataReader</param>
        /// <returns>Product Entity</returns>
        public Product CreateProduct(IDataReader rdr)
        {
            Product prod = new Product();
            for (int i = 0; i < rdr.FieldCount; i++)
            {
                switch (rdr.GetName(i))
                {
                    case "ProductUID":
                        prod.ProductUID = rdr.GetInt32(rdr.GetOrdinal("ProductUID"));
                        break;
                    case "ProductName":
                        prod.ProductName = rdr.GetString(rdr.GetOrdinal("ProductName"));
                        break;
                    case "FlickrTagName":
                        prod.FlickrTagName = rdr.GetString(rdr.GetOrdinal("FlickrTagName"));
                        break;
                    case "CrossSellProductUID":
                        prod.CrossSellProductUID = rdr.GetInt32(rdr.GetOrdinal("CrossSellProductUID"));
                        break;
                }
            }
            return prod;
        } 
        #endregion

        #region CreateInventory
        /// <summary>
        /// this method will create an instance of the Inventory entity
        /// </summary>
        /// <param name="rdr">IDataReader</param>
        /// <returns>Inventory</returns>
        public Inventory CreateInventory(IDataReader rdr)
        {
            Inventory inv = new Inventory();
            for (int i = 0; i < rdr.FieldCount; i++)
            {
                switch (rdr.GetName(i))
                {
                    case "InventoryUID":
                        inv.InventoryUID = rdr.GetInt32(rdr.GetOrdinal("InventoryUID"));
                        break;
                    case "ProductUID":
                        inv.ProductUID = rdr.GetInt32(rdr.GetOrdinal("ProductUID"));
                        break;
                    case "InventoryName":
                        inv.InventoryName = rdr.GetString(rdr.GetOrdinal("InventoryName"));
                        break;
                    case "Description":
                        inv.Description = rdr.GetString(rdr.GetOrdinal("Description"));
                        break;
                    case "Price":
                        inv.Price = rdr.GetDecimal(rdr.GetOrdinal("Price"));
                        break;
                    case "CreateDate":
                        inv.CreateDate = rdr.GetDateTime(rdr.GetOrdinal("CreateDate"));
                        break;
                    case "FlickrImageUID":
                        inv.FlickrImageUID = rdr.GetString(rdr.GetOrdinal("FlickrImageUID"));
                        break;
                    case "IsActive":
                        inv.IsActive = rdr.GetBoolean(rdr.GetOrdinal("IsActive"));
                        break;
                    default:
                        break;
                }
            }
            return inv;
        }
        #endregion

        #region CreatePhotograph
        /*
        /// <summary>
        /// this method will create an instance of the Photograph entity
        /// </summary>
        /// <param name="rdr">IDataReader</param>
        /// <returns>Photograph</returns>
        public Photograph CreatePhotograph(IDataReader rdr)
        {
            Photograph photoInfo = new Photograph();
            for (int i = 0; i < rdr.FieldCount; i++)
            {
                switch (rdr.GetName(i))
                {
                    case "ImageUID":
                        photoInfo.ImageUID = rdr.GetString(rdr.GetOrdinal("InventoryUID"));
                        break;
                    case "ThumbnailURL":
                        photoInfo.ThumbnailURL = rdr.GetString(rdr.GetOrdinal("ThumbnailURL"));
                        break;
                    case "ImageURL":
                        photoInfo.ImageURL = rdr.GetString(rdr.GetOrdinal("ImageURL"));
                        break;
                    default:
                        break;
                }
            }
            return photoInfo;
        }
        */ 
        #endregion

        #endregion


        #region Nested Entities
        /*
        public Inventory CreateInventoryPhotograph(IDataReader rdr)
        {
            //create Computer entity
            Inventory inv = CreateInventory(rdr);

            //create instance of Package entity and add to Computer entity
            Photograph photo = CreatePhotograph(rdr);
            inv.PhotographInfo = photo;
            return inv;
        } 
        */
        #endregion
    }
}
