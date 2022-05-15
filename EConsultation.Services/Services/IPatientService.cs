using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EConsultation.Models.Models;

namespace EConsultation.Services.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient> GetPatient(int id);

        Task<Patient> GetPatientByEMailId(string patientEmailId);
        Task<Patient> AddPatient(Patient patient);
        Task<Patient> UpdatePatient(Patient patient);

    }
}
