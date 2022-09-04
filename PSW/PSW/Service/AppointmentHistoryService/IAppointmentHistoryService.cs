using PSW.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Service.AppointmentHistoryService
{
    public interface IAppointmentHistoryService
    {
        public AppointmentHistoryDTO AddReview(AppointmentHistoryDTO appointmentHistoryDTO);
    }
}
