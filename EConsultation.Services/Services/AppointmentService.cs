using EConsultation.Models.Context;
using EConsultation.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EConsultation.Services.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly EConsultContext _eConsultContext;

        public AppointmentService(EConsultContext eConsultContext)
        {
            this._eConsultContext = eConsultContext;
        }

        public async Task<Appointment> BookAppointment(Appointment appointment)
        {
            var result = await _eConsultContext.Appointments.AddAsync(appointment);
            await _eConsultContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Appointment> GetAppointment(string doctorName)
        {
            return await _eConsultContext.Appointments.FirstOrDefaultAsync(e => e.DoctorName == doctorName);
        }

        public async Task<IEnumerable<AppointmentSlot>> GetAppointmentSlots(int doctorId)
        {
            return await _eConsultContext.AppointmentSlots.Where(e => e.DoctorID == doctorId).ToListAsync();
        }
    }
}
