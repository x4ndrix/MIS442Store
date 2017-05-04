using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIS442Store.Controllers
{
    public class ErrorController : Controller
    {

        //Function that gets invoked in the event on an error.
        public ActionResult ServerError()
        {
            //Set status code to 500 before returning view
            Response.StatusCode = 500;
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }




        /*
        // GET: Error
        public ActionResult Index()
        {
            return View();
        }
        */
    }
}