using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AutoMapper;
using EmploymentSystem.Application.Common.Mappers;
using EmploymentSystem.Domain.Entities;
using EmploymentSystem.Domain.Enums;

namespace EmploymentSystem.Application.DTOs
{
    public class UserRolesDto : IMapFrom<UserRole>
    {
        public int RoleId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserRolesDto, UserRole>().ReverseMap();
        }
    }
}
