using AutoMapper;
using EmploymentSystem.Application.Common.Mappers;
using EmploymentSystem.Domain.Entities;
using EmploymentSystem.Domain.Entities.Vaccancy;
using EmploymentSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.DTOs
{
    public class JobApplicationDto : IMapFrom<JobApplication>
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string VacancyName { get; set; }
        public JobApplicationStatus Status { get; set; }
        public string CVBase64 { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<JobApplication , JobApplicationDto>()
                .ForMember(e=>e.Name,e=>e.MapFrom(e=>e.User.Name))
                .ForMember(e=>e.Phone,e=>e.MapFrom(e=>e.User.Phone))
                .ForMember(e=>e.Email,e=>e.MapFrom(e=>e.User.Email))
                .ForMember(e=>e.VacancyName,e=>e.MapFrom(e=>e.Vaccancy.Title))
                .ReverseMap();
        }
    }
}
