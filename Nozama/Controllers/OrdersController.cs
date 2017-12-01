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
    public class OrdersController : Controller
    {
        private NozamaContext db = new NozamaContext();

        // GET: Checkout/Create
        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }
    }
}
