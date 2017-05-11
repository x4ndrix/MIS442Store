using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIS442Store.Controllers
{
    public class ProductController : Controller
    {
       

        // GET: Product
        public ActionResult Index()
        {
            ViewBag.Title = "MIS442 Products";
            ViewBag.Header = "MIS442 Products";
            return View();
        }
    }
}