using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
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
                Guid sessionId;
                var cookie = Request.Cookies["session"];
                if (cookie == null || !System.Guid.TryParse(cookie.Value, out sessionId))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                sessionId = new Guid(cookie.Value);

                var items = db.CartProducts.SqlQuery(@"SELECT * FROM dbo.CartProducts WHERE Cart_CartId = @id", new SqlParameter("@id", sessionId)).ToList();

                order.OrderPlaced = DateTime.Now;
                order.Status = Status.Pending;
                decimal sum = 0;
                foreach (var item in items)
                {
                    sum += item.Product.Price;
                }
                order.OrderTotal = sum;
                db.Orders.Add(order);
                db.SaveChanges();

                db.CartProducts.RemoveRange(items);
                db.SaveChanges();
                return Redirect("/");
            }
            return View(order);
        }
    }
}
