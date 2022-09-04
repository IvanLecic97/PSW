using PSW.DTO;
using PSW.Repository;
using PSW.Repository.IRepo;
using PSW.Service.AppointmentHistoryService;
using PSW.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Service.AppointmentHistoryService
{
    public class AppointmentHistoryService : IAppointmentHistoryService
    {

        private readonly IAppointmentHistoryRepository appointmentHistoryRepository;
        private readonly IAppointmentRepository appointmentRepository;

        public AppointmentHistoryService(IAppointmentHistoryRepository appointmentHistoryRepository, IAppointmentRepository appointmentRepository)
        {
            this.appointmentHistoryRepository = appointmentHistoryRepository;
            this.appointmentRepository = appointmentRepository;
        }

        public AppointmentHistoryDTO AddReview(AppointmentHistoryDTO appointmentHistoryDTO)
        {
            Appointment appointment = appointmentRepository.FindById(appointmentHistoryDTO.AppointmentId);

            if (appointment.IsRewieved == false)
            {
                AppointmentHistory AppointmentHistory = new AppointmentHistory(appointmentHistoryDTO.AppointmentId, appointmentHistoryDTO.AppointmentComment, appointmentHistoryDTO.DoctorGrade);

                appointment.IsRewieved = true;

                appointmentRepository.UpdateAppointment(appointment);
                appointmentHistoryRepository.Save(AppointmentHistory);

                return new AppointmentHistoryDTO(AppointmentHistory.AppointmentComment, AppointmentHistory.DoctorRating, AppointmentHistory.AppointmentId);
            }
            else return null;

            

           
        }
    }
}
