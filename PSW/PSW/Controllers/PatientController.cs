using AutoMapper;
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
        private readonly IMapper mapper;



    public PatientController(IPatientService patientService, IClinicFeedbackService clinicFeedbackService, 
        ICanceledAppointmentsService canceledAppointmentsService, IMapper mapper)
    {
        this.patientService = patientService;
        this.clinicFeedbackService = clinicFeedbackService;
        this.canceledAppointmentsService = canceledAppointmentsService;
            this.mapper = mapper;
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


    [Authorize(Roles = "Admin")]
    [HttpGet("allToxic")]
    public IActionResult GetAllToxicPatients()
        {
            IActionResult response;
            List<PatientDTO> retList = new();
            foreach(Patient p in patientService.FindAllBlockedOrBlockable()){
                PatientDTO patient = mapper.Map<PatientDTO>(p);
                retList.Add(patient);
            } 
            response = Ok(new {
                list = retList
            });
            return response;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("block")]
        public IActionResult BlockPatient([FromBody] PatientDTO patientDTO)
        {
            IActionResult response = Ok(new
            {
                response = patientService.BlockPatient(patientDTO)
            });
            return response;
            
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("unblock")]
        public IActionResult UnBlockPatient([FromBody] PatientDTO patientDTO)
        {
            IActionResult response = Ok(new
            {
                response = patientService.UnblockPatient(patientDTO)
            });
            return response;

        }


        [Authorize(Roles = "Admin")]
        [HttpPost("removeFromToxic")]
        public IActionResult RemoveFromToxic([FromBody] PatientDTO patientDTO)
        {
            IActionResult response = Ok(new
            {
                response = patientService.RemoveFromToxicList(patientDTO)
            });
            return response;

        }



    }
}
