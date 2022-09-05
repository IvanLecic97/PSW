using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.DTO
{
    public class ClinicFeedbackDTO
    {
        public int Id { get; set; }

        public String Text { get; set; }

        public double Rating { get; set; }

        public bool Anonymous { get; set; }

        public String PatientUsername { get; set; }

        public bool AdminApproval { get; set; }


        public ClinicFeedbackDTO() { }

        public ClinicFeedbackDTO(string text, double rating, bool anonymous, string patientUsername)
        {
            Text = text;
            Rating = rating;
            Anonymous = anonymous;
            PatientUsername = patientUsername;
        }
    }
}
