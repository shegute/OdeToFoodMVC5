using OdeToFood.Data.Services;
using OdeToFood.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace OdeToFood.Web.Controllers
{
    //??? Any call from the web will first hit the corresponding controller,
    // this is based on RoutConfig 
    // The controller will then build all the info needed as a model and then pass that to the
    // corresponding view.
    //??? And additional data can be found from the query string or 
    // with MVC, the framework will look around for any additional info and provide it.
    // For eg, here it will look for name in the httpcontext and add it to the name param/arg
 
    //??? This type of controller vs WebApiController is geared towards building an html view response, 
    //vs the latter which is geared towards taking in json and responding with json, mostly for web calls vs 
    // webpage calls.
    public class RestaurantController : Controller
    {
        public ActionResult Index(string name)
        {
            var model = new RestaurantViewModel();
            //??? Get setting from app config
            model.Greeting = ConfigurationManager.AppSettings.Get("RestaurantPageGreeting");
            //??? Get an arg/query string thats passed using one of these 2 ways.
            //modle.Name = HttpContext.Request.QueryString["name"];
            model.Name = name;
            //??? This will call the Index.cshtml view under the OdeToFood.Web\Views\Restaurant folder.
            return View(model);
        }
    }
}