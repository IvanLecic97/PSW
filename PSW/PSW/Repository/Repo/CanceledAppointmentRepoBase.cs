using PSW.Model;
using PSW.Model.MyDbContext;
using PSW.Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Repository.Repo
{
    public class CanceledAppointmentRepoBase : ICanceledAppointmentRepository
    {

        private readonly MyDbContext dbContext;

        public CanceledAppointmentRepoBase(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(CanceledAppointment entity)
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

        public IEnumerable<CanceledAppointment> FindAll()
        {
            return dbContext.CanceledAppointments.ToList();
        }

        public IEnumerable<CanceledAppointment> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public List<CanceledAppointment> FindAllByPatientId(int id)
        {
            IEnumerable<CanceledAppointment> list1 = FindAll().Where(e => e.PatientId == id);
            List<CanceledAppointment> retList = new();
            foreach (CanceledAppointment c in list1)
            {
                retList.Add(c);
            }
            return retList;
        }

        public List<CanceledAppointment> FindAllByPatientIdDescending(int id)
        {
            IEnumerable<CanceledAppointment> list1 = FindAll().Where(e => e.PatientId == id).OrderByDescending(b => b.CancellationDate);
            List<CanceledAppointment> retList = new();
            foreach (CanceledAppointment c in list1)
            {
                retList.Add(c);
            }
            return retList;
        }

        public CanceledAppointment FindById(int id)
        {
            return dbContext.CanceledAppointments.SingleOrDefault(e=> e.Id == id);
        }

        public void Save(CanceledAppointment entity)
        {
            CanceledAppointment CanceledAppointment = FindById(entity.Id);
            if (CanceledAppointment == null)
            {
                dbContext.CanceledAppointments.Add(entity);
            }
            else dbContext.CanceledAppointments.Update(entity);

            dbContext.SaveChanges();

        }

        public void SaveAll(IEnumerable<CanceledAppointment> entities)
        {
            throw new NotImplementedException();
        }

       
    }
}
