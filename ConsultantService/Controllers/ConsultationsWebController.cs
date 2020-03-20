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
using ConsultationService.Models;

namespace ConsultantService.Controllers
{
    public class ConsultationsWebController : ApiController
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: api/ConsultationsWeb
        public IQueryable<Consultation> GetConsultations()
        {
            return db.Consultations;
        }

        // GET: api/ConsultationsWeb/5
        [ResponseType(typeof(Consultation))]
        public IHttpActionResult GetConsultation(int id)
        {
            Consultation consultation = db.Consultations.Find(id);
            if (consultation == null)
            {
                return NotFound();
            }

            return Ok(consultation);
        }

        // PUT: api/ConsultationsWeb/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConsultation(int id, Consultation consultation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != consultation.Id)
            {
                return BadRequest();
            }

            db.Entry(consultation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultationExists(id))
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

        // POST: api/ConsultationsWeb
        [ResponseType(typeof(Consultation))]
        public IHttpActionResult PostConsultation(Consultation consultation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Consultations.Add(consultation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = consultation.Id }, consultation);
        }

        // DELETE: api/ConsultationsWeb/5
        [ResponseType(typeof(Consultation))]
        public IHttpActionResult DeleteConsultation(int id)
        {
            Consultation consultation = db.Consultations.Find(id);
            if (consultation == null)
            {
                return NotFound();
            }

            db.Consultations.Remove(consultation);
            db.SaveChanges();

            return Ok(consultation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConsultationExists(int id)
        {
            return db.Consultations.Count(e => e.Id == id) > 0;
        }
    }
}