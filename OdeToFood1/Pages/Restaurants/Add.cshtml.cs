using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.data;
using Restaurants;

namespace OdeToFood.Pages.Restaurants
{
    public class AddModel : PageModel
    {
        private readonly IHtmlHelper htmlHelper;
        private readonly IRestaurantData RestaurantData;

        public IEnumerable<SelectListItem> Cuisines;

        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public AddModel(IRestaurantData restaurantData ,IHtmlHelper htmlHelper)
        {
            this.RestaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public void OnGet()
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                RestaurantData.Add(Restaurant);
                TempData["Message"] = "New restaurant is saved!";
                return RedirectToPage("./List");
            }
            return Page();
        }
    }
}