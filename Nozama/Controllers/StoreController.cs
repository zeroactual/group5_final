using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using Nozama.DAL;
using Nozama.Models;

namespace Nozama.Controllers
{
    public class StoreController : Controller
    {
        private NozamaContext db = new NozamaContext();

        // GET: Store
        //public ActionResult Index()
        //{
        //    return View();
        //}


        public ActionResult Index(string productType, string productDesc)
        {

            var products = from p in db.Products
                         select p;

            if (!string.IsNullOrEmpty(productType))
            {
                products = products.Where(s => s.ProductType.ToString().Contains(productType));

            }

            if (!string.IsNullOrEmpty(productDesc))
            {
                products = products.Where(s => s.Description.Contains(productDesc));
            }

            return View(products);
            
        }

        // GET: Store/Details/5
        public ActionResult Details(int? id)
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
            return View(product);
        }

        // GET: Store/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Store/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductType,Description,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Store/Edit/5
        public ActionResult Edit(int? id)
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
            return View(product);
        }

        // POST: Store/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductType,Description,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Store/Delete/5
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
            return View(product);
        }

        // POST: Store/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Store/AddCart/5
        public ActionResult AddCart(int? id)
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
                sessionId = System.Guid.NewGuid();
                Response.Cookies.Add(new HttpCookie("session", sessionId.ToString()));
            }
            else
            {
                sessionId = new Guid(cookie.Value);
            }

            Response.Cookies.Add(new HttpCookie("session", sessionId.ToString()));

            var cart = db.Carts.Find(sessionId);
            if (cart == null)
            {
                var products = new List<Product>();
                products.Add(product);
                db.Carts.Add(
                    new Cart()
                    {
                        CartId = sessionId,
                        Products = products
                    }
                );
            }
            else
            {
                cart.Products.Add(product);
                db.Carts.AddOrUpdate(cart);
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
