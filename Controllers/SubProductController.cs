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
    public class SubProductController : Controller
    {

        private ProductDb db = new ProductDb();

        //
        // GET: /SubProduct/

        public ActionResult Index()
        {
            return View(db.SubProducts.ToList());
        }

        //
        // GET: /SubProduct/Details/5

        public ActionResult Details(int id = 0)
        {
            SubProduct subproduct = db.SubProducts.Find(id);
            if (subproduct == null)
            {
                return HttpNotFound();
            }
            return View(subproduct);
        }

        //
        // GET: /SubProduct/Create

        public ActionResult Create()
        {
            var query = db.Products.Select(c => new { c.Id, c.Name });
            ViewBag.Id = new SelectList(query.AsEnumerable(), "Id", "Name", 1);

            var query1 = db.Suppliers.Select(c1 => new { c1.Id, c1.SupplierName });
            ViewBag.Id1 = new SelectList(query1.AsEnumerable(), "Id", "SupplierName", 1);

            return View();
        }

        //
        // POST: /SubProduct/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubProduct subproduct)
        {
            if (ModelState.IsValid)
            {
                db.SubProducts.Add(subproduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subproduct);
        }

        //
        // GET: /SubProduct/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SubProduct subproduct = db.SubProducts.Find(id);
            if (subproduct == null)
            {
                return HttpNotFound();
            }

            var query = db.Products.Select(c => new { c.Id, c.Name });
            ViewBag.Id = new SelectList(query.AsEnumerable(), "Id", "Name", 1);

            var query1 = db.Suppliers.Select(c1 => new { c1.Id, c1.SupplierName });
            ViewBag.Id1 = new SelectList(query1.AsEnumerable(), "Id", "SupplierName", 1);

            return View(subproduct);
        }

        //
        // POST: /SubProduct/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubProduct subproduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subproduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subproduct);
        }

        //
        // GET: /SubProduct/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SubProduct subproduct = db.SubProducts.Find(id);
            if (subproduct == null)
            {
                return HttpNotFound();
            }
            return View(subproduct);
        }

        //
        // POST: /SubProduct/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubProduct subproduct = db.SubProducts.Find(id);
            db.SubProducts.Remove(subproduct);
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