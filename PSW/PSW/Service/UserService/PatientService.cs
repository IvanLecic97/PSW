using PSW.Converter;
using PSW.DTO;
using PSW.Model.Users;
using PSW.Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Service.UserService
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository patientRepository;


        public PatientService(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }


        public bool AddPatient(PatientDTO patientDTOForRegistration)
        {
            Patient patientForRegistration = PatientConverter.DtoToPatient(patientDTOForRegistration);

            if (patientRepository.FindByEmail(patientForRegistration.Email) == null)
            {
                patientForRegistration.Id = patientRepository.Count() + 1;
                DateTime date = (DateTime)patientDTOForRegistration.Birthday;
                patientDTOForRegistration.Birthday = date.Date;
                SavePatient(patientForRegistration);
                return true;
            }
            return false;
        }



        public List<Patient> FindAll()
        {
            return (List<Patient>)patientRepository.FindAll();
        }

        public List<Patient> FindAllBlockedOrBlockable()
        {
            return patientRepository.FindAllBlockableAndBlocked();
        }

        public Patient FindByEmail(string email)
        {
            return patientRepository.FindByEmail(email);
        }

        public Patient FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Patient PatientLogin(string email, string password)
        {
            Patient patient = patientRepository.FindByEmailAndPassword(email, password);
            if (patient != null)
            {
                return patient;
            }
            return null;
        }

        public void SavePatient(Patient patient)
        {
            patientRepository.Save(patient);
        }




    }
}
