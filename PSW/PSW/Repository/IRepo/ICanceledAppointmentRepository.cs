using PSW.Model;
using PSW.Repository.CRUDRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Repository.IRepo
{
    public interface ICanceledAppointmentRepository : ICRUDRepository<CanceledAppointment, int>
    {
        List<CanceledAppointment> FindAllByPatientId(int id);

        List<CanceledAppointment> FindAllByPatientIdDescending(int id);

    }
}
