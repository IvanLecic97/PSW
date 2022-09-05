using Moq;
using PSW.Model.Users;
using PSW.Repository.IRepo;
using PSW.Service.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PswTest
{
   public class DoctorTest
    {
        private readonly DoctorService service = new(CreateMockedDoctorRepository());

        [Fact]
        public Doctor FindById()
        {
            Doctor doctor = service.FindById(1);
            Assert.NotNull(doctor);
            return doctor;
        }


        [Fact]
        public Doctor LoginDoctor()
        {
            Doctor doctor = service.LoginDoctor("doctor1@gmail.com", "123");
            Assert.NotNull(doctor);
            return doctor;
        }


        private static IDoctorRepository CreateMockedDoctorRepository()
        {
            var MockedDoctorRepository = new Mock<IDoctorRepository>();

            Doctor doctor = new();
            doctor.Address = "address1";
            doctor.Birthday = new DateTime();
            doctor.City = "city1";
            doctor.DoctorType = "Family";
            doctor.Email = "doctor1@gmail.com";
            doctor.Name = "name1";
            doctor.Password = "123";
            doctor.Phone = "1234566";
            doctor.Surname = "surname1";
            doctor.Id = 1;

            MockedDoctorRepository.Setup(repo => repo.FindById(It.IsAny<int>())).Returns(doctor);
            MockedDoctorRepository.Setup(repo => repo.FindByEmailAndPassword(It.IsAny<String>(), It.IsAny<String>())).Returns(doctor);


            return MockedDoctorRepository.Object;
        }
    }
}
