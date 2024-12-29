using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using AutoMapper;
using EmploymentSystem.Application.Common.Mappers;
using EmploymentSystem.Domain.Entities;
using EmploymentSystem.Domain.Enums;

namespace EmploymentSystem.Application.DTOs
{
    public class RegisterDto : IMapFrom<User>
    {
        [Required(ErrorMessage = "User Name is Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password Name is Required")]
       // [Required(ErrorMessage = "Password Name is Required"), RegularExpression("((?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{8,40})",ErrorMessage = "must contains one lowercase characters")]

        public string Password { get; set; }
        public string Name { get; set; }
        [RegularExpression("^01[0125][0-9]{8}$",ErrorMessage ="Please Enter Valid Number"),Required(ErrorMessage = "Phone is Required")]
        public string Phone { get; set; }
        [EmailAddress(ErrorMessage = "Please Enter Valid Email Address")]
        public string Email { get; set; }
        public UserTypes UserType { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<RegisterDto, User>().ReverseMap();
        }
    }
}
