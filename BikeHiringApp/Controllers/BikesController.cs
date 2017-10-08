using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BikeHiringApp.Models;

namespace BikeHiringApp.Controllers
{
    public class BikesController : Controller
    {
        private BikeDBEntities db = new BikeDBEntities();

        // GET: Bikes
        public ActionResult Index()
        {
            return View(db.Bikes.ToList());
        }

        // GET: Bikes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bike bike = db.Bikes.Find(id);
            if (bike == null)
            {
                return HttpNotFound();
            }
            return View(bike);
        }

        // GET: Bikes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bikes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Bike_Id,Bike_Model,Description,Cost,Status")] Bike bike)
        {
            if (ModelState.IsValid)
            {
                db.Bikes.Add(bike);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bike);
        }

        // GET: Bikes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bike bike = db.Bikes.Find(id);
            if (bike == null)
            {
                return HttpNotFound();
            }
            return View(bike);
        }

        // POST: Bikes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Bike_Id,Bike_Model,Description,Cost,Status")] Bike bike)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bike).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bike);
        }

        // GET: Bikes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bike bike = db.Bikes.Find(id);
            if (bike == null)
            {
                return HttpNotFound();
            }
            return View(bike);
        }

        // POST: Bikes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bike bike = db.Bikes.Find(id);
            db.Bikes.Remove(bike);
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
