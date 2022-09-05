using Moq;
using PSW.DTO;
using PSW.Model;
using PSW.Repository.IRepo;
using PSW.Service.AppointmentHistoryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PswTest
{
    public class AppointmentHistoryTest
    {

        private readonly AppointmentHistoryService service = new(CreateMockAppointmentHistoryRepository(), CreateMockAppointmentRepository());


        [Fact]
        public AppointmentHistoryDTO AddReview()
        {
            AppointmentHistoryDTO appointmentDTO = new();
            appointmentDTO.AppointmentComment = "comment";
            appointmentDTO.AppointmentId = 1;
            appointmentDTO.DoctorGrade = 9;

            Assert.NotNull(service.AddReview(appointmentDTO));
            return appointmentDTO;



        }




        public static IAppointmentHistoryRepository CreateMockAppointmentHistoryRepository()
        {
            var MockedRepository = new Mock<IAppointmentHistoryRepository>();


            AppointmentHistory appointmentHistory = new();
            appointmentHistory.AppointmentComment = "comment";
            appointmentHistory.AppointmentId = 1;
            appointmentHistory.DoctorRating = 9;

            MockedRepository.Setup(repo => repo.Save(It.IsAny<AppointmentHistory>())).Verifiable();
            return MockedRepository.Object;
        }

        public static IAppointmentRepository CreateMockAppointmentRepository()
        {
            var MockedRepository = new Mock<IAppointmentRepository>();

            Appointment appointment = new();

            appointment.Date = new DateTime();
            appointment.DoctorId = 1;
            appointment.DoctorType = "Family";
            appointment.Id = 1;
            appointment.IsOver = false;
            appointment.IsRewieved = false;
            appointment.IsTaken = false;
            appointment.PatientId = 1;


            MockedRepository.Setup(repo => repo.UpdateAppointment(It.IsAny<Appointment>())).Verifiable();
            MockedRepository.Setup(repo => repo.FindById(It.IsAny<int>())).Returns(appointment);

            return MockedRepository.Object;
        }


    }
}
