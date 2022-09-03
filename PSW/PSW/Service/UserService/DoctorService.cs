using PSW.Model.Users;
using PSW.Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Service.UserService
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }

        public Doctor LoginDoctor(String email, String password)
        {
            Doctor Doctor = doctorRepository.FindByEmailAndPassword(email, password);
            if (Doctor != null)
            {
                return Doctor;
            }
            else return null;

        }

        public Doctor FindById(int id)
        {
            Doctor Doctor = doctorRepository.FindById(id);
            if (Doctor != null)
            {
                return Doctor;
            }
            else return null;
        }


    }
}
