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
using ConsultantService.Models;

namespace ConsultantService.Controllers
{
    public class ConsultantsController : ApiController
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: api/Consultants
        public IQueryable<Consultant> GetConsultants()
        {
            return db.Consultants;
        }

        // GET: api/Consultants/5
        [ResponseType(typeof(Consultant))]
        public IHttpActionResult GetConsultant(int id)
        {
            Consultant consultant = db.Consultants.Find(id);
            if (consultant == null)
            {
                return NotFound();
            }

            return Ok(consultant);
        }

        // PUT: api/Consultants/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConsultant(int id, Consultant consultant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != consultant.Id)
            {
                return BadRequest();
            }

            db.Entry(consultant).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultantExists(id))
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

        // POST: api/Consultants
        [ResponseType(typeof(Consultant))]
        public IHttpActionResult PostConsultant(Consultant consultant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Consultants.Add(consultant);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = consultant.Id }, consultant);
        }

        // DELETE: api/Consultants/5
        [ResponseType(typeof(Consultant))]
        public IHttpActionResult DeleteConsultant(int id)
        {
            Consultant consultant = db.Consultants.Find(id);
            if (consultant == null)
            {
                return NotFound();
            }

            db.Consultants.Remove(consultant);
            db.SaveChanges();

            return Ok(consultant);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConsultantExists(int id)
        {
            return db.Consultants.Count(e => e.Id == id) > 0;
        }
    }
}