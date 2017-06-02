using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MIS442Store.DataLayer.DataModels;
using MIS442Store.DataLayer.Interfaces;
using MIS442Store.DataLayer.Repositories;
using System.Data.Linq;

namespace MIS442Store.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {

        private IProductRepository _repo;

        public ProductController()
        {
            //Create new product repository
            //_repo = new ProductRepository();

            //Create new LINQProductRepository object
            _repo = new LINQProductRepository();
        }

        // GET: Product
        [HttpGet]
        public ActionResult Index()
        {
            //Pass a list of products from the repo to the view
            return View(_repo.GetList());
        }

        [HttpGet]
        public ActionResult Add()
        {
            //Return the add view when requested
            return View(new Product());
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            if(!ModelState.IsValid)
            {
                return View(product);
            }
            //Save product to repo
            _repo.Save(product);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Product product) 
        {
            if(!ModelState.IsValid)
            {
                return View(product);
            }
            _repo.Save(product);

            return RedirectToAction("Index");
           
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Product prod = _repo.Get(id);

            return View(prod);
        }
        
        [OutputCache(Duration = 500, VaryByParam ="id")]
        public ActionResult ViewProduct(int id)
        {
            

            return View("ViewProduct");
        }

    }
}