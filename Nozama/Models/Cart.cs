using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Nozama.Models
{
    public class Cart
    {
        [Key]
        public Guid CartId { get; set; }
//        public Guid SessionId { get; set; }
        public List<Product> Products { get; set; }
    }
}