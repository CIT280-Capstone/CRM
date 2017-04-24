using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CIT280_Capstone.Models;
using CIT280_Capstone.DAL;
using PagedList;

namespace CIT280_Capstone.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        
        public ViewResult Index(string sortOrder, string searchString, string filterValue, int? pageNo)
        {
            ViewBag.CurrentSortOrder = sortOrder;
            ViewBag.LastNameSortParm = String.IsNullOrEmpty(sortOrder) ? "lastName_desc" : "";
            ViewBag.NameSortParm = sortOrder == "firstName" ? "firstName_desc" : "firstName";

            if (searchString != null)
                pageNo = 1;           
            else
                searchString = filterValue;            

            ViewBag.FilterValue = searchString;

            var students = from s in db.Customers
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "lastName_desc":
                    students = students.OrderByDescending(s => s.LastName);
                    break;
                case "firstName":
                    students = students.OrderBy(s => s.FirstName);
                    break;
                case "firstName_desc":
                    students = students.OrderByDescending(s => s.FirstName);
                    break;
                default:
                    students = students.OrderBy(s => s.LastName);
                    break;
            }

            int sizeOfPage = 15;
            int numberOfPage = (pageNo ?? 1);
            return View(students.ToPagedList(numberOfPage, sizeOfPage));
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer.MailingAddressID != null)
                customer.MailingAddress = db.Addresses.Find(customer.MailingAddressID);
            if (customer.DeliveryAddressID != null)
                customer.DeliveryAddress = db.Addresses.Find(customer.DeliveryAddressID);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        public ActionResult SmallCustomerDetails()
        {
            var latestOrders = db.Orders.ToList().OrderBy(x => x.OrderDate).Take(5);

            List<Customer> customers = new List<Customer>();
            foreach (var order in latestOrders)
            {
                customers.Add(db.Customers.Find(order.CustomerID));
            }
            return PartialView(customers);
        }
        public ActionResult SmallOrderDetails()
        {
            var latestOrders = db.Orders.ToList().OrderBy(x => x.Customer).Take(5);

            List<Order> orders = new List<Order>();
            foreach (var order in latestOrders)
            {
                orders.Add(db.Orders.Find(order.ID));
            }
            return PartialView(orders);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = customer.ID });
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,PhoneNumber, DeliveryAddressID, MailingAddressID, TaxExempt")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", customer.ID);
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
