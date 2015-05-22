using InventoryManagement.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryManagement.Controllers
{
    [Authorize]
    public class InventoryController : Controller
    {
        //
        // GET: /Inventory/

        ProductDb _db = new ProductDb();

        //public ActionResult Index(string sortOrder, string CurrentSort, int? page)
        public ActionResult Index()
        {

            if (User.IsInRole("AdminWebSite") == true)
            {
                return RedirectToAction("Index", "Client");
            }

            //int pageSize = 10;
            //int pageIndex = 1;
            //pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            //ViewBag.CurrentSort = sortOrder;

            //sortOrder = String.IsNullOrEmpty(sortOrder) ? "Id" : sortOrder;

         //   IPagedList<Product> products = null;

            var username = User.Identity.Name;
            var user = _db.UserProfiles.SingleOrDefault(u => u.UserName.ToLower() == username);
            var clientId = user.ClientId;
            TempData["clientId"] = clientId;


            //switch (sortOrder)
            //{
            //    case "Id":
            //        if (sortOrder.Equals(CurrentSort))
            //            products = _db.Products.OrderByDescending
            //                    (m => m.Id).Where(m=>m.ClientId == clientId).ToPagedList(pageIndex, pageSize);
            //                    //(m => m.Id).ToPagedList(pageIndex, pageSize);
            //        else
            //            products = _db.Products.OrderBy
            //                    (m => m.Id).Where(m => m.ClientId == clientId).ToPagedList(pageIndex, pageSize);
            //                    //(m => m.Id).ToPagedList(pageIndex, pageSize);
            //        break;
            //    case "Name":
            //        if (sortOrder.Equals(CurrentSort))
            //            products = _db.Products.OrderByDescending
            //                    (m => m.Name).ToPagedList(pageIndex, pageSize);
            //        else
            //            products = _db.Products.OrderBy
            //                    (m => m.Name).ToPagedList(pageIndex, pageSize);
            //        break;

            //    case "Brand":
            //        if (sortOrder.Equals(CurrentSort))
            //            products = _db.Products.OrderByDescending
            //                    (m => m.Name).ToPagedList(pageIndex, pageSize);
            //        else
            //            products = _db.Products.OrderBy
            //                    (m => m.Name).ToPagedList(pageIndex, pageSize);
            //        break;

            //    case "Tags":
            //        if (sortOrder.Equals(CurrentSort))
            //            products = _db.Products.OrderByDescending
            //                    (m => m.Name).ToPagedList(pageIndex, pageSize);
            //        else
            //            products = _db.Products.OrderBy
            //                    (m => m.Name).ToPagedList(pageIndex, pageSize);
            //        break;

            //    case "WholesalePrice":
            //        if (sortOrder.Equals(CurrentSort))
            //            products = _db.Products.OrderByDescending
            //                    (m => m.Name).ToPagedList(pageIndex, pageSize);
            //        else
            //            products = _db.Products.OrderBy
            //                    (m => m.Name).ToPagedList(pageIndex, pageSize);
            //        break;

            //    case "RetailPrice":
            //        if (sortOrder.Equals(CurrentSort))
            //            products = _db.Products.OrderByDescending
            //                    (m => m.Name).ToPagedList(pageIndex, pageSize);
            //        else
            //            products = _db.Products.OrderBy
            //                    (m => m.Name).ToPagedList(pageIndex, pageSize);
            //        break;

            //    case "BuyPrice":
            //        if (sortOrder.Equals(CurrentSort))
            //            products = _db.Products.OrderByDescending
            //                    (m => m.Name).ToPagedList(pageIndex, pageSize);
            //        else
            //            products = _db.Products.OrderBy
            //                    (m => m.Name).ToPagedList(pageIndex, pageSize);
            //        break;

            //    case "InitialCostPrice":
            //        if (sortOrder.Equals(CurrentSort))
            //            products = _db.Products.OrderByDescending
            //                    (m => m.Name).ToPagedList(pageIndex, pageSize);
            //        else
            //            products = _db.Products.OrderBy
            //                    (m => m.Name).ToPagedList(pageIndex, pageSize);
            //        break;

            //    case "Stock":
            //        if (sortOrder.Equals(CurrentSort))
            //            products = _db.Products.OrderByDescending
            //                    (m => m.Name).ToPagedList(pageIndex, pageSize);
            //        else
            //            products = _db.Products.OrderBy
            //                    (m => m.Name).ToPagedList(pageIndex, pageSize);
            //        break;

            //    case "Taxable":
            //        if (sortOrder.Equals(CurrentSort))
            //            products = _db.Products.OrderByDescending
            //                    (m => m.Name).ToPagedList(pageIndex, pageSize);
            //        else
            //            products = _db.Products.OrderBy
            //                    (m => m.Name).ToPagedList(pageIndex, pageSize);
            //        break;

            //    case "ManageStock":
            //        if (sortOrder.Equals(CurrentSort))
            //            products = _db.Products.OrderByDescending
            //                    (m => m.Name).ToPagedList(pageIndex, pageSize);
            //        else
            //            products = _db.Products.OrderBy
            //                    (m => m.Name).ToPagedList(pageIndex, pageSize);
            //        break;

            //    case "KeepSelling":
            //        if (sortOrder.Equals(CurrentSort))
            //            products = _db.Products.OrderByDescending
            //                    (m => m.Name).ToPagedList(pageIndex, pageSize);
            //        else
            //            products = _db.Products.OrderBy
            //                    (m => m.Name).ToPagedList(pageIndex, pageSize);
            //        break;

            //    case "PublishOnline":
            //        if (sortOrder.Equals(CurrentSort))
            //            products = _db.Products.OrderByDescending
            //                    (m => m.Name).ToPagedList(pageIndex, pageSize);
            //        else
            //            products = _db.Products.OrderBy
            //                    (m => m.Name).ToPagedList(pageIndex, pageSize);
            //        break;

            //    case "OnlineOrdering":
            //        if (sortOrder.Equals(CurrentSort))
            //            products = _db.Products.OrderByDescending
            //                    (m => m.Name).ToPagedList(pageIndex, pageSize);
            //        else
            //            products = _db.Products.OrderBy
            //                    (m => m.Name).ToPagedList(pageIndex, pageSize);
            //        break;
            //    // Add sorting statements for other columns

            //    case "Default":
            //        products = _db.Products.OrderBy
            //                (m => m.Id).ToPagedList(pageIndex, pageSize);
            //        break;
            //}
            //return View(_db.Products.ToList().Where(m=> m.IsDeleted != true).Where(m => m.SaleableItem == true));
            return View(_db.Products.ToList().Where(m => m.IsDeleted != true));

            
            //return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.ClientId = Convert.ToInt32(TempData["clientId"]);
                _db.Products.Add(product);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public ActionResult Edit(int Id)
        {
            var model = _db.Products.Find(Id);
            //var temp = System.Web.Security.Membership.GetUser().ProviderUserKey;
            //var temp1 = WebMatrix.WebData.WebSecurity.GetUserId(User.Identity.Name);
            //var currentUserId = WebMatrix.WebData.WebSecurity.GetUserId(User.Identity.Name);
            //var manager = new UserManager<MyUser>(new UserStore<MyUser>(new MyDbContext()));
            //var currentUser = manager.FindById(User.Identity.GetUserId());
            //System.Web.Profile.ProfileBase _userProfile = System.Web.Profile.ProfileBase.Create(User.Identity.Name);
            //var context = new ProductDb();
            //var username = User.Identity.Name;
            //var user = context.UserProfiles.SingleOrDefault(u => u.UserName.ToLower() == username);
            //var clientId = user.ClientId;
            //var temp = _userProfile.GetPropertyValue("ClientId");


            // For testing
            //TempData["ItemId"] = Id;
            //ViewBag.ItemId = Id;
            Session["ItemId"] = Id;
            var modelRelationship = _db.ItemRelationships.ToList().Where(m => m.ItemId == Id);

            ViewData["Relationship"] = modelRelationship;
            // End testing code

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                product.ClientId = Convert.ToInt32(TempData["clientId"]);
                _db.Entry(product).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet]
        public ActionResult Relationship(int Id)
        {
            //var model = _db.ItemRelationships.Find(Id);
            //ViewBag.ItemId = Id;
            //ViewData["ItemId"] = Id;
            //Session["ItemId"] = Id;
            var model = _db.ItemRelationships.ToList().Where(m => m.ItemId == Id);

            return View(model);
            //return View();
        }

        //[HttpPost]
        //public ActionResult Relationship(Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        product.ClientId = Convert.ToInt32(TempData["clientId"]);
        //        _db.Entry(product).State = EntityState.Modified;
        //        _db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(product);
        //}

        [HttpGet]
        public ActionResult AddNewRelationship()
        {
            //var model = _db.ItemRelationships.Find(Id);
            //ViewBag.ItemId = Id;
            //var model = _db.ItemRelationships.ToList().Where(m => m.ItemId == Id);
            //ViewBag.ItemId = Id;
            //return View(model);

            var model = _db.Products.ToList().Where(m => m.SaleableItem != true);

            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = "Select", Value = "0" });
            //li.Add(new SelectListItem { Text = "Cloth", Value = "9" });
            //li.Add(new SelectListItem { Text = "Zip", Value = "10" });

            foreach (var item in model)
            {
                li.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }
            
            Session["SubItem"] = li;
            //TempData["ItemId1"] = TempData["ItemId"];
            //ViewBag.ItemId = TempData["ItemId"];
            return View();
        }

        [HttpPost]
        public ActionResult AddNewRelationship(ItemRelationship itemRelationship)
        {

            if (ModelState.IsValid)
            {
                itemRelationship.ItemId = Convert.ToInt32(Session["ItemId"]);
                itemRelationship.SubItemName = ((List<SelectListItem>)Session["SubItem"]).Where(e => e.Value == itemRelationship.SubItemId.ToString()).FirstOrDefault().Text;
                _db.ItemRelationships.Add(itemRelationship);
                _db.SaveChanges();
                //return RedirectToAction("Relationship", itemRelationship.ItemId);
                //return RedirectToAction("Index");
                return RedirectToAction("Edit", new { id = itemRelationship.ItemId });
            }
            return View(itemRelationship);
        }

        [HttpGet]
        public ActionResult GoToSubproduct(int id)
        {
            int i = 0;
            TempData["product_id"] = id;
            return RedirectToAction("Index", "SubProduct");
        }


        [HttpGet]
        public ActionResult Delete(int Id)
        {
            //if (ModelState.IsValid)
            //{
                //_db.Entry(product).State = EntityState.Modified;
            var model = _db.Products.Find(Id);
            _db.Products.Remove(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            //}
            //return View(product);
        }

        //public ActionResult WebgridSample()
        //{
        //    ObservableCollection<ItemRelationship> itemRelationshipList =
        //        new ObservableCollection<ItemRelationship>();
        //    itemRelationshipList.Add(new ItemRelationship
        //    {
        //        Id = 1,
        //        ItemId = 101,
        //        SubItemId = 201,
        //        Quantity = 800,
        //        Unit = "Computer",
        //        UnitPrice = "test",
        //        Cost = 123,
                
        //    });
        //    itemRelationshipList.Add(new ItemRelationship
        //    {
        //        Id = 2,
        //        ItemId = 102,
        //        SubItemId = 202,
        //        Quantity = 800,
        //        Unit = "Computer",
        //        UnitPrice = "test",
        //        Cost = 123,
        //    });
        //    itemRelationshipList.Add(new ItemRelationship
        //    {
        //        Id = 3,
        //        ItemId = 103,
        //        SubItemId = 203,
        //        Quantity = 800,
        //        Unit = "Computer",
        //        UnitPrice = "test",
        //        Cost = 123,
        //    });
            
        //    return View(itemRelationshipList);
        //}

        public ActionResult ExportData()
        {
            GridView gv = new GridView();
            gv.DataSource = _db.Products.ToList();
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Inventory.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }

            base.Dispose(disposing);
        }

    }
}
