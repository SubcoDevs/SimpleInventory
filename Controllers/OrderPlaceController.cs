using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryManagement.Models;

namespace InventoryManagement.Controllers
{
    public class OrderPlaceController : Controller
    {
        private ProductDb db = new ProductDb();

        //
        // GET: /OrderPlace/

        public ActionResult Index()
        {
            return View(db.Order1.ToList());
        }

        //
        // GET: /OrderPlace/Details/5

        public ActionResult Details(int id = 0)
        {
            Order1 order1 = db.Order1.Find(id);
            if (order1 == null)
            {
                return HttpNotFound();
            }
            return View(order1);
        }

        //
        // GET: /OrderPlace/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /OrderPlace/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order1 order1)
        {
            if (ModelState.IsValid)
            {
                db.Order1.Add(order1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(order1);
        }

        //
        // GET: /OrderPlace/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Order1 order1 = db.Order1.Find(id);
            if (order1 == null)
            {
                return HttpNotFound();
            }
            return View(order1);
        }

        //
        // POST: /OrderPlace/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Order1 order1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order1);
        }

        //
        // GET: /OrderPlace/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Order1 order1 = db.Order1.Find(id);
            if (order1 == null)
            {
                return HttpNotFound();
            }
            return View(order1);
        }

        //
        // POST: /OrderPlace/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order1 order1 = db.Order1.Find(id);
            db.Order1.Remove(order1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}