using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Michaels_Stuff;
using Michaels_Stuff.Models;

namespace Michaels_Stuff.Controllers
{
    public class MediaReleasesController : Controller
    {
        private KendallsoftEntity db = new KendallsoftEntity();

        // GET: MediaReleases
        public ActionResult Index()
        {
            return View(db.MyMediaReleases.ToList());
        }

        // GET: MediaReleases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MediaRelease mediaRelease = db.MyMediaReleases.Find(id);
            if (mediaRelease == null)
            {
                return HttpNotFound();
            }
            return View(mediaRelease);
        }

        // GET: MediaReleases/Create
         [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //MKExplained
        [ChildActionOnly()]
        public PartialViewResult _MediaReleases(Int32 artistID)
        {
            return PartialView(db.MyPublications.Where(x => x.ArtistId==artistID));
        }

        // POST: MediaReleases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MediaId,MediaTitle")] MediaRelease mediaRelease)
        {
            if (ModelState.IsValid)
            {
                db.MyMediaReleases.Add(mediaRelease);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mediaRelease);
        }

        // GET: MediaReleases/Edit/5
         [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MediaRelease mediaRelease = db.MyMediaReleases.Find(id);
            if (mediaRelease == null)
            {
                return HttpNotFound();
            }
            return View(mediaRelease);
        }

        // POST: MediaReleases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MediaId,MediaTitle")] MediaRelease mediaRelease)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mediaRelease).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mediaRelease);
        }

        // GET: MediaReleases/Delete/5
         [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MediaRelease mediaRelease = db.MyMediaReleases.Find(id);
            if (mediaRelease == null)
            {
                return HttpNotFound();
            }
            return View(mediaRelease);
        }

        // POST: MediaReleases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MediaRelease mediaRelease = db.MyMediaReleases.Find(id);
            db.MyMediaReleases.Remove(mediaRelease);
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
