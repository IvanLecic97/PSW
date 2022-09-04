using PSW.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Service.ReferralService.cs
{
    public interface IReferralService
    {
        public String MakeSpecialistAppointment(ReferralDTO referralDTO);
    }
}
