using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PSW.DTO;
using PSW.Model.Users;
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


    public PatientController(IPatientService patientService, IClinicFeedbackService clinicFeedbackService)
    {
        this.patientService = patientService;
        this.clinicFeedbackService = clinicFeedbackService;
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


     


}
}
