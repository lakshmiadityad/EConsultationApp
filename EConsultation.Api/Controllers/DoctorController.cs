using EConsultation.Models.Models;
using EConsultation.Services.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EConsultation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            this._doctorService=doctorService;
        }
        [HttpGet]
        public async Task<ActionResult> GetDoctors()
        {
            try
            {
                return Ok(await _doctorService.GetDoctors());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the databse");
            }

        }
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            try
            {
                var result = await _doctorService.GetDoctor(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the databse");
            }

        }

        [HttpGet("GetByEMailId")]
        public async Task<ActionResult<Doctor>> GetDoctorByEMailId(string doctorEMailId)
        {
            try
            {
                var result = await _doctorService.GetDoctorByEMailId(doctorEMailId);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the databse");
            }
        }

        [EnableCors]
        [HttpGet("GetBySpec")]
        public async Task<ActionResult<Doctor>> GetDoctorBySpec(string specialization)
        {
            try
            {
                return Ok(await _doctorService.GetDoctorBySpec(specialization));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the databse");
            }
        }


        [HttpPost]
        public async Task<ActionResult<Doctor>> AddDoctor(Doctor doctor)
        {
            try
            {
                if (doctor == null)
                    return BadRequest();
               
                var addedDoctor = await _doctorService.AddDoctor(doctor);
                return addedDoctor;

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding new doctor");
            }
        }


        [HttpPut("id/{id}")]
        public async Task<ActionResult<Doctor>> UpdateDoctor(int id, Doctor doctor)
        {
            try
            {
                if (id != doctor.DoctorId)
                    return BadRequest("Doctor Id mismatch");

                var doctortoUpdate = await _doctorService.GetDoctor(id);
                if (doctortoUpdate == null)
                {
                    return NotFound($"Doctor with Id={id} not found");
                }

                return await _doctorService.UpdateDoctor(doctor);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating new user");
            }
        }

    }
}
