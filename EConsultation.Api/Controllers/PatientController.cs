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
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            this._patientService = patientService;
        }

        [HttpGet]
        public async Task<ActionResult> GetPatients()
        {
            try
            {
                return Ok(await _patientService.GetPatients());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the databse");
            }

        }
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            try
            {
                var result = await _patientService.GetPatient(id);
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
        [HttpGet("GetByEMailId/{UserLoginId}")]
        public async Task<ActionResult<Patient>> GetPatientByEMailId(string patientEMailId)
        {
            try
            {
                var result = await _patientService.GetPatientByEMailId(patientEMailId);
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

        [HttpPost]
        public async Task<ActionResult<Patient>> AddPatient(Patient patient)
        {
            try
            {
                if (patient == null)
                    return BadRequest();
               
                var addedpatient = await _patientService.AddPatient(patient);
                return addedpatient;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding new patient");
            }
        }


        [HttpPut("id/{id}")]
        public async Task<ActionResult<Patient>> Updatepatient(int id, Patient patient)
        {
            try
            {
                if (id != patient.PatientId)
                    return BadRequest("patient Id mismatch");

                var patienttoUpdate = await _patientService.GetPatient(id);
                if (patienttoUpdate == null)
                {
                    return NotFound($"patient with Id={id} not found");
                }

                return await _patientService.UpdatePatient(patient);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating new user");
            }
        }
    }
}
