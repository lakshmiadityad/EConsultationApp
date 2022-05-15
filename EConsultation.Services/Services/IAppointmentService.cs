using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EConsultation.Models.Models;

namespace EConsultation.Services.Services
{
    public interface IAppointmentService
    {
        public Task<IEnumerable<AppointmentSlot>> GetAppointmentSlots(int doctorId);
        public Task<Appointment> GetAppointment(string doctorName);

        public Task<Appointment> BookAppointment(Appointment appointment);
    }
}
