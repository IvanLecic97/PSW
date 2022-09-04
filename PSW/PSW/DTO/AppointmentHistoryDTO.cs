using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.DTO
{
    public class AppointmentHistoryDTO
    {
        public String AppointmentComment { get; set; }

        public double DoctorGrade { get; set; }

        public int PatientId { get; set; }

        public int AppointmentId { get; set; }

        public AppointmentHistoryDTO(string appointmentComment, double doctorGrade, int appointmentId)
        {
            AppointmentComment = appointmentComment;
            DoctorGrade = doctorGrade;
            AppointmentId = appointmentId;
        }
    }
}
