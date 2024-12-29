


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

namespace EmploymentSystem.Application.Queries
{
    public class GetAllApplicationUserQuery : IRequest<IEnumerable<UserDto>>
    {

    }

    public class GetAllApplicationUserQueryHandler :
         IRequestHandler<GetAllApplicationUserQuery, IEnumerable<UserDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<User> _ApplicationUserRepository;

        public GetAllApplicationUserQueryHandler(
            IMapper mapper,
            IRepository<User> ApplicationUserRepository
            )
        {
            _mapper = mapper;
            _ApplicationUserRepository = ApplicationUserRepository;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetAllApplicationUserQuery request, CancellationToken cancellationToken)
        {
            var data = _ApplicationUserRepository.TableNoTracking.Include(e => e.UserRoles).Where(x => !x.IsDeleted).ToList();
            return _mapper.Map<List<UserDto>>(data);
        }
    }
}

   


