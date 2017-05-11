using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MIS442Store.Controllers
{
    public class ErrorController : Controller
    {

        
        public ActionResult ServerError()
        {
            //Set status code to 500 before returning view

            ViewBag.Message = "Error is a 500 error. Something terrible has happened.";
            //Response.StatusCode = 500;
            return View();
        }

        public ActionResult NotFound()
        {

            ViewBag.Message = "This error is a 400 error. It means that the resource you requested doesn't currently exist.";
            //Response.StatusCode = 404;
            return View();
        }
    }
}