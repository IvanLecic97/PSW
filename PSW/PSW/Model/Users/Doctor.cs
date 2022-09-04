using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Model.Users
{
    public class Doctor : RegUser
    {
        public String DoctorType { get; set; }


        public Doctor() { }
    }
}
