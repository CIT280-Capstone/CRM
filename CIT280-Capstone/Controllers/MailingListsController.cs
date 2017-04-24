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
    public class MailingListsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MailingLists
        public ActionResult Index()
        {
            return View(db.MailingLists.ToList());
        }

        // GET: MailingLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MailingList mailingList = db.MailingLists.Find(id);
            db.Entry(mailingList).Collection(x => x.Customers).Load();
            if (mailingList == null)
            {
                return HttpNotFound();
            }
            return View(mailingList);
        }
        public ActionResult AddToList(int id, int custID)
        {
            var list = db.MailingLists.Find(id);
            db.Entry(list).Collection(x => x.Customers).Load();
            var customer = db.Customers.Find(custID);
            list.Customers.Add(customer);
            db.Entry(list).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Details", "Customers", new { id = custID });
        }

        // GET: MailingLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MailingLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description")] MailingList mailingList)
        {
            if (ModelState.IsValid)
            {
                db.MailingLists.Add(mailingList);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(mailingList);
        }

        // GET: MailingLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MailingList mailingList = db.MailingLists.Find(id);
            if (mailingList == null)
            {
                return HttpNotFound();
            }
            return View(mailingList);
        }

        // POST: MailingLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description")] MailingList mailingList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mailingList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mailingList);
        }

        // GET: MailingLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MailingList mailingList = db.MailingLists.Find(id);
            if (mailingList == null)
            {
                return HttpNotFound();
            }
            return View(mailingList);
        }

        // POST: MailingLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MailingList mailingList = db.MailingLists.Find(id);
            db.MailingLists.Remove(mailingList);
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
