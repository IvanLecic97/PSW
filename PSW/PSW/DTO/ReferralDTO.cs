using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.DTO
{
    public class ReferralDTO
    {
        public int Id { get; set; }

        public int FamilyDoctorId { get; set; }

        public int SpecialistId { get; set; }

        public int PatientId { get; set; }

        public DateTime Date { get; set; }

        public String DateString { get; set; }

        public int AppointmentId { get; set; }

        public int FamilyDoctorAppointmentId { get; set; }

        public String Text { get; set; }

        public String FamilyDoctorEmail { get; set; }

        public ReferralDTO() { }

    }
}
