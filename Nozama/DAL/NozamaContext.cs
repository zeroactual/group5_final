﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Nozama.Models;

namespace Nozama.DAL
{
    public class NozamaContext: DbContext
    {
        public NozamaContext(): base("DefaultConnection")
        {
            
        }

        public DbSet <Order> Orders { get; set; }
        public DbSet <Product> Products { get; set; }
        public DbSet <Cart> Carts { get; set; }
        public DbSet<CartProducts> CartProducts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}