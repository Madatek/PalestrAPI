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
using PalestrApi;

namespace PalestrApi.Controllers
{
    public class PalestresController : ApiController
    {
        private EntityModel db = new EntityModel();

        // GET: api/Palestres
        public IQueryable<Palestre> GetPalestre()
        {
            return db.Palestre;
        }

        // GET: api/Palestres/5
        [ResponseType(typeof(Palestre))]
        public IHttpActionResult GetPalestre(int id)
        {
            Palestre palestre = db.Palestre.Find(id);
            if (palestre == null)
            {
                return NotFound();
            }

            return Ok(palestre);
        }

        // PUT: api/Palestres/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPalestre(int id, Palestre palestre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != palestre.Id)
            {
                return BadRequest();
            }

            db.Entry(palestre).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PalestreExists(id))
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

        // POST: api/Palestres
        [ResponseType(typeof(Palestre))]
        public IHttpActionResult PostPalestre(Palestre palestre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Palestre.Add(palestre);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = palestre.Id }, palestre);
        }

        // DELETE: api/Palestres/5
        [ResponseType(typeof(Palestre))]
        public IHttpActionResult DeletePalestre(int id)
        {
            Palestre palestre = db.Palestre.Find(id);
            if (palestre == null)
            {
                return NotFound();
            }

            db.Palestre.Remove(palestre);
            db.SaveChanges();

            return Ok(palestre);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PalestreExists(int id)
        {
            return db.Palestre.Count(e => e.Id == id) > 0;
        }
    }
}