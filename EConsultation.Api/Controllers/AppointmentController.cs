using EConsultation.Models.Models;
using EConsultation.Services.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using EConsultation.Models.Context;

namespace EConsultation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            this._appointmentService = appointmentService;
        }
        [HttpGet("GetByDoctorId/{doctorId}")]
        public async Task<ActionResult<AppointmentSlot>> GetAppointmentSlots(int doctorId)
        {
            try
            {
                return Ok(await _appointmentService.GetAppointmentSlots(doctorId));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the databse");
            }
            //try
            //{
            //    var result = await _appointmentService.GetAppointmentSlots(doctorId);
            //    if (result == null)
            //    {
            //        return NotFound();
            //    }
            //    return result;
            //}
            //catch (Exception)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the databse");
            //}
        }
        [HttpPost]
        public async Task<ActionResult<Appointment>> BookAppointment(Appointment appointment)
        {
            try
            {
                if (appointment == null)
                    return BadRequest();
                var bookedappointment = await _appointmentService.BookAppointment(appointment);
                return bookedappointment;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error booking new appointment");
            }


        }
    }
}

