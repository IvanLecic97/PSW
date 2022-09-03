using PSW.DTO;
using PSW.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Converter
{
    public class PatientConverter
    {
        public static Patient DtoToPatient(PatientDTO PatientDTO)
        {
            Patient p = new();
            p.Address = PatientDTO.Address;
            p.Birthday = PatientDTO.Birthday;
            p.BloodType = PatientDTO.BloodType;
            p.City = PatientDTO.City;
            p.Email = PatientDTO.Email;
            p.HealthCard = PatientDTO.HealthCard;
            p.Id = PatientDTO.Id;
            p.IsBlockable = PatientDTO.IsBlockable;
            p.IsBlocked = PatientDTO.IsBlocked;
            p.MedicalRecordId = PatientDTO.MedicalRecordId;
            p.Name = PatientDTO.Name;
            p.Password = PatientDTO.Password;
            p.Phone = PatientDTO.Phone;
            p.Surname = PatientDTO.Surname;
            return p;

        }

        public static PatientDTO PatientToDto(Patient PatientDTO)
        {
            PatientDTO p = new();
            p.Address = PatientDTO.Address;
            p.Birthday = PatientDTO.Birthday;
            p.BloodType = PatientDTO.BloodType;
            p.City = PatientDTO.City;
            p.Email = PatientDTO.Email;
            p.HealthCard = PatientDTO.HealthCard;
            p.Id = PatientDTO.Id;
            p.IsBlockable = PatientDTO.IsBlockable;
            p.IsBlocked = PatientDTO.IsBlocked;
            p.MedicalRecordId = PatientDTO.MedicalRecordId;
            p.Name = PatientDTO.Name;
            p.Password = PatientDTO.Password;
            p.Phone = PatientDTO.Phone;
            p.Surname = PatientDTO.Surname;
            return p;
        }
    }
}
