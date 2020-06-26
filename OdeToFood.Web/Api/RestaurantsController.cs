using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OdeToFood.Web.APIController
{
    public class RestaurantsController : ApiController
    {
        //https://localhost:44397/api/restaurants
        private readonly IRestaurantData db;

        public RestaurantsController(IRestaurantData db)
        {
            this.db = db;
        }
        public IEnumerable<Restaurant> Get()
        {

            //return "Hello World!";
            var model = db.GetAll();
            return model;
        }
    }
}
