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
                return View(new List<Product>());
            }

            sessionId = new Guid(cookie.Value);
            var cart = db.Carts.Find(sessionId);
            if (cart == null || cart.Products == null)
            {
                return View(new List<Product>());
            }

            return View(cart.Products);
//
//            //            var carts = db.Carts.Where(c => c.CartId == new Guid(cook.Value)).Select(c => c.Products);
//            List<Product> products = c.Products;
//
////            List<Cart> products = query.ToList();
////            Cart cart = query.First();
////            var query = db.Carts.Where(c => c.Session.SessionId == new Guid(""));            
//
//            return View(products);
        }

        // GET: Cart/Delete/5
        public ActionResult DeleteCart(int? id)
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

            var cook = Request.Cookies["session"];
            Cart c;
            c = db.Carts.Find(new Guid(cook.Value));
            if (c == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                c.Products.Remove(product);
            }
           
           
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
