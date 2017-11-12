using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Nozama.Models;

namespace Nozama.DAL
{
    public class NozamaInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<NozamaContext>
    {
        protected override void Seed(NozamaContext context)
        { 
            //load customers
            var customers = new List<Customer>
            {
                new Customer() {FirstName="Jane",LastName="Doe",StreetAddress="123 Anywhere Streeet",State="MO",PostalCode="12345",Country="USA",Email="janedoe@gmail.com"},
                new Customer() {FirstName="John",LastName="Doe",StreetAddress="5 Michigan Avenue",State="IL",PostalCode="54321",Country="USA",Email="johndoe@gmail.com"},
                new Customer() { FirstName="Daisy",LastName="Block",StreetAddress="7896 Green Drive",State="CA",PostalCode="94321",Country="USA",Email="daisyblock@gmail.com"},
            };
            customers.ForEach(s => context.Customers.Add(s));
            context.SaveChanges();

            //load products
            var products = new List<Product>
            {
                new Product() { ProductType=ProductType.CellPhone,Description="iPhone",Price=Convert.ToDecimal(999.99)},
                new Product() { ProductType=ProductType.Tablet,Description="iPad",Price=Convert.ToDecimal(359.99)},
                new Product() { ProductType=ProductType.Accessory,Description="iPad Case",Price=Convert.ToDecimal(29.99)},
                new Product() { ProductType=ProductType.Computer,Description="MacBook Pro",Price=Convert.ToDecimal(1899.99)},
                new Product() { ProductType=ProductType.Computer,Description="Dell Latitude",Price=Convert.ToDecimal(1299.99)},
                new Product() { ProductType=ProductType.CellPhone,Description="Galaxy",Price=Convert.ToDecimal(199.99)},
                new Product() { ProductType=ProductType.Accessory,Description="iPhone Case",Price=Convert.ToDecimal(19.99)},
                new Product() { ProductType=ProductType.Tablet,Description="Surface",Price=Convert.ToDecimal(599.00)},
            };
            products.ForEach(s => context.Products.Add(s));
            context.SaveChanges();


        }
    }
}