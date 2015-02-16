using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Michaels_Stuff.Models;

namespace Michaels_Stuff.Controllers
{
    public class KendallsoftsController : Controller
    {
        private Michaels_StuffContext db = new Michaels_StuffContext();

        // GET: Kendallsofts
        public ActionResult Index()
        {
            return View(db.Kendallsofts.ToList());
        }

        // GET: Kendallsofts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kendallsoft kendallsoft = db.Kendallsofts.Find(id);
            if (kendallsoft == null)
            {
                return HttpNotFound();
            }
            return View(kendallsoft);
        }

        // GET: Kendallsofts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kendallsofts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Companyid,CompanyName,CEO")] Kendallsoft kendallsoft)
        {
            if (ModelState.IsValid)
            {
                db.Kendallsofts.Add(kendallsoft);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kendallsoft);
        }

        // GET: Kendallsofts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kendallsoft kendallsoft = db.Kendallsofts.Find(id);
            if (kendallsoft == null)
            {
                return HttpNotFound();
            }
            return View(kendallsoft);
        }

        // POST: Kendallsofts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Companyid,CompanyName,CEO")] Kendallsoft kendallsoft)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kendallsoft).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kendallsoft);
        }

        // GET: Kendallsofts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kendallsoft kendallsoft = db.Kendallsofts.Find(id);
            if (kendallsoft == null)
            {
                return HttpNotFound();
            }
            return View(kendallsoft);
        }

        // POST: Kendallsofts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kendallsoft kendallsoft = db.Kendallsofts.Find(id);
            db.Kendallsofts.Remove(kendallsoft);
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
