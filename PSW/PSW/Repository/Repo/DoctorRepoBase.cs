using PSW.Model.MyDbContext;
using PSW.Model.Users;
using PSW.Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Repository.Repo
{
    public class DoctorRepoBase : IDoctorRepository
    {

        private readonly MyDbContext dbContext;

        public DoctorRepoBase(MyDbContext context)
        {
            this.dbContext = context;
        }


        public int Count()
        {
            return dbContext.Doctors.ToList().Count;
        }

        public void Delete(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int identificator)
        {
            throw new NotImplementedException();
        }

        public bool ExistsById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public Doctor FindByDoctorName(string name)
        {
            return dbContext.Doctors.SingleOrDefault((Doctor doctor) => doctor.Name.Equals(name));
        }

        public Doctor FindByEmail(string name)
        {
            return dbContext.Doctors.SingleOrDefault((Doctor doctor) => doctor.Email.Equals(name));
        }



        // public Doctor GetBranchFromId(int id)
        // {
        //     return dbContext.Doctors.SingleOrDefault((String specialty) => );
        // }

        public Doctor FindById(int id)
        {
            return dbContext.Doctors.SingleOrDefault((Doctor doctor) => doctor.Id == id);
        }

        public void Save(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public void SaveAll(IEnumerable<Doctor> entities)
        {
            throw new NotImplementedException();
        }

        public Doctor FindByEmailAndPassword(string name, string password)
        {
            return dbContext.Doctors.SingleOrDefault((Doctor doctor) => doctor.Email.Equals(name) && doctor.Password.Equals(password));
        }
    }
}
