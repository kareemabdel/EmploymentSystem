// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


//using CleanArchitecture.Razor.Application.Findings.DTOs;

using AutoMapper;
using MediatR;
using EmploymentSystem.Application.DTOs;
using Microsoft.EntityFrameworkCore;
using EmploymentSystem.Domain;
using EmploymentSystem.Domain.Entities;

namespace EmploymentSystem.Application.Commands
{
    public class AddApplicationUserCommand : IRequest<UserDto>
    {
        public AddApplicationUserDto obj { get; set; }
    }

    public class AddApplicationUserCommandHandler : IRequestHandler<AddApplicationUserCommand, UserDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Domain.Entities.User> _applicationUserRepository;

        public AddApplicationUserCommandHandler(
            IRepository<Domain.Entities.User> applicationUserRepository,
            IMapper mapper
            )
        {
            _applicationUserRepository = applicationUserRepository;
            _mapper = mapper;
        }
        public async Task<UserDto> Handle(AddApplicationUserCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<Domain.Entities.User>(request.obj);
            if (!await IsUserExists(item))
            {
                var result = _applicationUserRepository.InsertWithEntityReturn(item);
                return _mapper.Map<UserDto>(result);
            }
            else
            {
                throw new Exception($" Email, Phone Or UserName already Exists");
            }
        }

        public async Task<bool> IsUserExists(User applicationUser)
        {
            var user = await _applicationUserRepository.TableNoTracking.Where(p => p.Email == applicationUser.Email||
            p.Phone==applicationUser.Phone
            ||p.UserName==applicationUser.UserName).FirstOrDefaultAsync();
            if (user!=null)
            {
                if (user.IsDeleted)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}



