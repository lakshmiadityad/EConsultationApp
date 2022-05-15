using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EConsultation.Models.Models
{
    public partial class Doctor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]

        public int DoctorId { get; set; }
        [Required]
        public string DoctorName { get; set; }
        public string MobileNum { get; set; }
        public string EMailId { get; set; }
        public int Experience { get; set; }
        [Required]
        public string Specialization { get; set; }

        public int ConsultationFee { get; set; }
    }
}
