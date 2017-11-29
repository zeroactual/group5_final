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
        public decimal OrderTotal { get; set; }
        public Status Status { get; set; }
        public DateTime OrderPlaced { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}