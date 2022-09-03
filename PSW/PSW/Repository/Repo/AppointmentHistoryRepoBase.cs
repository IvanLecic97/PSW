using PSW.Model;
using PSW.Model.MyDbContext;
using PSW.Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Repository.Repo
{
    public class AppointmentHistoryRepoBase : IAppointmentHistoryRepository
    {
        private readonly MyDbContext myDbContext;

        public AppointmentHistoryRepoBase(MyDbContext context)
        {
            this.myDbContext = context;
        }

        public int Count()
        {
            return myDbContext.AppointmentHistory.ToList().Count;
        }

        public void Delete(AppointmentHistory entity)
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

        public IEnumerable<AppointmentHistory> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AppointmentHistory> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public AppointmentHistory FindById(int id)
        {
            return myDbContext.AppointmentHistory.SingleOrDefault((AppointmentHistory appointmentHistory) => appointmentHistory.Id == id);
        }

        public void Save(AppointmentHistory entity)
        {
            throw new NotImplementedException();
        }

        public void SaveAll(IEnumerable<AppointmentHistory> entities)
        {
            throw new NotImplementedException();
        }
    }
}
