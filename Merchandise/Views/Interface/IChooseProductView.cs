﻿using System;
using System.Collections.Generic;
using System.Text;

using SkiChair.Data.Entities;

namespace SkiChair.Merchandise.Views
{
    public interface IChooseProductView
    {
        List<Product> ProductList { get; set; }
    }
}




