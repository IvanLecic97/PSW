using PSW.Model;
using PSW.Repository.CRUDRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Repository.IRepo
{
   public interface IAppointmentRepository : ICRUDRepository<Appointment, int>
    {
        public Appointment FindByDoctorId(int id);
        public void UpdateAppointment(Appointment a);

        public List<Appointment> FindByPatientsId(int id);

        public List<Appointment> FindNotOverByDoctorId(int id);

        public List<Appointment> GetAllSpecialistAppointments();
    }
}
