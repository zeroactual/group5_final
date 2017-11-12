using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Nozama.Models
{
    public enum Status
    {
        Pending, InTransit, Delivered, Cancelled
    }

    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public decimal OrderTotal { get; set; }
        public Status Status { get; set; }
        public DateTime OrderPlaced { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}