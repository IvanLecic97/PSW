using PSW.Model;
using PSW.Repository.CRUDRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PSW.Repository.IRepo
{
 public interface IAppointmentHistoryRepository : ICRUDRepository<AppointmentHistory, int>
    {
       
        
        

    }
}
