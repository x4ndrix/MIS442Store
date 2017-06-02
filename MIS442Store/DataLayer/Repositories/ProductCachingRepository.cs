using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MIS442Store.DataLayer.Interfaces;
using MIS442Store.DataLayer.DataModels;
using MIS442Store.Controllers;
using MIS442Store.DataLayer;
using System.Data.Linq;

namespace MIS442Store.DataLayer.Repositories
{
    public class ProductCachingRepository : LINQProductRepository
    {
       
        public override List<Product> GetList()
        {
            List<Product> prodsList = (List<Product>)HttpRuntime.Cache["ProductsList"];

            //If the cache is empty, get list of products into cache from parent class
            if(prodsList == null)
            {
                prodsList = base.GetList();
                HttpRuntime.Cache["ProductsList"] = prodsList;
            }
            return prodsList;
        }

    }
}