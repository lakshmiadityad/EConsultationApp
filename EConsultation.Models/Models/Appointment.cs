using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EConsultation.Models.Models
{
    public partial class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int AppointmentId { get; set; }
        [Required]
        public string PatientName { get; set; }
        [Required]
        public string DoctorName { get; set; }
        [Required]
        public DateTime? AppoinmentDate { get; set; }

        public string PatientPhoneNumber { get; set; }
    }
}
