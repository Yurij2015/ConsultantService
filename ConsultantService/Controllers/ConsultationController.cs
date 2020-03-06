using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using ConsultantService.Models;
using System.Data.Entity;

namespace ConsultantService.Controllers
{
    public class ConsultationController : ApiController
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
            Consultation friend = db.Consultations.Find(id);
            if (friend != null)
            {
                db.Consultations.Remove(friend);
                db.SaveChanges();
                return Ok(friend);
            }
            return NotFound();
        }
    }
}