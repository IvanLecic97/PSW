using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSW.Repository.IRepo;
using PSW.Model.Users;
using PSW.Model.MyDbContext;
using PSW.Repository.CRUDRepository;

namespace PSW.Repository.Repo
{
    public class PatientRepoBase : IPatientRepository
    {
        private readonly MyDbContext dbContext;

        public PatientRepoBase(MyDbContext context)
        {
            this.dbContext = context;
        }

        public int Count()
        {
            return dbContext.Patients.ToList().Count;
        }

        public void Delete(Patient entity)
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

        public IEnumerable<Patient> FindAll()
        {
            return dbContext.Patients.ToList();
        }

        public IEnumerable<Patient> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> FindBlockedAndBlockablePatients()
        {
            throw new NotImplementedException();
        }

        public Patient FindByEmail(string email)
        {

            return dbContext.Patients.SingleOrDefault((Patient patient) => patient.Email.ToLower().Equals(email.ToLower()));
        }

        public Patient FindByEmailAndPassword(string email, string password)
        {
            return dbContext.Patients.SingleOrDefault((Patient patient) => patient.Email.ToLower().Equals(email.ToLower()) && patient.Password.Equals(password));
        }

        public Patient FindById(int id)
        {
            return dbContext.Patients.SingleOrDefault((Patient patient) => patient.Id == id);
        }

        public void Save(Patient entity)
        {
            if (FindByEmail(entity.Email) == null)
                dbContext.Patients.Add(entity);
            else
                dbContext.Patients.Update(entity);
            dbContext.SaveChanges();
        }

        public void SaveAll(IEnumerable<Patient> entities)
        {
            throw new NotImplementedException();
        }

        
    }
}
