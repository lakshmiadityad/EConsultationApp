using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EConsultation.Models.Models;

namespace EConsultation.Services.Services
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor> GetDoctor(int id);
        Task<IEnumerable<Doctor>> GetDoctorBySpec(string specialization);
        Task<Doctor> GetDoctorByEMailId(string doctorEmailId);
        Task<Doctor> AddDoctor(Doctor doctor);
        Task<Doctor> UpdateDoctor(Doctor doctor);
    }
}
