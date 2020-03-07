using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ConsultationService.Models;

namespace ConsultantService.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("ConsultationConnection")
        {
        }

        public DbSet<Consultation> Consultations { get; set; }
    }
}