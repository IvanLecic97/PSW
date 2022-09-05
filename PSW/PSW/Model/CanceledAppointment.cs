using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Model
{
    public class CanceledAppointment
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public DateTime CancellationDate { get; set; }

        public CanceledAppointment() { }
    }
}
