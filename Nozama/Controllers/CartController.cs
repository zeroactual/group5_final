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
    public class CartController : Controller
    {
        private NozamaContext db = new NozamaContext();

        // GET: Cart
        public ActionResult Index()
        {
            Guid sessionId;
            var cookie = Request.Cookies["session"];
            if (cookie == null || !System.Guid.TryParse(cookie.Value, out sessionId))
            {
                return View(new List<CartProducts>());
            }

            sessionId = new Guid(cookie.Value);
            var cart = db.Carts.Find(sessionId);
            if (cart == null || cart.Carts == null)
            {
                return View(new List<CartProducts>());
            }

            return View(cart.Carts);
        }

        // GET: Cart/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            Guid sessionId;
            var cookie = Request.Cookies["session"];
            if (cookie == null || !System.Guid.TryParse(cookie.Value, out sessionId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sessionId = new Guid(cookie.Value);

            var items = db.CartProducts.SqlQuery(@"SELECT * FROM dbo.CartProducts WHERE Cart_CartId = @id", new SqlParameter("@id", sessionId)).ToList();
            foreach (var item in items)
            {
                if (item.Product.ProductID == id)
                {
                    db.CartProducts.Remove(item);
                    db.SaveChanges();
                    break;
                }
            }
            return RedirectToAction("Index");
        }
    }
}
