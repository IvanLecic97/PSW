using PSW.DTO;
using PSW.Model;
using PSW.Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Service.ClinicFeedbackService
{
    public class ClinicFeedbackService : IClinicFeedbackService
    {
        private readonly IClinicFeedbackRepository clinicFeedbackRepository;

        public ClinicFeedbackService(IClinicFeedbackRepository clinicFeedbackRepository)
        {
            this.clinicFeedbackRepository = clinicFeedbackRepository;
        }

        public ClinicFeedbackDTO AddNewFeedback(ClinicFeedbackDTO clinicFeedbackDTO)
        {

            if (clinicFeedbackRepository.FindByPatientEmail(clinicFeedbackDTO.PatientUsername) == null)
            {
                ClinicFeedback ClinicFeedback = new ClinicFeedback(clinicFeedbackDTO.Text, clinicFeedbackDTO.Rating, clinicFeedbackDTO.Anonymous, clinicFeedbackDTO.PatientUsername, false);

                clinicFeedbackRepository.Save(ClinicFeedback);

                return new ClinicFeedbackDTO(ClinicFeedback.Text, ClinicFeedback.Rating, ClinicFeedback.Anonymous, ClinicFeedback.PatientUsername);

            }

            else return null; 
        }

        public IEnumerable<ClinicFeedback> GetAllFeedbacks()
        {
            return clinicFeedbackRepository.FindAll();
        }

        public String ChangeApproval(ClinicFeedbackDTO clinicFeedbackDTO)
        {
            ClinicFeedback Feedback = clinicFeedbackRepository.FindById(clinicFeedbackDTO.Id);
            if (Feedback != null)
            {
                Feedback.AdminApproval = !Feedback.AdminApproval;
                clinicFeedbackRepository.Save(Feedback);
                return "Approval changed";
            }
            else return "Feedback does not exist";

        }


    }
}
