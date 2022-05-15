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
    public class PatientService : IPatientService
    {
        private readonly EConsultContext _eConsultContext;

        public PatientService(EConsultContext eConsultContext)
        {
            this._eConsultContext= eConsultContext;
        }

        public async Task<Patient> AddPatient(Patient patient)
        {
            try
            {
                var result = await _eConsultContext.Patients.AddAsync(patient);
                await _eConsultContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Patient> GetPatient(int id)
        {
            return await _eConsultContext.Patients.FirstOrDefaultAsync(e => e.PatientId == id);
        }

        public async Task<Patient> GetPatientByEMailId(string patientEmailId)
        {
            return await _eConsultContext.Patients.FirstOrDefaultAsync(e => e.EMailId == patientEmailId);
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _eConsultContext.Patients.ToListAsync();
        }

        public async Task<Patient> UpdatePatient(Patient patient)
        {

            var result = await _eConsultContext.Patients.FirstOrDefaultAsync(e => e.PatientId == patient.PatientId);
            if (result != null)
            {
                result.PatientName = patient.PatientName;
                result.MobileNum = patient.MobileNum;
                result.EMailId = patient.EMailId;
                result.Age = patient.Age;
                result.Gender = patient.Gender;
                result.BloodGroup = patient.BloodGroup;


                await _eConsultContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
