using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using OdeToFood.data;
using Restaurants;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IRestaurantData restaurants;
        private readonly ILogger<ListModel> logger;

        [BindProperty(SupportsGet = true)]
        public string name { get; set; }

        public IEnumerable<Restaurant> Restaurants;
        public ListModel(IRestaurantData restaurantData, ILogger<ListModel> logger)
        {
            this.restaurants = restaurantData;
            this.logger = logger;
        }
        public void OnGet()
        {
            logger.LogError("Executing ListModel");
            this.Restaurants = restaurants.GetAll(name);
        }
    }
}