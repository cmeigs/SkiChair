using System;
using System.Collections.Generic;
using System.Text;

using SkiChair.Data.Entities;

namespace SkiChair.PhotoGallery.Views
{
    public interface ISetView
    {
        string SetTitle { get; set; }
        string SetID { get; set; }
        List<Photograph> PhotoList { get; set; }
    }
}




