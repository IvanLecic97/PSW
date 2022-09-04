using PSW.Model;
using PSW.Repository.CRUDRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Repository.IRepo
{
   public interface IClinicFeedbackRepository : ICRUDRepository<ClinicFeedback, int>
    {

        public ClinicFeedback FindByPatientEmail(string email);

    }
}
