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
    public class PublicationsController : Controller
    {
        private KendallsoftEntity db = new KendallsoftEntity();

        // GET: Publications
        public ActionResult Index()
        {
            var myPublications = db.MyPublications.Include(p => p.Artist).Include(p => p.MediaRelease);
            return View(myPublications.ToList());
        }

        // GET: Publications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publication publication = db.MyPublications.Find(id);
            if (publication == null)
            {
                return HttpNotFound();
            }
            return View(publication);
        }

        // GET: Publications/Create
         [Authorize]
        public ActionResult Create()
        {
            ViewBag.ArtistId = new SelectList(db.MyArtists, "ArtistId", "LastName");
            ViewBag.MediaId = new SelectList(db.MyMediaReleases, "MediaId", "MediaTitle");
            return View();
        }

        // POST: Publications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PublicationId,ArtistId,MediaId,DateReleased")] Publication publication)
        {
            if (ModelState.IsValid)
            {
                db.MyPublications.Add(publication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistId = new SelectList(db.MyArtists, "ArtistId", "LastName", publication.ArtistId);
            ViewBag.MediaId = new SelectList(db.MyMediaReleases, "MediaId", "MediaTitle", publication.MediaId);
            return View(publication);
        }

        // GET: Publications/Edit/5
         [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publication publication = db.MyPublications.Find(id);
            if (publication == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistId = new SelectList(db.MyArtists, "ArtistId", "LastName", publication.ArtistId);
            ViewBag.MediaId = new SelectList(db.MyMediaReleases, "MediaId", "MediaTitle", publication.MediaId);
            return View(publication);
        }

        // POST: Publications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PublicationId,ArtistId,MediaId,DateReleased")] Publication publication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistId = new SelectList(db.MyArtists, "ArtistId", "LastName", publication.ArtistId);
            ViewBag.MediaId = new SelectList(db.MyMediaReleases, "MediaId", "MediaTitle", publication.MediaId);
            return View(publication);
        }

        // GET: Publications/Delete/5
         [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publication publication = db.MyPublications.Find(id);
            if (publication == null)
            {
                return HttpNotFound();
            }
            return View(publication);
        }

        // POST: Publications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Publication publication = db.MyPublications.Find(id);
            db.MyPublications.Remove(publication);
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
