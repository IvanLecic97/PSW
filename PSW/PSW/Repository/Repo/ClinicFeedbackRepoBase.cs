using PSW.Model;
using PSW.Model.MyDbContext;
using PSW.Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Repository.Repo
{
    public class ClinicFeedbackRepoBase : IClinicFeedbackRepository
    {

        private readonly MyDbContext dbContext;


        public ClinicFeedbackRepoBase(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(ClinicFeedback entity)
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

        public IEnumerable<ClinicFeedback> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClinicFeedback> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public ClinicFeedback FindById(int id)
        {
            return dbContext.ClinicFeedbacks.SingleOrDefault((ClinicFeedback ClinicFeedback) => ClinicFeedback.Id == id );
        }

        public void Save(ClinicFeedback entity)
        {
            if (FindById(entity.Id) == null)
            {
                dbContext.ClinicFeedbacks.Add(entity);
            }
            else
                dbContext.ClinicFeedbacks.Update(entity);
            dbContext.SaveChanges();
        }

        public void SaveAll(IEnumerable<ClinicFeedback> entities)
        {
            throw new NotImplementedException();
        }

        public ClinicFeedback FindByPatientEmail(string email)
        {
            return dbContext.ClinicFeedbacks.SingleOrDefault((ClinicFeedback feedback) => feedback.PatientUsername.Equals(email) );
        }
    }
}
