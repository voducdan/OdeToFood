using Restaurants;
using System.Collections.Generic;

namespace OdeToFood.data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll(string name);
        Restaurant GetById(int Id);
        Restaurant Update(Restaurant UpdatedRestaurant);
        Restaurant Add(Restaurant newRestaurant);
        Restaurant Delete(int Id);
        int GetCountOfRestaurants();
        int Commit();
    }
}
