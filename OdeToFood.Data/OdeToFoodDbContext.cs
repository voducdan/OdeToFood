﻿using Microsoft.EntityFrameworkCore;
using Restaurants;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.data
{
    public class OdeToFoodDbContext : DbContext
    {
        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options) :base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
