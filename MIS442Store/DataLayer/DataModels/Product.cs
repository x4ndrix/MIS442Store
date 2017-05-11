using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS442Store.DataLayer.DataModels
{
    public class Product
    {
        //Accessors for each column in product table created in The Data Layer step 1
        public int ProductID {get; set;}
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double ProductVersion { get; set; }
        public DateTime ProductReleaseDate { get; set; }
    }
}