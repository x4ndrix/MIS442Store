﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS442Store.DataLayer.Interfaces
{
    public interface IProductRepository
    {
        Product Get(int id);
        List<Product> GetList();
        void Save(Product product);
    }
}
