using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PSW.DTO;
using PSW.Model;
using PSW.Model.Users;
using PSW.Service.CanceledAppointmentsService;
using PSW.Service.ClinicFeedbackService;
using PSW.Service.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Controllers { 
    
    [Produces("application/json")]
    [Route("patients")]
    [ApiController]
    public class PatientController : ControllerBase
    {
    private readonly IPatientService patientService;
    private readonly IClinicFeedbackService clinicFeedbackService;
        private readonly ICanceledAppointmentsService canceledAppointmentsService;


    public PatientController(IPatientService patientService, IClinicFeedbackService clinicFeedbackService, ICanceledAppointmentsService canceledAppointmentsService)
    {
        this.patientService = patientService;
        this.clinicFeedbackService = clinicFeedbackService;
        this.canceledAppointmentsService = canceledAppointmentsService;
    }


    [HttpPost("register")]
    public IActionResult Register([FromBody] PatientDTO patientDTO)
    {
        patientService.AddPatient(patientDTO);
        return Ok();
    }

    [HttpGet("getUsers")]
    public List<Patient> getAll()
    {
        return patientService.FindAll().ToList();
    }

    [Authorize(Roles = "Patient")]
    [HttpPost("addClinicFeedback")]
    public IActionResult AddClinicFeedback([FromBody] ClinicFeedbackDTO clinicFeedbackDTO)
    {
            IActionResult response;
            response = Ok(new
            {
                feedback = clinicFeedbackService.AddNewFeedback(clinicFeedbackDTO)
            }
                );

            return response;
    }

    
    [AllowAnonymous]
    [HttpGet("getCanceled")]
    public List<CanceledAppointment> GetCanceledAppointments()
        {
            return canceledAppointmentsService.GetCanceledAppointments();
        }


    [HttpGet("allToxic")]
    public IActionResult GetAllToxicPatients()
        {
            IActionResult response;
            response = Ok(new {
                list = patientService.FindAllBlockedOrBlockable()
            });
            return response;
        }



     


    }
}
