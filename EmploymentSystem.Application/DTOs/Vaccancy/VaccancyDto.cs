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
    public class VaccancyDto : IMapFrom<Vaccancy>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public VaccancyStatusEnum Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<VaccancyDto, Vaccancy>().ReverseMap();
        }
    }
}
