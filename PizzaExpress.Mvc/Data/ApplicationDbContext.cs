﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PizzaExpress.Models;

namespace PizzaExpress.Mvc.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Products> Products { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Sauce> Sauces { get; set; }
        public DbSet<Cart> Carts { get; set; }
    }
}