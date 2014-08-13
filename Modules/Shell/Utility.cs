using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;


namespace SkiChair.Shell
{
    public class Utility
    {
        /// Public String Values
        //public static string someConfigString = System.Configuration.ConfigurationManager.AppSettings["AppSettingName"];

        #region Public Property Values
        public static string FlickrUserID
        {
            get { return ConfigurationManager.AppSettings.Get("FlickrUserId"); }
        }
        public static string FlickrGroupID
        {
            get { return ConfigurationManager.AppSettings.Get("FlickrGroupId"); }
        }    
        public static string FlickrAPIKey
        {
            get { return ConfigurationManager.AppSettings.Get("FlickrAPIKey"); }
        }
        public static string FlickrSharedSecret
        {
            get { return ConfigurationManager.AppSettings.Get("FlickrSharedSecret");}
        }
        #endregion

        /// <summary>
        /// Public Enum Types
        /// </summary>
        public enum SkiChairProduct
        {
            [Description("Snow Ski Chair")]
            SnowSkiChair = 1,
            [Description("Water Ski Chair")]
            WaterSkiChair = 2,
            [Description("Hockey Stick Chair")]
            HockeyStickChair = 3,
            [Description("Golf Club Chair")]
            GolfClubChair = 4,
            [Description("Wake Board Bench")]
            WakeBoardBench = 5,
            [Description("Snow Board Bench")]
            SnowBoardBench = 6,
            [Description("Skate Board Bench")]
            SkateBoardBench = 7,
            [Description("Snow Ski Bench")]
            SnowSkiBench = 8,
            [Description("Base Ball Bat Chair")]
            BaseBallBatChair = 9,
            [Description("Snow Board Chair")]
            SnowBoardChair = 10,
            [Description("Water Ski Bench")]
            WaterSkiBench = 11,
            [Description("Wake Board Chair")]
            WakeBoardChair = 12,
            [Description("Skate Board Chair")]
            SkateBoardChair = 13,
            [Description("Log Collection")]
            LogCollection = 14,
            [Description("Coat Rack")]
            CoatRack = 15,
            [Description("Wine Rack")]
            WineRack = 16,
            [Description("Children Chair")]
            ChildrenChair = 17,
            [Description("Snow Ski Current Inventory")]
            SnowSkiCurrentInventory = 18,
            [Description("Water Ski Current Inventory")]
            WaterSkiCurrentInventory = 19,
            [Description("Wake Board Current Inventory")]
            WakeBoardCurrentInventory = 20,
            [Description("Snow Board Current Inventory")]
            SnowBoardCurrentInventory = 21,
            [Description("Other Products")]
            OtherProducts = 22,
            [Description("Other Furniture")]
            OtherFurniture = 23,
            [Description("Shot Ski")]
            ShotSki = 24,
            [Description("Wood Kit")]
            WoodKit = 25,
            [Description("Bench Legs")]
            BenchLegs = 26,
            [Description("Sports Bottle Openers")]
            BottleOpeners = 27,
            [Description("Hockey Accessories")]
            HockeyAccessories = 28
        }


        /// <summary>
        /// this method will return the string value description of SkiChairProduct
        /// </summary>
        /// <param name="product">SkiChairProduct Enum</param>
        /// <returns>string value description of SkiChairProduct Enum</returns>
        public static string GetProductName(SkiChairProduct product)
        {
            switch (product)
            {
                case SkiChairProduct.SnowSkiChair:
                    return "Snow Ski Chair";
                case SkiChairProduct.SnowBoardChair:
                    return "Snow Board Chair";
                case SkiChairProduct.WaterSkiChair:
                    return "Water Ski Chair";
                case SkiChairProduct.HockeyStickChair:
                    return "Hockey Stick Chair";
                case SkiChairProduct.GolfClubChair:
                    return "Golf Club Chair";
                case SkiChairProduct.WakeBoardBench:
                    return "Wake Board Bench";
                case SkiChairProduct.SnowBoardBench:
                    return "Snow Board Bench";
                case SkiChairProduct.SkateBoardBench:
                    return "Skate Board Bench";
                case SkiChairProduct.SnowSkiBench:
                    return "Snow Ski Bench";
                case SkiChairProduct.BaseBallBatChair:
                    return "Base Ball Bat Chair";
                case SkiChairProduct.WaterSkiBench:
                    return "Water Ski Bench";
                case SkiChairProduct.WakeBoardChair:
                    return "Wake Board Chair";
                case SkiChairProduct.SkateBoardChair:
                    return "Skate Board Chair";
                case SkiChairProduct.LogCollection:
                    return "Log Collection";
                case SkiChairProduct.CoatRack:
                    return "Coat Rack";
                case SkiChairProduct.WineRack:
                    return "Wine Rack";
                case SkiChairProduct.ChildrenChair:
                    return "Children's Chair";
                case SkiChairProduct.SnowSkiCurrentInventory:
                    return "Snow Ski Current Inventory";
                case SkiChairProduct.WaterSkiCurrentInventory:
                    return "Water Ski Current Inventory";
                case SkiChairProduct.WakeBoardCurrentInventory:
                    return "Wake Board Current Inventory";
                case SkiChairProduct.SnowBoardCurrentInventory:
                    return "Snow Board Current Inventory";
                case SkiChairProduct.OtherProducts:
                    return "Other Products";
                case SkiChairProduct.OtherFurniture:
                    return "Other Furniture";
                case SkiChairProduct.ShotSki:
                    return "Shot Ski";
                case SkiChairProduct.WoodKit:
                    return "Wood Kit";
                case SkiChairProduct.BenchLegs:
                    return "Bench Legs";
                case SkiChairProduct.BottleOpeners:
                    return "Sports Bottle Openers";
                case SkiChairProduct.HockeyAccessories:
                    return "Hockey Accessories";
                default:
                    return "";
            }
        }


        /// <summary>
        /// this method will strip all characters from a text string that are not numeric
        /// </summary>
        public static string StripNonNumeric(string input)
        {
            Regex regEx = new Regex(@"[^0-9.]+");
            return regEx.Replace(input, "");
        }


        /// <summary>
        /// this method will strip all special characters from a text string but the ones specified in the RegEx
        /// </summary>
        public static string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, @"[^a-zA-Z0-9.!%:\r\n, $]+", "", RegexOptions.Compiled);
        }


    }
}
