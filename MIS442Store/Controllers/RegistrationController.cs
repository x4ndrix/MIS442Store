using MIS442Store.DataLayer.DataModels;
using MIS442Store.DataLayer.Interfaces;
using MIS442Store.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIS442Store.Controllers
{
    [Authorize]
    public class RegistrationController : Controller
    {
        // GET: Registration
        /**public ActionResult Index()
        {
            return View();
        }**/

        private IRegistrationRepository _repo;

        public RegistrationController()
        {
            //Create new product repository
            _repo = new RegistrationRepository();
        }

        // GET: Product
        [HttpGet]
        public ActionResult Index()
        {
            //Pass a list of registrations from the repo to the view
            return View(_repo.GetRegistrations());
        }

        [HttpGet]
        public ActionResult AddRegistration()
        {
            //Return the add view when requested
            return View(new Registration());
        }

        [HttpPost]
        public ActionResult AddRegistration(Registration registration)
        {
            if (!ModelState.IsValid)
            {
                return View(registration);
            }
            //Save product to repo
            _repo.SaveRegistration(registration);
            return RedirectToAction("Index");
        }

        [HttpGet]
        //Retrieve a list of all registrations for user
        public ActionResult AdminIndex()
        {
            return View(_repo.GetRegistrations());
        }

    }

}
