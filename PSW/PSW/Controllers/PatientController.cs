using Microsoft.AspNetCore.Mvc;
using PSW.DTO;
using PSW.Model.Users;
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


    public PatientController(IPatientService patientService)
    {
        this.patientService = patientService;
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

}
}
