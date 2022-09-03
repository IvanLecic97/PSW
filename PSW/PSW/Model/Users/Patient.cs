using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Model.Users
{
    public class Patient : RegUser
    {
        public string BloodType { get; set; }
        public string HealthCard { get; set; }

        public bool IsBlocked { get; set; }
        public bool IsBlockable { get; set; }

        public int MedicalRecordId { get; set; }


        public Patient()
        {

        }

        public Patient(string bloodType, string healthCard, bool isBlocked, bool isBlockable)
        {
            this.BloodType = bloodType;
            this.HealthCard = healthCard;
            IsBlocked = isBlocked;
            IsBlockable = isBlockable;
        }
    }
}
