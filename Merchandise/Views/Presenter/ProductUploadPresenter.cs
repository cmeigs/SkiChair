using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;

using SkiChair.Data.Entities;

namespace SkiChair.Merchandise.Views
{
    public class ProductUploadPresenter : Presenter<IProductUploadView>
    {
        private IMerchandiseController _controller;
        public ProductUploadPresenter([CreateNew] IMerchandiseController controller)
        {
            _controller = controller;
        }

        public override void OnViewLoaded()
        {
        }

        public override void OnViewInitialized()
        {
        }

        /// <summary>
        /// this method will return all SkiChair products
        /// </summary>
        /// <returns>DataSet containing products</returns>
        public List<Product> GetAllProducts()
        {
            return _controller.GetAllProducts();
        }


        /// <summary>
        /// this method will upload our image and save it relevant information to the database
        /// </summary>
        /// <param name="fileLocation">local location of image to upload</param>
        /// <returns>boolean</returns>
        public bool UploadPhotograph(string flickrAuth, string fileLocation)
        {
            return _controller.UploadPhotograph(flickrAuth, View.ProductInventory, fileLocation);
        }



    }
}




