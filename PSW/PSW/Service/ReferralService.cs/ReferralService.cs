using PSW.DTO;
using PSW.Model;
using PSW.Repository.IRepo;
using PSW.Service.AppointmentService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace PSW.Service.ReferralService.cs
{
    public class ReferralService : IReferralService
    {


        private readonly IReferralRepository ReferralRepository;
        private readonly IPatientRepository patientRepository;
        private readonly IAppointmentRepository appointmentRepository;
        private readonly IDoctorRepository doctorRepository;
        private readonly IAppointmentService appointmentService;
        

       public ReferralService(IReferralRepository referralRepository, IPatientRepository patientRepository, IAppointmentRepository appointmentRepository, 
           IDoctorRepository doctorRepository, IAppointmentService appointmentService)
       {
            this.ReferralRepository = referralRepository;
            this.patientRepository = patientRepository;
            this.appointmentRepository = appointmentRepository;
            this.doctorRepository = doctorRepository;
            this.appointmentService = appointmentService;
       }

        public string MakeSpecialistAppointment(ReferralDTO referralDTO)
        {


             AppointmentDTO AppointmentDTO = new();
             if(appointmentRepository.FindById(referralDTO.AppointmentId).IsTaken == true || appointmentRepository.FindById(referralDTO.AppointmentId).IsOver == true )
             {
                 return "That appointment is already taken or over!";
             } else
            {
                Random random = new();
                int number = random.Next(0, 10000);
                String FileName = number.ToString();

                AppointmentDTO.appointmentId = referralDTO.AppointmentId;
                AppointmentDTO.patientUsername = patientRepository.FindById(referralDTO.PatientId).Email;
                String returnValueAppointment = appointmentService.MakeAppointment(AppointmentDTO);
                
                String name = patientRepository.FindById(referralDTO.PatientId).Name +
                   "_" + FileName
                   + ".txt";

                Referral referral = new Referral(referralDTO.Text, doctorRepository.FindByEmail(referralDTO.FamilyDoctorEmail).Id, referralDTO.SpecialistId, referralDTO.PatientId,
                    referralDTO.Date, referralDTO.AppointmentId, name);

                Appointment appointment = appointmentRepository.FindById(referralDTO.AppointmentId);
                appointment.IsOver = true;

                appointmentRepository.Save(appointment);
                ReferralRepository.Save(referral);


                String path = @"C:\Users\ika_l\Desktop\KONACNOPSW\PSW\PSW\PSW\Referrals\" + name;
                try
                {
                    using (FileStream fs = File.Create(path))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes(referralDTO.Text);
                        fs.Write(info, 0, referralDTO.Text.Length);
                        return "Success";
                    }
                }
                catch (Exception ex)
                {
                    return "Failed";
                }

              }

            





            

           
        }
    }
}
