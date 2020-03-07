using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using ConsultantService.Models;
using System.Data.Entity;
using ConsultationService.Models;

namespace ConsultantService.Controllers
{
    public class ConsultationsController : ApiController
    {
        ApplicationContext db = new ApplicationContext();

        public IEnumerable<Consultation> Get()
        {
            return db.Consultations.ToList();
        }

        public Consultation Get(int id)
        {
            return db.Consultations.Find(id);
        }

        public IHttpActionResult Post([FromBody]Consultation consultation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Consultations.Add(consultation);
            db.SaveChanges();
            return Ok(consultation);
        }

        public IHttpActionResult Put([FromBody]Consultation consultation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(consultation).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(consultation);
        }

        public IHttpActionResult Delete(int id)
        {
            Consultation consultation = db.Consultations.Find(id);
            if (consultation != null)
            {
                db.Consultations.Remove(consultation);
                db.SaveChanges();
                return Ok(consultation);
            }
            return NotFound();
        }
    }
}