using System.Collections.Generic;
using Restaurants;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OdeToFood.data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext db;

        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }
        public Restaurant Add(Restaurant newRestaurant)
        {
            db.Add(newRestaurant);
            Commit();
            return newRestaurant;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Restaurant Delete(int Id)
        {
            var restaurant = GetById(Id);
            if(restaurant != null)
            {
                db.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll(string name)
        {
            var query = from r in db.Restaurants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return query;
        }

        public Restaurant GetById(int Id)
        {
            return db.Restaurants.Find(Id);
        }

        public int GetCountOfRestaurants()
        {
            return db.Restaurants.Count();
        }

        public Restaurant Update(Restaurant UpdatedRestaurant)
        {
            var entity = db.Restaurants.Attach(UpdatedRestaurant);
            entity.State = EntityState.Modified;
            return UpdatedRestaurant;
        }
    }
}
