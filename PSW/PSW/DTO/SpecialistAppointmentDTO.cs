using PSW.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.DTO
{
    public class SpecialistAppointmentDTO
    {
        public Appointment Appointment { get; set; }

        public String Name { get; set; }

        public String Surname { get; set; }

        public SpecialistAppointmentDTO() { }
    }
}
