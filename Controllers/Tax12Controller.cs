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
    public class Tax12Controller : Controller
    {
        private ProductDb db = new ProductDb();

        //
        // GET: /Tax12/

        public ActionResult Index()
        {
            return View(db.Tax12.ToList());
        }

        //
        // GET: /Tax12/Details/5

        public ActionResult Details(int id = 0)
        {
            Tax12 tax12 = db.Tax12.Find(id);
            if (tax12 == null)
            {
                return HttpNotFound();
            }
            return View(tax12);
        }

        //
        // GET: /Tax12/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Tax12/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tax12 tax12)
        {
            if (ModelState.IsValid)
            {
                db.Tax12.Add(tax12);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tax12);
        }

        //
        // GET: /Tax12/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Tax12 tax12 = db.Tax12.Find(id);
            if (tax12 == null)
            {
                return HttpNotFound();
            }
            return View(tax12);
        }

        //
        // POST: /Tax12/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tax12 tax12)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tax12).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tax12);
        }

        //
        // GET: /Tax12/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Tax12 tax12 = db.Tax12.Find(id);
            if (tax12 == null)
            {
                return HttpNotFound();
            }
            return View(tax12);
        }

        //
        // POST: /Tax12/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tax12 tax12 = db.Tax12.Find(id);
            db.Tax12.Remove(tax12);
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