using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AutoMapper;
using EmploymentSystem.Application.Common.Mappers;
using EmploymentSystem.Domain.Entities;

namespace EmploymentSystem.Application.DTOs
{
    public class UserDto : IMapFrom<User>
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<UserRolesDto>? UserRoles { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
