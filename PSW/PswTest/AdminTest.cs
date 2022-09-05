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
    public class AdminTest
    {
        private readonly AdminService service = new(CreateMockAdminRepository());


        [Fact]
        public Admin LoginAdmin()
        {
            Admin admin = service.LoginAdmin("admin1@gmail.com", "123");
            Assert.NotNull(admin);
            return admin;
        }



        private static IAdminRepository CreateMockAdminRepository()
        {
            var MockedRepository = new Mock<IAdminRepository>();

            Admin admin = new();
            admin.Address = "address1";
            admin.Birthday = new DateTime();
            admin.City = "city1";
            admin.Email = "admin1@gmail.com";
            admin.Name = "name1";
            admin.Password = "123";
            admin.Phone = "1234566";
            admin.Surname = "surname1";
            admin.Id = 1;

            MockedRepository.Setup(repo => repo.FindByEmailAndPassword(It.IsAny<String>(), It.IsAny<String>())).Returns(admin);


            return MockedRepository.Object;

        }
    }
}
