using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eBayInventory;

namespace eBayInventory.Views
{
    public class itemtypesController : Controller
    {
        private ebaydbEntities db = new ebaydbEntities();

        // GET: itemtypes
        public ActionResult Index()
        {
            return View(db.itemtypes.ToList());
        }

        // GET: itemtypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            itemtype itemtype = db.itemtypes.Find(id);
            if (itemtype == null)
            {
                return HttpNotFound();
            }
            return View(itemtype);
        }

        // GET: itemtypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: itemtypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemTypeID,TypeDesc")] itemtype itemtype)
        {
            if (ModelState.IsValid)
            {
                db.itemtypes.Add(itemtype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(itemtype);
        }

        // GET: itemtypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            itemtype itemtype = db.itemtypes.Find(id);
            if (itemtype == null)
            {
                return HttpNotFound();
            }
            return View(itemtype);
        }

        // POST: itemtypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemTypeID,TypeDesc")] itemtype itemtype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemtype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itemtype);
        }

        // GET: itemtypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            itemtype itemtype = db.itemtypes.Find(id);
            if (itemtype == null)
            {
                return HttpNotFound();
            }
            return View(itemtype);
        }

        // POST: itemtypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            itemtype itemtype = db.itemtypes.Find(id);
            db.itemtypes.Remove(itemtype);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
