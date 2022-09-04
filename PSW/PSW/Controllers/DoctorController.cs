using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PSW.Model.Users;
using PSW.Repository.IRepo;
using PSW.Service.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Controllers
{

    [Produces("application/json")]

    [Route("doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository DoctorRepository;
        private readonly IDoctorService DoctorService;

        public DoctorController(IDoctorRepository doctorRepository, IDoctorService doctorService)
        {
            this.DoctorRepository = doctorRepository;
            this.DoctorService = doctorService;
        }

        [Authorize(Roles = "Doctor")]
        [HttpGet("getDoctorById/{id}")]
        public IActionResult GetDoctorById(int id)
        {
            Doctor doctor = DoctorService.FindById(id);
            IActionResult response;
            response = Ok(new
            {
                name = doctor.Name,
                surname = doctor.Surname
            });
            return response;
        }

    }
}
