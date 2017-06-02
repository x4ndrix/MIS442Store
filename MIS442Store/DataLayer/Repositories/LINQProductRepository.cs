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
    public class LINQProductRepository : IProductRepository
    {
        private MIS442DBDataContext _DataContext = new MIS442DBDataContext();

        //GetList method retrieves a list of items in the MIS442DB

        public virtual List<Product> GetList()
        {
            List<Product> productList = new List<Product>();
            ISingleResult<ProductDO> productDOs = _DataContext.Product_GetList();

            foreach (var p in productDOs)
            {
                Product product = new Product();

                product.ProductID = p.ProductID;
                product.ProductCode = p.ProductCode;
                product.ProductName = p.ProductName;
                product.ProductReleaseDate = p.ProductReleaseDate;
                product.ProductVersion = (double)p.ProductVersion;

                //Set the rest of the properties of our Product object
                productList.Add(product);

            }
            return productList;
        }

        public virtual Product Get(int id)
        {
            Product product = null;
            ProductDO productDO = _DataContext.Product_Get(id).SingleOrDefault();

            if (productDO != null)
            {
                product.ProductID = productDO.ProductID;

            }
            return product;
        }
        public virtual void Save(Product product)
        {
            if (product.ProductID == 0)
            {
                _DataContext.Product_InsertUpdate(product.ProductID, product.ProductCode, product.ProductName, (decimal)product.ProductVersion, product.ProductReleaseDate);
            }

            else
            {
                _DataContext.Product_InsertUpdate(product.ProductID, product.ProductCode, product.ProductName, (decimal)product.ProductVersion, product.ProductReleaseDate);
            }
        }
    }
}
        
       

        
