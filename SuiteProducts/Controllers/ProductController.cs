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

            var product = _db.Products.OrderBy(x => Guid.NewGuid()).FirstOrDefault();

            return PartialView("_Product", product);
        }

        // GET: Product
        public ActionResult Index([Bind(Prefix ="package")]int? package_id, string catagory = null, string searchTerm = null)
        {
            //turn catagory into a enum
            int value = 0;
            var products = _db.Products.ToList();

            if (package_id != null)
            {
                value = 1;
            }
            else if (catagory != null) {
                value = 2;
            }
            else if (searchTerm != null) {
                value = 3;
            }
            else {
                value = 0;
            }

            switch (value)
            {
                case 1:
                    products = products.Where(r => r.Package_Id == package_id).ToList();
                    break;
                case 2:
                    products = products.Where(r => r.Catagory == catagory).ToList();
                    break;
                    //fix search to look for works anywhere
                case 3:
                    products = products.Where(r => r.Product_Name.StartsWith(searchTerm)).Take(10).ToList();
                    break;
                default: 
                    break;
            }

            if (products != null)
            {
                return View(products);
            }
            else {
                return HttpNotFound();
            }

            
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
