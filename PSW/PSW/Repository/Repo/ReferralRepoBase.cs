using PSW.Model;
using PSW.Model.MyDbContext;
using PSW.Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Repository.Repo
{
    public class ReferralRepoBase : IReferralRepository
    {

        private readonly MyDbContext dbContext;

        public ReferralRepoBase(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(Referral entity)
        {
            dbContext.Referrals.Remove(entity);
            dbContext.SaveChanges();
        }

        public void DeleteByAppointmentId(int id)
        {
            dbContext.Referrals.Remove(dbContext.Referrals.Single(a => a.AppointmentId == id));
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int identificator)
        {
            throw new NotImplementedException();
        }

        

        public Referral FindByAppointmentId(int id)
        {
            return dbContext.Referrals.SingleOrDefault((Referral referral) => referral.Id.Equals(id));

        }

        public bool ExistsById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Referral> FindAll()
        {
           return dbContext.Referrals.ToList();
        }

        public IEnumerable<Referral> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public Referral FindById(int id)
        {
            return dbContext.Referrals.SingleOrDefault((Referral referral) => referral.Id.Equals(id));
        }

        public void Save(Referral entity)
        {
            if (FindById(entity.Id) == null)
            {
                dbContext.Referrals.Add(entity);
            }
            else dbContext.Referrals.Update(entity);
            dbContext.SaveChanges();
        }

        public void SaveAll(IEnumerable<Referral> entities)
        {
            throw new NotImplementedException();
        }
    }
}
