﻿using SuiteProducts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuiteProducts.Controllers
{
    public class PackageController : Controller
    {
        SuitesProductDb _db = new SuitesProductDb();

        // GET: Package
        [HttpGet]//maybe do [Authorize]
        public ActionResult Index()
        {
            var packages = _db.Packages.ToList();

            return View(packages);
        }

        // GET: Package/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Package/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Package/Create
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

        // GET: Package/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Package/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Package/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Package/Delete/5
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
    }
}
