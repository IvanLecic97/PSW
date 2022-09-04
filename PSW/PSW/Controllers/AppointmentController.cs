using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PSW.DTO;
using PSW.Model;
using PSW.Model.Users;
using PSW.Service.AppointmentService;
using PSW.Service.ReferralService.cs;
using PSW.Service.UserService;
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
        private readonly IDoctorService doctorService;
        private readonly IReferralService referralService;

        public AppointmentController(IAppointmentService aService, IDoctorService doctorService, IReferralService referralService)
        {
            this.appointmentService = aService;
            this.doctorService = doctorService;
            this.referralService = referralService;
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



        [Authorize(Roles = "Patient")]
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

        [Authorize(Roles = "Patient")]
        [HttpPost("makeReservation")]
        public String MakeReservation(AppointmentDTO appointmentDTO)
        {
            String retVal = appointmentService.MakeAppointment(appointmentDTO);
            return retVal;
        }

        [Authorize(Roles = "Patient")]
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

        [Authorize(Roles ="Patient")]
        [HttpPost("cancelAppointment")]
        public String CancelAppointment([FromBody] CancelDTO cancel)
        {
            return appointmentService.CancelAppointment(cancel.Email, cancel.AppointmentId);
        }

        [Authorize(Roles = "Doctor")]
        [HttpGet("getDoctorsAppointments/{email}")]
        public IActionResult FindDoctorsAppointments(String email)
        {
            IActionResult response;
            response = Ok(new
            {
                list = appointmentService.GetDoctorsNotOverAppointments(email)
            });
            return response;
        }

        [Authorize(Roles = "Doctor")]
        [HttpGet("getSpecialistAppointments")]
        public IActionResult FindSpecialistAppointments()
        {

            IActionResult response;
            List<SpecialistAppointmentDTO> retList = new();

            foreach(Appointment a in appointmentService.GetAllSpecialistAppointments())
            {
                Doctor doctor = doctorService.FindById(a.DoctorId);
                SpecialistAppointmentDTO specialistAppointmentDTO = new();
                specialistAppointmentDTO.Appointment = a;
                specialistAppointmentDTO.Name = doctor.Name;
                specialistAppointmentDTO.Surname = doctor.Surname;

                retList.Add(specialistAppointmentDTO);
            }
           
            response = Ok(new
            {
                list = retList
            });
            return response;
        }

        [Authorize(Roles = "Doctor")]
        [HttpPost("newReferral")]
        public IActionResult NewReferral([FromBody] ReferralDTO referralDTO)
        {
            IActionResult response;

            response = Ok(new
            {
                list = referralService.MakeSpecialistAppointment(referralDTO)
            });
            return response;
        }

    }
}
