using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Model.Users
{
    public class Doctor : RegUser
    {
        public DoctorType DoctorType { get; set; }


        public Doctor() { }
    }
}
