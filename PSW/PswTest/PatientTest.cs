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
   public class PatientTest
    {

        private readonly PatientService service = new(CreateMockedPatientRepository());

        [Fact]
        public Patient PatientLogin()
        {
            Patient patient = service.PatientLogin("email1@gmail.com", "123");
            Assert.NotNull(patient);
            return patient;
        }

        [Fact]
        public void GetAllPatients()
        {
            List<Patient> patients = service.FindAll();
            Assert.NotNull(patients);
        }

        [Fact]
        public void FindAllBlockedOrBlockable()
        {
            List<Patient> patients = service.FindAllBlockedOrBlockable();
            Assert.NotNull(patients);
        }


        [Fact]
        public Patient FindByEmail()
        {
            Patient patient = service.FindByEmail("email1@gmail.com");
            Assert.NotNull(patient);
            return patient;
        }


        private static IPatientRepository CreateMockedPatientRepository()
        {
            var MockedPatientRepository = new Mock<IPatientRepository>();
            var patients = new List<Patient>();
            var patients2 = new List<Patient>();

            Patient patient1 = new Patient();

            patient1.Address = "address1";
            patient1.Birthday = new DateTime();
            patient1.BloodType = "type1";
            patient1.City = "city1";
            patient1.Email = "email1@gmail.com";
            patient1.HealthCard = "card1";
            patient1.IsBlockable = false;
            patient1.IsBlocked = false;
            patient1.Name = "name1";
            patient1.Password = "123";
            patient1.Phone = "1234";
            patient1.Surname = "surname1";
            patients.Add(patient1);

            Patient patient2 = new();

            patient2.Address = "address2";
            patient2.Birthday = new DateTime().AddDays(3);
            patient2.BloodType = "type2";
            patient2.City = "city2";
            patient2.Email = "email2@gmail.com";
            patient2.HealthCard = "card2";
            patient2.IsBlockable = true;
            patient2.IsBlocked = false;
            patient2.Name = "name2";
            patient2.Password = "123";
            patient2.Phone = "12344";
            patient2.Surname = "surname2";

            patients2.Add(patient2);

            Patient patient3 = new();

            patient3.Address = "address3";
            patient3.Birthday = new DateTime().AddDays(12);
            patient3.BloodType = "type3";
            patient3.City = "city3";
            patient3.Email = "email3@gmail.com";
            patient3.HealthCard = "card3";
            patient3.IsBlockable = false;
            patient3.IsBlocked = true;
            patient3.Name = "name3";
            patient3.Password = "123";
            patient3.Phone = "12343";
            patient3.Surname = "surname3";

            patients2.Add(patient3);


            Patient patient4 = new();

            patient4.Address = "address4";
            patient4.Birthday = new DateTime().AddDays(122);
            patient4.BloodType = "type4";
            patient4.City = "city4";
            patient4.Email = "email4@gmail.com";
            patient4.HealthCard = "card4";
            patient4.IsBlockable = false;
            patient4.IsBlocked = true;
            patient4.Name = "name4";
            patient4.Password = "123";
            patient4.Phone = "12344";
            patient4.Surname = "surname4";


            MockedPatientRepository.Setup(repo => repo.FindAll()).Returns(patients);
            MockedPatientRepository.Setup(repo => repo.FindByEmailAndPassword(It.IsAny<String>(), It.IsAny<String>())).Returns(patient1);
            MockedPatientRepository.Setup(repo => repo.FindAllBlockableAndBlocked()).Returns(patients2);
            MockedPatientRepository.Setup(repo => repo.FindByEmail(It.IsAny<String>())).Returns(patient1);
            

            return MockedPatientRepository.Object;

        }


      /*  private static IPatientService CreateMockPatientService()
        {
            var mockService = new Mock<IPatientService>();
            return (IPatientService)mockService;
        } */
    }
}
