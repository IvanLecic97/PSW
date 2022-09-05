using PSW.DTO;
using PSW.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Service.ClinicFeedbackService
{
    public interface IClinicFeedbackService
    {
        public ClinicFeedbackDTO AddNewFeedback(ClinicFeedbackDTO clinicFeedbackDTO);

        public IEnumerable<ClinicFeedback> GetAllFeedbacks();

        public String ChangeApproval(ClinicFeedbackDTO clinicFeedbackDTO);

        public List<ClinicFeedback> GetAllApprovedByAdmin();

        public List<ClinicFeedback> GetAll();



    }
}
