


using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using EmploymentSystem.Application.DTOs;
using EmploymentSystem.Application.Interfaces;
using MediatR;
using AutoMapper.QueryableExtensions;
using EmploymentSystem.Domain.Entities;
using EmploymentSystem.Domain;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmploymentSystem.Application.Queries
{
    public class GetApplicationUserByIdQuery : IRequest<UserDto>
    {
        public Guid UserId { get; set; }
    }

    public class GetApplicationUserByIdQueryHandler :
         IRequestHandler<GetApplicationUserByIdQuery, UserDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<User> _ApplicationUserRepository;

        public GetApplicationUserByIdQueryHandler(
            IMapper mapper,
            IRepository<User> ApplicationUserRepository
            )
        {
            _mapper = mapper;
            _ApplicationUserRepository = ApplicationUserRepository;
        }

        public async Task<UserDto> Handle(GetApplicationUserByIdQuery request, CancellationToken cancellationToken)
        {            
            var data = _ApplicationUserRepository.TableNoTracking.Include(e=>e.UserRoles).FirstOrDefaultAsync(x => x.Id==request.UserId);
            return _mapper.Map<UserDto>(data.Result);
        }
    }
}

   


