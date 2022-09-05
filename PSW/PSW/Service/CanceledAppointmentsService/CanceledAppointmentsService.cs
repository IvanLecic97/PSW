using PSW.Model;
using PSW.Model.Users;
using PSW.Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Service.CanceledAppointmentsService
{
    public class CanceledAppointmentsService : ICanceledAppointmentsService
    {
        private readonly IAppointmentRepository appointmentRepository;
        private readonly ICanceledAppointmentRepository canceledAppointmentRepository;
        private readonly IPatientRepository patientRepository;

        public CanceledAppointmentsService(IAppointmentRepository appointmentRepository, ICanceledAppointmentRepository canceledAppointmentRepository,
            IPatientRepository patientRepository)
        {
            this.appointmentRepository = appointmentRepository;
            this.canceledAppointmentRepository = canceledAppointmentRepository;
            this.patientRepository = patientRepository;
        }

        public void AddNewCanceledAppointment(int patientId, DateTime date)
        {
            CanceledAppointment CanceledAppointment = new();
            CanceledAppointment.PatientId = patientId;
            CanceledAppointment.CancellationDate = date;
            canceledAppointmentRepository.Save(CanceledAppointment);
            CheckIfPatientIsToxic(patientId);

        }

        public void CheckIfPatientIsToxic(int patientId)
        {
            Patient Patient = patientRepository.FindById(patientId);
            List<CanceledAppointment> List1 = canceledAppointmentRepository.FindAllByPatientId(patientId);
            List<CanceledAppointment> List2 = canceledAppointmentRepository.FindAllByPatientIdDescending(patientId);
            int CancelNumber = 0;
            foreach(CanceledAppointment c1 in List1)
            {
                CancelNumber = 0;
                foreach(CanceledAppointment c2 in List2)
                {
                    if(c1.CancellationDate.AddDays(30) > c2.CancellationDate)
                    {
                        CancelNumber += 1;
                        if(CancelNumber >=3)
                        {
                            Patient.IsBlockable = true;
                            patientRepository.Save(Patient);
                            return;
                        }
                    }
                }

            }

        }

        public List<CanceledAppointment> GetCanceledAppointments()
        {
            return canceledAppointmentRepository.FindAllByPatientId(1);
        }

    }
}
