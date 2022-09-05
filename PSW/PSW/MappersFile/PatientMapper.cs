using AutoMapper;
using PSW.DTO;
using PSW.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.MappersFile
{
    public class PatientMapper : Profile
    {

        public PatientMapper()
        {
            CreateMap<Patient, PatientDTO>();
           // CreateMap<List<Patient>, List<PatientDTO>>();
        }
        
        
    }
}
