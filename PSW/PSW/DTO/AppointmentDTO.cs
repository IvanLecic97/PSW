using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.DTO
{
    public class AppointmentDTO
    {
        [JsonProperty("dateUpper")]
        public String DateUpper { get; set; }
        [JsonProperty("dateLower")]
        public String DateLower { get; set; }

        [JsonProperty("doctorName")]
        public String DoctorName { get; set; }
        [JsonProperty("priority")]
        public String Priority { get; set; }

        [JsonProperty("appointmentID")]
        public int appointmentId { get; set; }

        [JsonProperty("patientId")]
        public String patientUsername { get; set; }


        public AppointmentDTO() { }
    }
}
