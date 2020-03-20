using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Restaurants
{
    public class Restaurant
    {
        public int Id{ get; set; }

        [Required]
        public string Name { get; set; }
        public string Location{ get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
