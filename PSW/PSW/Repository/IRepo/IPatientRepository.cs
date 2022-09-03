using PSW.Repository.CRUDRepository;
using PSW.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Repository.IRepo
{
    public interface IPatientRepository : ICRUDRepository<Patient, int>
    {
        Patient FindByEmailAndPassword(string email, string password);

        Patient FindByEmail(string email);

        IEnumerable<Patient> FindBlockedAndBlockablePatients();
    }
}
