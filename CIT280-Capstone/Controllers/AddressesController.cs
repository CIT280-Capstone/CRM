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
    public class AddressesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Addresses
        public ActionResult Index()
        {
            return View(db.Addresses.ToList());
        }

        // GET: Addresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // GET: Addresses/Create
        public ActionResult CreateDelivery(int id)
        {
            ViewBag.CustID = id;
            return View();
        }
        public ActionResult CreateMailing(int id)
        {
            ViewBag.CustID = id;
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDelivery([Bind(Include = "ID,Street,City,State,ZipCode")] Address address, int CustID)
        {
            if (ModelState.IsValid)
            {
                db.Addresses.Add(address);
                db.Customers.Find(CustID).DeliveryAddressID = address.ID;
                db.SaveChanges();
                return RedirectToAction("Details", "Customers", new { id = CustID });
            }
            return RedirectToAction("Details", "Customers", new { id = CustID });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMailing([Bind(Include = "ID,Street,City,State,ZipCode")] Address address, int CustID)
        {
            if (ModelState.IsValid)
            {
                db.Addresses.Add(address);
                db.Customers.Find(CustID).MailingAddressID = address.ID;
                db.SaveChanges();
                return RedirectToAction("Details", "Customers", new { id = CustID });
            }
            return RedirectToAction("Details", "Customers", new { id = CustID });
        }

        // GET: Addresses/Edit/5
        public ActionResult Edit(int? id, int custID)
        {
            ViewBag.custID = custID;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Street,City,State,ZipCode")] Address address, int CustID)
        {
            if (ModelState.IsValid)
            {
                db.Entry(address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Customers", new { id = CustID });
            }
            return RedirectToAction("Details", "Customers", new { id = CustID });
        }

        // GET: Addresses/Delete/5
        public ActionResult DeleteDelivery(int? id, int CustID)
        {
            ViewBag.custID = CustID;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }
        public ActionResult DeleteMailing(int? id, int CustID)
        {
            ViewBag.custID = CustID;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("DeleteDelivery")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDeliveryConfirmed(int id, int CustID)
        {
            Address address = db.Addresses.Find(id);
            db.Addresses.Remove(address);
            db.Customers.Find(CustID).DeliveryAddressID = null;
            db.SaveChanges();
            return RedirectToAction("Details", "Customers", new { id = CustID });
        }

        [HttpPost, ActionName("DeleteMailing")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMailingConfirmed(int id, int CustID)
        {
            Address address = db.Addresses.Find(id);
            db.Addresses.Remove(address);
            db.Customers.Find(CustID).MailingAddressID = null;
            db.SaveChanges();
            return RedirectToAction("Details", "Customers", new { id = CustID });
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
