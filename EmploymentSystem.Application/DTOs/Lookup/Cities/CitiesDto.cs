using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using EmploymentSystem.Application.Common.Mappers;
using EmploymentSystem.Domain.Entities;

namespace EmploymentSystem.Application.DTOs
{
    public class CitiesDto : IMapFrom<City>
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string EnglishDescription { get; set; }
        public string ArabicDescription { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CitiesDto, City>().ReverseMap();   
        }
    }
}
