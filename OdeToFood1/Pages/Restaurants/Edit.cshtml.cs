using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.data;
using Restaurants;
using System.Collections.Generic;

namespace OdeToFood.Pages
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData RestaurantData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurant restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines;
        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.RestaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int restaurantId)
        {
            restaurant = RestaurantData.GetById(restaurantId);
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            if (restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                restaurant = RestaurantData.Update(restaurant);
                RestaurantData.Commit();
                return RedirectToPage("./Detail", new { restaurantId = restaurant.Id });
            }
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            return Page();
        }
    }
}