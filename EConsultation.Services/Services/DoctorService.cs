using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EConsultation.Models.Context;
using EConsultation.Models.Models;
using EConsultation.Services.Services;
using Microsoft.EntityFrameworkCore;

namespace EConsultation.Services.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly EConsultContext _eConsultContext;

        public DoctorService(EConsultContext eConsultContext)
        {
            this._eConsultContext = eConsultContext;
        }

        public async Task<Doctor> AddDoctor(Doctor doctor)
        {
            try
            {
                var result = await _eConsultContext.Doctors.AddAsync(doctor);
                await _eConsultContext.SaveChangesAsync();
                return result.Entity;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Doctor> GetDoctor(int id)
        {
            return await _eConsultContext.Doctors.FirstOrDefaultAsync(e => e.DoctorId == id);
        }

        public async Task<Doctor> GetDoctorByEMailId(string doctorEmailId)
        {
            return await _eConsultContext.Doctors.FirstOrDefaultAsync(e => e.EMailId == doctorEmailId);
        }

        public async Task<IEnumerable<Doctor>> GetDoctorBySpec(string specialization)
        {
            return await _eConsultContext.Doctors.Where(e => e.Specialization == specialization).ToListAsync();
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _eConsultContext.Doctors.ToListAsync();
        }

        public async Task<Doctor> UpdateDoctor(Doctor doctor)
        {
            var result = await _eConsultContext.Doctors.FirstOrDefaultAsync(e => e.DoctorId == doctor.DoctorId);
            if (result != null)
            {
                result.DoctorName = doctor.DoctorName;
                result.MobileNum = doctor.MobileNum;
                result.EMailId = doctor.EMailId;
                result.Experience = doctor.Experience;
                result.Specialization = doctor.Specialization;
                result.ConsultationFee = doctor.ConsultationFee;


                await _eConsultContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
