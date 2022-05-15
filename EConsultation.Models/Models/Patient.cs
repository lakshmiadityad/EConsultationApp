using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EConsultation.Models.Models
{
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int PatientId { get; set; }
        [Required]
        public string PatientName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string MobileNum { get; set; }
        public string EMailId { get; set; }
        public string Gender { get; set; }
        public string BloodGroup { get; set; }

    }
}
