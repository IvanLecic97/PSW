using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            Appointment Appointment = FindById(entity.Id);
            if (Appointment == null)
            {
                myDbContext.Appointments.Add(Appointment);
            }
            else myDbContext.Appointments.Update(Appointment);
            myDbContext.SaveChanges();
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

        public List<Appointment> FindNotOverByDoctorId(int id)
        {
            var list1 = myDbContext.Appointments;
            var list2 = list1.Where(e => e.IsOver == false && e.DoctorId.Equals(id));
            // return myDbContext.Appointments.Where(e => e.IsOver == false && e.Id.Equals(id)).ToList();
            List<Appointment> retList = new();
            foreach(Appointment a in list2)
            {
                retList.Add(a);
            }
            return retList;
           
        }

        public List<Appointment> GetAllSpecialistAppointments()
        {
            var list1 = myDbContext.Appointments;
            var list2 = list1.Where(e => e.DoctorType.Equals("Specialist")).Where(b => b.IsTaken == false);
            List<Appointment> retList = new();
            foreach(Appointment a in list2)
            {
                retList.Add(a);
            }
            return retList;
        }



    }
}
