using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SuiteProducts.Models;

namespace SuiteProducts.Controllers
{
    public class PackageController : Controller
    {
        private SuitesProductDb _db = new SuitesProductDb();

        // GET: Package
        public ActionResult Index()
        {
            return View(_db.Packages.ToList());
        }

        // GET: Package/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Package package = _db.Packages.Find(id);
        //    if (package == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(package);
        //}

        // GET: Package/Create
        public ActionResult Create()
        {
            return View();
        }
        // I think I should remove id
        // POST: Package/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Package_Id,Package_Name,Price,Description")] Package package)
        {
            if (ModelState.IsValid)
            {
                _db.Packages.Add(package);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(package);
        }

        // GET: Package/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package package = _db.Packages.Find(id);
            if (package == null)
            {
                return HttpNotFound();
            }
            return View(package);
        }

        // POST: Package/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Package_Id,Package_Name,Price,Description")] Package package)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(package).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(package);
        }

        // GET: Package/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package package = _db.Packages.Find(id);
            if (package == null)
            {
                return HttpNotFound();
            }
            return View(package);
        }

        // POST: Package/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Package package = _db.Packages.Find(id);
            _db.Packages.Remove(package);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
