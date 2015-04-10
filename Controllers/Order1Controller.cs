using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using InventoryManagement.Models;

namespace InventoryManagement.Controllers
{
    public class Order1Controller : Controller
    {
        //
        // GET: /Order1/

        ProductDb _db = new ProductDb();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult CheckDetail()
        {
           

            var supplier1 = Request.Form["Supplier"].ToString();
            var subproduct1 = Request.Form["SubProduct"].ToString();


       //     var query = _db.Suppliers.Where(c => c.SupplierName == supplier1).Select(c => new { c.Id, c.SupplierName }).SingleOrDefault();



            if (supplier1 != "")
            {
                var query = _db.Suppliers.Where(c => c.SupplierName == supplier1).Select(c => new { c.Id, c.SupplierName });
                TempData["id"] = new SelectList(query.AsEnumerable(), "Id", "SupplierName", 1);
                TempData["check1"] = "S";
                
            }
            else if (subproduct1 != "")
            {
                var query = _db.SubProducts.Where(c => c.Name == subproduct1).Select(c => new { c.Id, c.Name });
                TempData["id"] = new SelectList(query.AsEnumerable(), "Id", "Name", 1);
                TempData["check1"] = "SP";    
            }
            else
            {
                TempData["id"] = "";
                TempData["check1"] = "";
                return View();
            }

            return RedirectToAction("Index", "OrderPlace");

           // return View();

        }


    }
}
