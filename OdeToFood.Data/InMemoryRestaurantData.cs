using Restaurants;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> Restaurants;
        public InMemoryRestaurantData()
        {
            Restaurants = new List<Restaurant>()
            {
                new Restaurant{Id=1,Name="Dan",Location = "HCM",Cuisine=CuisineType.Indian },
                new Restaurant{Id=2,Name="Vo",Location = "HN",Cuisine=CuisineType.Italian },
                new Restaurant{Id=3,Name="Duc",Location = "DN",Cuisine=CuisineType.Mexican },
            };
        }
        public Restaurant GetById(int Id)
        {
            return Restaurants.SingleOrDefault(r => r.Id == Id);
        }
        public IEnumerable<Restaurant> GetAll(string name = null)
        {
            return from r in Restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
        public Restaurant Update(Restaurant UpdatedRestaurant)
        {
            var restaurant = Restaurants.SingleOrDefault(r => r.Id == UpdatedRestaurant.Id);
            if(restaurant != null)
            {
                restaurant.Name = UpdatedRestaurant.Name;
                restaurant.Location = UpdatedRestaurant.Location;
                restaurant.Cuisine = UpdatedRestaurant.Cuisine;
            }
            return restaurant;
        }
        public Restaurant Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = Restaurants.Max(r => r.Id) + 1;
            Restaurants.Add(newRestaurant);
            return newRestaurant;
        }
        public int Commit()
        {
            return 0;
        }

        public Restaurant Delete(int Id)
        {
            var restaurant = Restaurants.FirstOrDefault(r => r.Id == Id);
            if(restaurant != null)
            {
                Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public int GetCountOfRestaurants()
        {
            return Restaurants.Count();
        }
    }
}
