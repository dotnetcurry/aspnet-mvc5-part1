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
using Michaels_Stuff;
using Michaels_Stuff.Models;

namespace Michaels_Stuff.Controllers
{
    public class PublicationsApiController : ApiController
    {
        private KendallsoftEntity db = new KendallsoftEntity();

        // GET: api/PublicationsApi
        public IQueryable<Publication> GetMyPublications()
        {
            return db.MyPublications;
        }

        // GET: api/PublicationsApi/5
        [ResponseType(typeof(Publication))]
        public IHttpActionResult GetPublication(int id)
        {
            Publication publication = db.MyPublications.Find(id);
            if (publication == null)
            {
                return NotFound();
            }

            return Ok(publication);
        }

        // PUT: api/PublicationsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPublication(int id, Publication publication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != publication.PublicationId)
            {
                return BadRequest();
            }

            db.Entry(publication).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicationExists(id))
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

        // POST: api/PublicationsApi
        [ResponseType(typeof(Publication))]
        public IHttpActionResult PostPublication(Publication publication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MyPublications.Add(publication);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = publication.PublicationId }, publication);
        }

        // DELETE: api/PublicationsApi/5
        [ResponseType(typeof(Publication))]
        public IHttpActionResult DeletePublication(int id)
        {
            Publication publication = db.MyPublications.Find(id);
            if (publication == null)
            {
                return NotFound();
            }

            db.MyPublications.Remove(publication);
            db.SaveChanges();

            return Ok(publication);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PublicationExists(int id)
        {
            return db.MyPublications.Count(e => e.PublicationId == id) > 0;
        }
    }
}