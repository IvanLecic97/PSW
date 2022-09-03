using PSW.Model.Users;
using PSW.Repository.CRUDRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Repository.IRepo
{
    public interface IDoctorRepository : ICRUDRepository<Doctor, int>
    {
        public Doctor FindByDoctorName(String name);
    }
}
