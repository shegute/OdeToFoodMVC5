﻿using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant(){ Id = 1, Name="Toritellis", Cusine =CusineType.Italian},
                new Restaurant(){ Id = 2, Name="Abay", Cusine =CusineType.Ethiopian},
                new Restaurant(){ Id = 3, Name="Wavy Grab n Go", Cusine =CusineType.None}
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name);
        }
    }
}
