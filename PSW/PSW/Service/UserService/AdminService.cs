using PSW.Model.Users;
using PSW.Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Service.UserService
{
    public class AdminService : IAdminService
    {

        private readonly IAdminRepository adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            this.adminRepository = adminRepository;
        }

        public Admin LoginAdmin(string email, string password)
        {
            Admin Admin = adminRepository.FindByEmailAndPassword(email, password);
            if (Admin != null)
            {
                return Admin;
            }
            else return null;

        }
    }
}
