using OdeToFood.Data.Models;
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

        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name);
        }

        public void Add(Restaurant restaurant)
        {
            restaurants.Add(restaurant);
            restaurant.Id = restaurants.Max(r => r.Id) + 1;
        }

        public void Update(Restaurant restaurant)
        {
            var existing = Get(restaurant.Id);
            if (existing != null)
            {   
                existing.Name = restaurant.Name;
                existing.Cusine = restaurant.Cusine;
            }
        }

        public void Delete(int id)
        {
            var existing = Get(id);
            restaurants.Remove(existing);
        }
    }
}
