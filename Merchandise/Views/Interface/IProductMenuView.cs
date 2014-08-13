using System;
using System.Collections.Generic;
using System.Text;

using SkiChair.Data.Entities;

namespace SkiChair.Merchandise.Views
{
    public interface IProductMenuView
    {
        int ProductUID { get; }
        List<Inventory> ProductInventoryMenu { get; set; }
        List<Photograph> PhotoInfoCollection { get; set; }
    }
}




