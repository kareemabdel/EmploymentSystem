


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
using EmploymentSystem.Domain.Enums;
using static System.Net.Mime.MediaTypeNames;

namespace EmploymentSystem.Application.Queries
{
    public class GetUsersByUserTypeQuery : IRequest<IEnumerable<UserDto>>
    {
        public int [] UserTypes { get; set; }
    }

    public class GetUsersByUserTypeQueryHandler :
         IRequestHandler<GetUsersByUserTypeQuery, IEnumerable<UserDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<User> _ApplicationUserRepository;

        public GetUsersByUserTypeQueryHandler(
            IMapper mapper,
            IRepository<User> ApplicationUserRepository
            )
        {
            _mapper = mapper;
            _ApplicationUserRepository = ApplicationUserRepository;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetUsersByUserTypeQuery request, CancellationToken cancellationToken)
        {            
            var data = _ApplicationUserRepository.TableNoTracking.Include(e=>e.UserRoles).Where(e=>e.UserRoles.Any(x=>request.UserTypes.Contains(x.RoleId))).ToList();
            return _mapper.Map<List<UserDto>>(data);
        }
    }
}

   


