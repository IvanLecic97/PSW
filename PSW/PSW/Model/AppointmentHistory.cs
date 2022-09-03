using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Model
{
    public class AppointmentHistory
    {
        public int Id { get; set; }

        public int AppointmentId { get; set; }

        public String AppointmentComment { get; set; }

        public double DoctorRating { get; set; }
    }
}
