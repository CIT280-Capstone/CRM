using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CIT280_Capstone.Models;

namespace CIT280_Capstone.Controllers
{
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult CustomerOrdersList(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            List<Order> customerOrders = db.Orders.Where(x => x.CustomerID == id).ToList();
            if (customerOrders == null)
                return HttpNotFound();
            
            customerOrders.OrderBy(x => x.OrderDate);

            return PartialView(customerOrders);
        }

        public ActionResult LineItemsPerOrder(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            List<LineItem> lineItems = db.LineItems.Where(x => x.OrderID == id).ToList();
            if (lineItems == null)
                return HttpNotFound();
            foreach (var item in lineItems)
            {
                item.Product = db.Products.Find(item.ProductID);
            }

            ViewBag.elementID = id;
            return PartialView(lineItems);
        }

        public ActionResult OrderCountPerCustomer(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            ViewBag.OrderCount = db.Orders.Where(x => x.CustomerID == id).Count();

            return PartialView();
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
