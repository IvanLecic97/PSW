using PSW.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Service.UserService
{
    public interface IDoctorService
    {


        public Doctor LoginDoctor(String email, String password);

        public Doctor FindById(int id);
    }
}
