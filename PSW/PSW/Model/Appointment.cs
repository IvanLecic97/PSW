using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Model
{
    public class Appointment
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int DoctorId { get; set; }


        public bool IsTaken { get; set; }

        public int PatientId { get; set; }

        public bool IsOver { get; set; }

        public String DoctorType { get; set; }

        public bool IsRewieved { get; set; }

    }
}
