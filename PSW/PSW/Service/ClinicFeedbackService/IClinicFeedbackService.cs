using PSW.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Service.ClinicFeedbackService
{
    public interface IClinicFeedbackService
    {
        public ClinicFeedbackDTO AddNewFeedback(ClinicFeedbackDTO clinicFeedbackDTO);
    }
}
