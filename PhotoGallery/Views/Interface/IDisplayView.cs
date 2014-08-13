using System;
using System.Collections.Generic;
using System.Text;

using SkiChair.Data.Entities;

namespace SkiChair.PhotoGallery.Views
{
    public interface IDisplayView
    {
        string SetUID { get; set; }
        string PhotoUID { get; set; }
        Photograph Photo { get; set; }
    }
}




