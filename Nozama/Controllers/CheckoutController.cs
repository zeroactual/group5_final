using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Nozama.DAL;
using Nozama.Models;

namespace Nozama.Controllers
{
    public class CheckoutController : Controller
    {
        private NozamaContext db = new NozamaContext();

        // GET: Checkout/Create
        public ActionResult Index()
        {
            return View();
        }

        // POST: Checkout/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "FirstName,LastName,StreetAddress,State,PostalCode,Country,Email,PhoneNumber")] Order order)
        {
            if (ModelState.IsValid)
            {
                order.OrderPlaced = new DateTime();
                order.Status = Status.Pending;
//                order.OrderTotal = 
                db.Orders.Add(order);
                db.SaveChanges();
                return Redirect("/");
            }
            return View(order);
        }
    }
}
