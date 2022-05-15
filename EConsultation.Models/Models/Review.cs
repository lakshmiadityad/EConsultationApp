using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EConsultation.Models.Models
{
    public partial class Review
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ReviewId { get; set; }
        [Required]
        public int AppointmentID { get; set; }
        [Required]
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        [Required]
        public int DoctorID { get; set; }
        public string Doctor { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
