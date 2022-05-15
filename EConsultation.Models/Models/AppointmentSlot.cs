using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EConsultation.Models.Models
{
    public partial class AppointmentSlot
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SlotID { get; set; }
        [Required]
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public DateTime SlotTime { get; set; }
    }
}
