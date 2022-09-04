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
                ClinicFeedback ClinicFeedback = new ClinicFeedback(clinicFeedbackDTO.Text, clinicFeedbackDTO.Rating, clinicFeedbackDTO.Anonymous, clinicFeedbackDTO.PatientUsername);

                clinicFeedbackRepository.Save(ClinicFeedback);

                return new ClinicFeedbackDTO(ClinicFeedback.Text, ClinicFeedback.Rating, ClinicFeedback.Anonymous, ClinicFeedback.PatientUsername);

            }

            else return null; 
        }
    }
}
