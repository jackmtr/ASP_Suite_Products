using SuiteProducts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuiteProducts.Controllers
{
    public class ProductController : Controller
    {
        SuitesProductDb _db = new SuitesProductDb();

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
            public ActionResult Details(int id)
            {
                return View();
            }

            // GET: Product/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: Product/Create
            [HttpPost]
            public ActionResult Create(FormCollection collection)
            {
                try
                {
                    // TODO: Add insert logic here

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var review = _db.Products.Single(r => r.Product_Id == id);

            return View(review);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var product = _db.Products.Single(r => r.Product_Id == id);

            if (TryUpdateModel(product)) {
                //save into db
                return RedirectToAction("Index");
            }
            return View(product);

            //try
            //{
            //    // TODO: Add update logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }

            // GET: Product/Delete/5
            public ActionResult Delete(int id)
            {
                return View();
            }

            // POST: Product/Delete/5
            [HttpPost]
            public ActionResult Delete(int id, FormCollection collection)
            {
                try
                {
                    // TODO: Add delete logic here

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
        //static List<Product> _products = new List<Product> {
        //    new Product {
        //        Product_Id= 1,
        //        Product_Name= "Fresh Vegetable",
        //        Price= 60.00F,
        //        Description= "Baby carrots, celery, grape tomatoes, cauliflower, broccoli, cucumber, radish, peppers, sour cream dill dip",
        //    },
        //    new Product {
        //        Product_Id=2,
        //        Product_Name="Premium Cheese Platter",
        //        Price= 100.00F,
        //        Description= "Artisan selection of assorted, perfecly ripened local and international cheeses, pear jam, grpes, dried fruits.",
        //    },
        //new Product {
        //        Product_Id= 3,
        //        Product_Name= "Fresh Fruit",
        //        Price= 65,
        //        Description = "Watermelon, cantaloupe, pineapple, honeydew, strawberries, raspberries, blueberries"
        //    },
        //};

        protected override void Dispose(bool disposing)
        {
            if (_db != null) {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
