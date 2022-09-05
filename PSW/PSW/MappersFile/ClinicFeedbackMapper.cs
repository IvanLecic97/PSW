using AutoMapper;
using PSW.DTO;
using PSW.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.MappersFile
{
    public class ClinicFeedbackMapper : Profile
    {
        public ClinicFeedbackMapper()
        {
            CreateMap<ClinicFeedback, ClinicFeedbackDTO>();
        }
    }
}
