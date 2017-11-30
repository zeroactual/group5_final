using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Nozama.Models
{
    public class Cart
    {
        public Cart()
        {
            this.Carts = new List<CartProducts>();
        }

        [Key]
        public Guid CartId { get; set; }
        public virtual ICollection<CartProducts> Carts { get; set; }
    }
}