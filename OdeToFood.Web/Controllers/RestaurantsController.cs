using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        // GET: Restaurants
        //https://localhost:44397/restaurants
        private readonly IRestaurantData db;

        public RestaurantsController(IRestaurantData db)
        {
            this.db = db;
        }
        public ActionResult Index()
        {

            //return "Hello World!";
            var model = db.GetAll();
            return View(model);
        }


        //https://localhost:44397/restaurants/1
        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            //??? Handle case where restaurant id is incorrect. Protect it from crashing by redirecting.
            if (model == null)
            {
                //return RedirectToAction("Index"); OR
                return View("NotFound");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //??? The MVC FW will find any elements that can be used to create a Restaurant object from the browser
        // when Create is clicked and the pass it into this method. AKA model binding.
        //??? Also add this attribute to help the View differentiate which Create method to call.
        // First one will be called on GET and this one will be called on POST or Submit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            //??? ModelState can be used to add error messages to communicate it with the
            // view behind. But this is very tedious.
            if (string.IsNullOrEmpty(restaurant.Name))
            { ModelState.AddModelError(nameof(restaurant.Name), "This name is required."); }
            if (ModelState.IsValid)
            {
                db.Add(restaurant);
                //??? We can redirect to another page upon completion of this action, instead of returning the same Create View.
                // Also avoids user clicking the create button again. 
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if (model == null) { return HttpNotFound(); }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {

                db.Update(restaurant);
                //??? Passing data accross requests. This will be accessible on the next page that comes up.
                TempData["Message"] = "You have saved the restaurant!";
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View(restaurant);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }
        //??? HttpDelete is not too common since browsers send get and post, the rest like HttpDelete are used in WebApis.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }
    }
}