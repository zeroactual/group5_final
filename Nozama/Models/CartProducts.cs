using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nozama.Models
{
    public class CartProducts
    {
        [Key]
        public Guid CartProductId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Cart Cart { get; set; }
    }
}