using PSW.Model;
using PSW.Model.MyDbContext;
using PSW.Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Repository.Repo
{
    public class AppointmentRepoBase : IAppointmentRepository
    {
        private readonly MyDbContext myDbContext;

        public AppointmentRepoBase(MyDbContext context)
        {
            this.myDbContext = context;
        }

        public int Count()
        {
            return myDbContext.Appointments.ToList().Count;
        }

        public void Delete(Appointment entity)
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

        public IEnumerable<Appointment> FindAll()
        {
            return myDbContext.Appointments.ToList();
        }

        public IEnumerable<Appointment> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public Appointment FindByDoctorId(int id)
        {
            return myDbContext.Appointments.SingleOrDefault((Appointment appointment) => appointment.DoctorId == id);
        }

        public Appointment FindById(int id)
        {
            return myDbContext.Appointments.SingleOrDefault((Appointment appointment) => appointment.Id == id);
        }

        public List<Appointment> FindByPatientsId(int id)
        {
            // return myDbContext.Appointments.AsEnumerable((Appointment appointment) => appointment.PatientId == id);
            throw new NotImplementedException();
        }

        public void Save(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public void SaveAll(IEnumerable<Appointment> entities)
        {
            throw new NotImplementedException();
        }

        public void UpdateAppointment(Appointment a)
        {

            myDbContext.Appointments.Update(a);
            myDbContext.SaveChanges();
        }
    }
}
