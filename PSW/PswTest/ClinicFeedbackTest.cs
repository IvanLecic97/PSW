using Moq;
using PSW.DTO;
using PSW.Model;
using PSW.Repository.IRepo;
using PSW.Service.ClinicFeedbackService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;

namespace PswTest
{
    public class ClinicFeedbackTest
    {
        private readonly ClinicFeedbackService service = new(CreateMockClinickRepository());


        [Fact]
        public ClinicFeedbackDTO AddNewFeedback()
        {
            ClinicFeedbackDTO clinicFeedbackDTO = new();

            clinicFeedbackDTO.AdminApproval = true;
            clinicFeedbackDTO.Anonymous = false;
            clinicFeedbackDTO.Id = 1;
            clinicFeedbackDTO.PatientUsername = "patient@gmail.com";
            clinicFeedbackDTO.Rating = 9;
            clinicFeedbackDTO.Text = "text";


            ClinicFeedbackDTO dto = service.AddNewFeedback(clinicFeedbackDTO);
            Assert.NotNull(dto);
            return dto;

        }
        [Fact]
        public void GetAllFeedbacks()
        {
            IEnumerable<ClinicFeedback> clinicFeedbacks = service.GetAllFeedbacks();
            clinicFeedbacks.Count().ShouldBe(1);
        }

        [Fact]
        public void ChangeApproval()
        {
            ClinicFeedbackDTO clinicFeedbackDTO = new();
            clinicFeedbackDTO.Id = 1;
            ClinicFeedbackDTO dto = service.AddNewFeedback(clinicFeedbackDTO);
            Assert.True(dto.AdminApproval == false);


        }


        



        private static IClinicFeedbackRepository CreateMockClinickRepository()
        {
            var MockedRepository = new Mock<IClinicFeedbackRepository>();
            var feedbacks = new List<ClinicFeedback>();

            ClinicFeedback clinicFeedback = new();
            clinicFeedback.AdminApproval = true;
            clinicFeedback.Anonymous = false;
            clinicFeedback.Id = 1;
            clinicFeedback.PatientUsername = "patient@gmail.com";
            clinicFeedback.Rating = 9;
            clinicFeedback.Text = "text";

            feedbacks.Add(clinicFeedback);

            ClinicFeedback cf1 = null;

            MockedRepository.Setup(repo => repo.FindByPatientEmail(It.IsAny<String>())).Returns(cf1);
            MockedRepository.Setup(repo => repo.Save(It.IsAny<ClinicFeedback>())).Verifiable();
            MockedRepository.Setup(repo => repo.FindAll()).Returns(feedbacks);
            MockedRepository.Setup(repo => repo.FindById(It.IsAny<int>())).Returns(clinicFeedback);
            MockedRepository.Setup(repo => repo.Save(It.IsAny<ClinicFeedback>())).Verifiable();



            return MockedRepository.Object;
        }
    }
}
