using PSW.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Service.CanceledAppointmentsService
{
    public interface ICanceledAppointmentsService
    {
        void AddNewCanceledAppointment(int patientId, DateTime date);

        void CheckIfPatientIsToxic(int patientId);

        public List<CanceledAppointment> GetCanceledAppointments();
    }
}
