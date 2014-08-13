using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;

using SkiChair.Data.Entities;
using SkiChair.Data.Factories;

namespace SkiChair.Data
{
    public class DataService
    {
        static SqlDatabase database = new SqlDatabase(System.Configuration.ConfigurationManager.ConnectionStrings["PopWarnerConnectionString"].ConnectionString);
        static Database db = DatabaseFactory.CreateDatabase();
            

        /// <summary>
        /// this method will return all SkiChair products
        /// </summary>
        /// <returns>DataSet containing products</returns>
        public List<Product> GetAllProducts()
        {
            SkiChairFactory skiChairFactory = new SkiChairFactory();
            List<Product> productList = new List<Product>();

            string selectSQL = "SELECT * FROM SkiChair_Product";
            DbCommand cmd = db.GetSqlStringCommand(selectSQL);
            IDataReader rdr = database.ExecuteReader(cmd);

            while (rdr.Read())
                productList.Add(skiChairFactory.CreateProduct(rdr));

            return productList;
        }


        /// <summary>
        /// this method will get the product cross sell list of products given the specified product ID
        /// </summary>
        /// <param name="productUID">ID of the product to get the cross sell list for</param>
        /// <returns>Generic List of type Product</returns>
        public List<Product> GetCrossSellProduct(int productUID)
        {
            SkiChairFactory skiChairFactory = new SkiChairFactory();
            List<Product> productList = new List<Product>();

            string selectSQL = "SELECT CS.CrossSellProductUID, P.ProductName "
                                + "FROM SkiChair_CrossSell AS CS "
                                + "JOIN SkiChair_Product AS P ON CS.CrossSellProductUID = P.ProductUID "
                                + "WHERE CS.ProductUID = " + productUID;
            DbCommand cmd = db.GetSqlStringCommand(selectSQL);
            IDataReader rdr = database.ExecuteReader(cmd);

            while (rdr.Read())
                productList.Add(skiChairFactory.CreateProduct(rdr));
            return productList;
        }


        /// <summary>
        /// this method will select all active instances of a product inventory given its unique ID
        /// </summary>
        /// <param name="productUID">unique product ID</param>
        /// <param name="includeDisabled">if true, it will return ALL inventory despite the value of IsActive </param>
        /// <returns>Generic List of type Inventory</returns>
        public List<Inventory> GetInventoryListByProductUID(int productUID, bool includeDisabled)
        {
            SkiChairFactory skiChairFactory = new SkiChairFactory();
            List<Inventory> inventoryList = new List<Inventory>();

            string selectSQL;
            if (includeDisabled)
                selectSQL = "SELECT * FROM SkiChair_Inventory WHERE ProductUID = " + productUID + " ORDER BY CreateDate DESC";
            else
                selectSQL = "SELECT * FROM SkiChair_Inventory WHERE IsActive = 1 AND ProductUID = " + productUID + " ORDER BY CreateDate DESC";

            DbCommand cmd = db.GetSqlStringCommand(selectSQL);
            IDataReader rdr = database.ExecuteReader(cmd);
            
            while(rdr.Read())
                inventoryList.Add(skiChairFactory.CreateInventory(rdr));
            
            return inventoryList;
        }


        /// <summary>
        /// this method will select inventory information given its unique Flickr Image ID
        /// </summary>
        /// <param name="flickrImageUID">Unique Flickr Image ID</param>
        /// <returns>Inventory Entity</returns>
        public Inventory GetInventoryByFlickrImageUID(string flickrImageUID)
        {
            SkiChairFactory skiChairFactory = new SkiChairFactory();
            Inventory inven = new Inventory();

            string selectSQL = "SELECT * FROM SkiChair_Inventory WHERE FlickrImageUID = '" + flickrImageUID + "'";
            DbCommand cmd = db.GetSqlStringCommand(selectSQL);
            IDataReader rdr = database.ExecuteReader(cmd);

            while (rdr.Read())
                inven = skiChairFactory.CreateInventory(rdr);

            return inven;
        }


        /// <summary>
        /// this method will select an inventory item by its unique ID
        /// </summary>
        /// <param name="inventoryUID">ID if inventory item</param>
        /// <returns>Inventory Entity item</returns>
        public Inventory GetInventoryByInventoryUID(int inventoryUID)
        {
            SkiChairFactory skiChairFactory = new SkiChairFactory();
            Inventory inventoryItem = new Inventory();

            string selectSQL = "SELECT * FROM SkiChair_Inventory WHERE InventoryUID = " + inventoryUID;
            DbCommand cmd = db.GetSqlStringCommand(selectSQL);
            IDataReader rdr = database.ExecuteReader(cmd);

            while (rdr.Read())
                inventoryItem = skiChairFactory.CreateInventory(rdr);

            return inventoryItem;
        }


        /// <summary>
        /// this method will insert an inventory item into the database
        /// </summary>
        /// <param name="productInventory">Inventory Entity</param>
        /// <param name="flickrImageUID">flickr image id</param>
        /// <returns>true/false if successful</returns>
        public bool InsertInventory(Inventory productInventory, string flickrImageUID)
        {
            try
            {
                string insertSQL = "INSERT INTO SkiChair_Inventory (ProductUID, InventoryName, Description, Price, FlickrImageUID) " +
                    "VALUES (" + productInventory.ProductUID + ",'" + productInventory.InventoryName + "','" + productInventory.Description + "'," + productInventory.Price + ",'" + flickrImageUID + "')";
                DbCommand cmd = db.GetSqlStringCommand(insertSQL);
                database.ExecuteNonQuery(cmd);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }


        /// <summary>
        /// this method will update an inventory item in the database
        /// </summary>
        /// <param name="inventoryItem">Inventory entity</param>
        /// <returns>true/false if successful</returns>
        public bool UpdateInventory(Inventory inventoryItem)
        {
            try
            {
                string updateSQL = "UPDATE SkiChair_Inventory SET InventoryName='" + inventoryItem.InventoryName + 
                                    "', Description='" + inventoryItem.Description + 
                                    "', Price=" + inventoryItem.Price + 
                                    ", IsActive=" + Convert.ToInt16(inventoryItem.IsActive) + 
                                    " WHERE InventoryUID = " + inventoryItem.InventoryUID;
                DbCommand cmd = db.GetSqlStringCommand(updateSQL);
                database.ExecuteNonQuery(cmd);
                return true;
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
        public bool DeleteInventory(Inventory inventoryItem)
        {
            try
            {
                string deleteSQL = "DELETE SkiChair_Inventory WHERE InventoryUID = " + inventoryItem.InventoryUID;
                DbCommand cmd = db.GetSqlStringCommand(deleteSQL);
                database.ExecuteNonQuery(cmd);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        /// <summary>
        /// this method will return shipping informtion for the given product UID
        /// </summary>
        /// <param name="productUID">int</param>
        /// <returns>double</returns>
        public decimal GetShippingByProductUID(int productUID)
        {
            try
            {
                string selectSQL = "SELECT Shipping FROM SkiChair_Shipping WHERE ProductUID = " + productUID;
                DbCommand cmd = db.GetSqlStringCommand(selectSQL);
                IDataReader rdr = database.ExecuteReader(cmd);
                if (rdr.Read())
                    return rdr.GetDecimal(0);
                else
                    return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


    }
}
