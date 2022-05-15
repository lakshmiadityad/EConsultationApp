using Microsoft.EntityFrameworkCore;
using EConsultation.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EConsultation.Models.Context
{
    public partial class EConsultContext:DbContext
    {
        public EConsultContext(DbContextOptions<EConsultContext> options)
         : base(options)
        {
        }
        public virtual DbSet<Appointment> Appointments { get; set; }

        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }

        public virtual DbSet<AppointmentSlot> AppointmentSlots { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
    }
}
