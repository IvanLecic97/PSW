using PSW.DTO;
using PSW.Model;
using PSW.Model.Users;
using PSW.Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Service.AppointmentService
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository appointmentRepo;
        private readonly IDoctorRepository doctorRepository;
        private readonly IPatientRepository patientRepository;

        public AppointmentService(IAppointmentRepository repoBase, IDoctorRepository doctorRepository, IPatientRepository patientRepository)
        {
            this.appointmentRepo = repoBase;
            this.doctorRepository = doctorRepository;
            this.patientRepository = patientRepository;
        }

        public List<Appointment> FindByDate(String DateLower, String DateUpper, List<Appointment> appointments)
        {
            List<Appointment> appointmentsList = new List<Appointment>();
            DateTime d1 = DateTime.Parse(DateLower);
            DateTime d2 = DateTime.Parse(DateUpper);
            foreach (Appointment a in appointments)
            {
                if ((DateTime.Compare(a.Date, d1) > 0) &&
                   (DateTime.Compare(a.Date, d2) < 0))
                {
                    appointmentsList.Add(a);
                }
                else
                    if ((DateTime.Equals(a.Date.Date, d1.Date)) ||
                    (DateTime.Equals(a.Date.Date, d2.Date)))
                {
                    appointmentsList.Add(a);
                }
            }

            return appointmentsList;
        }

        public Appointment FindById(int id)
        {
            return appointmentRepo.FindById(id);
        }

        public List<Appointment> FindDateByPriority(string priority, String name, String DateLower, String DateUpper)
        {
            List<Appointment> retVal = new List<Appointment>();
            DateTime d1 = DateTime.Parse(DateLower);
            DateTime d2 = DateTime.Parse(DateUpper);


            String d3 = d1.AddDays(-10).ToString();
            String d4 = d2.AddDays(+10).ToString();
            if (priority.Equals("doctor"))
            {
                Doctor doctor = doctorRepository.FindByDoctorName(name);


                retVal = FindSuitableAppointments(doctor.Name, d3, d4);

            }
            else
                if (priority.Equals("time"))
            {
                List<Appointment> list = (List<Appointment>)appointmentRepo.FindAll();

                retVal = GetForTimeInterval(list, d1.ToString(), d2.ToString(), name);

            }

            return retVal;
        }

        public List<Appointment> GetForTimeInterval(List<Appointment> appointments, String DateLower, String DateUpper, String name)
        {
            List<Appointment> retVal = new List<Appointment>();
            DateTime d1 = DateTime.Parse(DateLower);
            DateTime d2 = DateTime.Parse(DateUpper);
            Doctor doctor = doctorRepository.FindByDoctorName(name);

            foreach (Appointment a in appointments)
            {
                if ((DateTime.Compare(a.Date, d1) > 0) &&
                   (DateTime.Compare(a.Date, d2) < 0) && (doctorRepository.FindById(a.DoctorId).DoctorType).Equals(doctor.DoctorType))
                {
                    retVal.Add(a);
                }
            }


            return retVal;
        }

        public List<Appointment> FindSuitableAppointments(String DoctorName, String DateLower, String DateUpper)
        {
            Doctor chosenDoctor = doctorRepository.FindByDoctorName(DoctorName);
            List<Appointment> appointments = GetByDoctorId(chosenDoctor.Id);
            List<Appointment> retList = FindByDate(DateLower, DateUpper, appointments);

            return retList;


        }

        public List<Appointment> GetByDoctorId(int id)
        {
            List<Appointment> appointments = (List<Appointment>)appointmentRepo.FindAll();
            List<Appointment> retList = new List<Appointment>();
            foreach (Appointment a in appointments)
            {
                if (a.DoctorId == id)
                {
                    retList.Add(a);
                }
            }
            return retList;
        }

        public String MakeAppointment(AppointmentDTO appointmentDTO)
        {
            Appointment a = appointmentRepo.FindById(appointmentDTO.appointmentId);
            Patient p = patientRepository.FindByEmail(appointmentDTO.patientUsername);
            a.IsTaken = true;
            a.PatientId = p.Id;
            appointmentRepo.UpdateAppointment(a);

            return "Appointment made!";
        }

        public List<Appointment> GetPatientsAppointments(String email)
        {
            Patient patient = patientRepository.FindByEmail(email);
            List<Appointment> Appointments = (List<Appointment>)appointmentRepo.FindAll();
            List<Appointment> RetVal = new();

            foreach (Appointment a in Appointments)
            {
                if (a.PatientId == patient.Id)
                {
                    RetVal.Add(a);

                }
            }

            return RetVal;

            //throw new NotImplementedException();
        }

        public string CancelAppointment(string email, int AppointmentId)
        {
            Appointment Appointment = appointmentRepo.FindById(AppointmentId);
            DateTime CurrentDate = DateTime.Now;
            if (CurrentDate.AddHours(48) < Appointment.Date)
            {
                Appointment.IsTaken = false;
                Appointment.PatientId = 0;
                appointmentRepo.UpdateAppointment(Appointment);
                return "Appointment canceled!!!";
            }
            else
            {
                return "You can't cancel an apointment which is in less than 48 hours!!!";
            }


            throw new NotImplementedException();
        }
    }
}
