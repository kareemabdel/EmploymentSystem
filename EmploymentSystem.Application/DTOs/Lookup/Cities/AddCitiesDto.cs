using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using EmploymentSystem.Application.Common.Mappers;
using EmploymentSystem.Domain.Entities;

namespace EmploymentSystem.Application.DTOs
{
    public class AddCitiesDto : IMapFrom<City>
    {
        public string Code { get; set; }
        public string EnglishDescription { get; set; }
        public string ArabicDescription { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddCitiesDto, City>().ReverseMap();
        }
    }
}
