using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Michaels_Stuff.Models;

namespace Michaels_Stuff
{
    public class MediaReleasesAPIController : ApiController
    {
        private KendallsoftEntity db = new KendallsoftEntity();

        // GET: api/MediaReleasesAPI
        public IQueryable<MediaRelease> GetMyMediaReleases()
        {
            return db.MyMediaReleases;
        }

        // GET: api/MediaReleasesAPI/5
        [ResponseType(typeof(MediaRelease))]
        public IHttpActionResult GetMediaRelease(int id)
        {
            MediaRelease mediaRelease = db.MyMediaReleases.Find(id);
            if (mediaRelease == null)
            {
                return NotFound();
            }

            return Ok(mediaRelease);
        }

        // PUT: api/MediaReleasesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMediaRelease(int id, MediaRelease mediaRelease)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mediaRelease.MediaId)
            {
                return BadRequest();
            }

            db.Entry(mediaRelease).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MediaReleaseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/MediaReleasesAPI
        [ResponseType(typeof(MediaRelease))]
        public IHttpActionResult PostMediaRelease(MediaRelease mediaRelease)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MyMediaReleases.Add(mediaRelease);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mediaRelease.MediaId }, mediaRelease);
        }

        // DELETE: api/MediaReleasesAPI/5
        [ResponseType(typeof(MediaRelease))]
        public IHttpActionResult DeleteMediaRelease(int id)
        {
            MediaRelease mediaRelease = db.MyMediaReleases.Find(id);
            if (mediaRelease == null)
            {
                return NotFound();
            }

            db.MyMediaReleases.Remove(mediaRelease);
            db.SaveChanges();

            return Ok(mediaRelease);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MediaReleaseExists(int id)
        {
            return db.MyMediaReleases.Count(e => e.MediaId == id) > 0;
        }
    }
}