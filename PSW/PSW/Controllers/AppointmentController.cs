using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PSW.DTO;
using PSW.Model;
using PSW.Service.AppointmentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Controllers
{

    [Produces("application/json")]

    [Route("appointment")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService appointmentService;

        public AppointmentController(IAppointmentService aService)
        {
            this.appointmentService = aService;
        }



        [Consumes("application/json")]
        [Produces("application/json")]
        [Authorize(Roles = "Patient")]
        [HttpPost("findByPriority")]
        public IActionResult FindByPriority([FromBody] AppointmentDTO appointmentDTO)
        {



            List<Appointment> retList = appointmentService.FindSuitableAppointments(appointmentDTO.DoctorName, appointmentDTO.DateLower, appointmentDTO.DateUpper);

            if (retList.Count == 0)
            {
                retList = appointmentService.FindDateByPriority(appointmentDTO.Priority,
                   appointmentDTO.DoctorName, appointmentDTO.DateLower, appointmentDTO.DateUpper);
            }
            IActionResult response;

            response = Ok(new
            {
                list = retList
            });

            return response;
        }



        [HttpGet("getappointment")]
        public List<Appointment> findAppointment(int Id)
        {
            List<Appointment> retList = appointmentService.GetByDoctorId(Id);
            IActionResult response;
            response = Ok(
                new
                {
                    list = retList
                });
            return retList;
        }

        [HttpPost("makeReservation")]
        public String MakeReservation(AppointmentDTO appointmentDTO)
        {
            String retVal = appointmentService.MakeAppointment(appointmentDTO);
            return retVal;
        }

        [HttpGet("findUsersAppointments/{email}")]
        public IActionResult FindUsersAppointments(String email)
        {
            IActionResult response;
            response = Ok(new
            {
                list = appointmentService.GetPatientsAppointments(email)
            });
            return response;
        }

        [HttpPost("cancelAppointment")]
        public String CancelAppointment([FromBody] CancelDTO cancel)
        {
            return appointmentService.CancelAppointment(cancel.Email, cancel.AppointmentId);
        }
    }
}
