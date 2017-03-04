using SuiteProducts.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SuiteProducts.Controllers
{
    public class ProductController : Controller
    {
        private SuitesProductDb _db = new SuitesProductDb();

        [ChildActionOnly]
        public ActionResult BestProduct() {

            var product = _db.Products.First();

            return PartialView("_Product", product);
        }

        // GET: Product
        public ActionResult Index(string catagory = null, string searchTerm = null)
        {
            //turn catagory into a enum

            var model = _db.Products.Where(r => (catagory == null && searchTerm == null) || r.Catagory.ToUpper() == catagory.ToUpper() || r.Product_Name.StartsWith(searchTerm)).Take(10);
            return View(model);
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
        if (id == null) {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Product product = _db.Products.Find(id);
        if (product == null) {
            return HttpNotFound();
        }
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        //I think I should remove id
        //FormCollection collection was original single parameter
        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Product_Id, Product_Name, Price, Catagory, Description, Package_Id")]  Product product)
        {
        if (ModelState.IsValid) {
            _db.Products.Add(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
                return View(product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _db.Products.Find(id);
            if (product == null) {
                return HttpNotFound();
            }

            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, FormCollection collection)
        public ActionResult Edit([Bind(Include = "Product_Id, Product_Name, Price, Catagory, Description, Package_Id")] Product product)
        {
            if (ModelState.IsValid) {
                _db.Entry(product).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _db.Products.Find(id);
            if (product == null) {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, FormCollection collection)
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = _db.Products.Find(id);
            _db.Products.Remove(product);
            _db.SaveChanges();
        return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null) {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
