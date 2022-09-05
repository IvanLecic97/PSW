using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.DTO
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public DateTime Birthday { get; set; }


        public string BloodType { get; set; }
        public string HealthCard { get; set; }

        public bool IsBlocked { get; set; }
        public bool IsBlockable { get; set; }


        public PatientDTO() { }

    }
}
