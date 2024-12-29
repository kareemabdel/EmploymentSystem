using AutoMapper;
using EmploymentSystem.Application.Common.Mappers;
using EmploymentSystem.Domain.Entities.Vaccancy;
using EmploymentSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.DTOs
{
    public class EditVaccancyDto : IMapFrom<Vaccancy>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int MaxApplications { get; set; }
        public DateTime ExpiredDate { get; set; }
        public VaccancyStatusEnum Status { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<EditVaccancyDto, Vaccancy>().ReverseMap();
        }
    }
}
