using PSW.Model;
using PSW.Repository.CRUDRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Repository.IRepo
{
    public interface IReferralRepository : ICRUDRepository<Referral, int>
    {
        
        public Referral FindByAppointmentId(int id);

        public void DeleteByAppointmentId(int id);
    }
}
