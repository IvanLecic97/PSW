using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PSW.DTO;
using PSW.Service.ClinicFeedbackService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Controllers
{


    [Produces("application/json")]

    [Route("feedback")]
    [ApiController]
    public class ClinicFeedbackController : ControllerBase
    {
        private readonly IClinicFeedbackService clinicFeedbackService;

        public ClinicFeedbackController(IClinicFeedbackService clinicFeedbackService)
        {
            this.clinicFeedbackService = clinicFeedbackService;
        }


        [Authorize(Roles = "Admin")]
        [HttpGet("all")]
        public IActionResult GetAllFeedbacks()
        {
            IActionResult response = Ok(new { 
                feedbacks = clinicFeedbackService.GetAllFeedbacks()
            });

            return response;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("approval")]
        public IActionResult ChangeApproval([FromBody] ClinicFeedbackDTO clinicFeedbackDTO)
        {
            IActionResult response = Ok(new
            {
                response = clinicFeedbackService.ChangeApproval(clinicFeedbackDTO)
            });

            return response;
        }




    }
}
