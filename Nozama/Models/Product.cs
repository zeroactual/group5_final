using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Nozama.Models
{
    public enum ProductType
    {
        CellPhone,Computer,Tablet,Accessory
    }

    public class Product
    {
        public int ProductID { get; set; }
        [Display(Name = "Category")]
        public ProductType ProductType { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

    }
}