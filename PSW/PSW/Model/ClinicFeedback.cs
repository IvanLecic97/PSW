using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Model
{
    public class ClinicFeedback
    {
        public int Id { get; set; }

        public String Text { get; set; }

        public double Rating { get; set; }

        public bool Anonymous { get; set; }

        public String PatientUsername { get; set; }

        public ClinicFeedback(string text, double rating, bool anonymous, string patientUsername)
        {
            Text = text;
            Rating = rating;
            Anonymous = anonymous;
            PatientUsername =  patientUsername;
        }

        public ClinicFeedback(int id, string text, double rating, bool anonymous, string patientUsername)
        {
            Id = id;
            Text = text;
            Rating = rating;
            Anonymous = anonymous;
            PatientUsername = patientUsername;
        }

        public ClinicFeedback() { }
    }
}
