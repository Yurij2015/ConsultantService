using System.ComponentModel.DataAnnotations;

namespace ConsultationService.Models
{
    public class Consultation
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
