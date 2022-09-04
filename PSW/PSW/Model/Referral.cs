using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Model
{
    public class Referral
    {
        public int Id { get; set; }

        public String Text { get; set; }

        public int FamilyDoctorId { get; set; }

        public int SpecialistId { get; set; }

        public int PatientId { get; set; }

        public DateTime AppointmentTime { get; set; }

        public int AppointmentId { get; set; }

        public String FileName { get; set; }

        public Referral(string text, int familyDoctorId, int specialistId, int patientId, DateTime appointmentTime, int appointmentId, String fileName)
        {
            Text = text;
            FamilyDoctorId = familyDoctorId;
            SpecialistId = specialistId;
            PatientId = patientId;
            AppointmentTime = appointmentTime;
            AppointmentId = appointmentId;
            FileName = fileName;
        }

        public Referral(int id, string text, int familyDoctorId, int specialistId, int patientId, DateTime appointmentTime, int appointmentId, String fileName)
        {
            Id = id;
            Text = text;
            FamilyDoctorId = familyDoctorId;
            SpecialistId = specialistId;
            PatientId = patientId;
            AppointmentTime = appointmentTime;
            AppointmentId = appointmentId;
            FileName = FileName;
        }

        public Referral() { }
    }
}
