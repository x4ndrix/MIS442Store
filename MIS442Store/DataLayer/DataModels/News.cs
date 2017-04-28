using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS442Store.DataLayer.DataModels
{
    public class News
    {
        

        //Properties for News list items
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public string author { get; set; }
        public DateTime datePosted { get; set; }
  
    }
}