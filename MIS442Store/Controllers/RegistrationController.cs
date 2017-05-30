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
        

        private IRegistrationRepository _repo;
        private IStateRepository _staterepo;

        public RegistrationController()
        {
            //Create new regisration and state repository
            _repo = new RegistrationRepository();
            _staterepo = new StateRepository();
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
            RegistrationModel regModel = new RegistrationModel();

            regModel.States = _staterepo.GetStates();
            //Return the add view when requested
            return View(regModel);

        }

        [HttpPost]
        public ActionResult AddRegistration(Registration reg)
        {
            if (!ModelState.IsValid)
            {
                return View(reg);
            }
            //Save product to repo
            _repo.SaveRegistration(reg);
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
