using PSW.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Service.UserService
{
    public interface IAdminService
    {
        public Admin LoginAdmin(String email, String password);
    }
}
