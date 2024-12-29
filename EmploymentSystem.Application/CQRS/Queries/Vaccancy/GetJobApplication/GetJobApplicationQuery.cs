


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
using Microsoft.Extensions.Localization;
using EmploymentSystem.Domain.Entities.Vaccancy;

namespace EmploymentSystem.Application.Queries
{
    public class GetJobApplicationQuery : IRequest<IEnumerable<JobApplicationDto>>
    {
        public Guid vacancyId { get; set; }

    }

    public class GetJobApplicationQueryHandler :IRequestHandler<GetJobApplicationQuery, IEnumerable<JobApplicationDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<JobApplication> _VaccancyRepository;
        private readonly IStringLocalizer<GetJobApplicationQuery> _localizer;
        public GetJobApplicationQueryHandler(IMapper mapper, IRepository<JobApplication> VaccancyRepository, IStringLocalizer<GetJobApplicationQuery> localizer)
        {
            _mapper = mapper;
            _VaccancyRepository = VaccancyRepository;
            _localizer = localizer;
        }

        public async Task<IEnumerable<JobApplicationDto>> Handle(GetJobApplicationQuery request, CancellationToken cancellationToken)
        {  
            var data =await _VaccancyRepository.TableNoTracking.Include(e=>e.User)
                .Include(e=>e.Vaccancy)
                .Where(x => !x.IsDeleted && x.VaccancyId==request.vacancyId).ToListAsync();
            return _mapper.Map<List<JobApplicationDto>>(data);
        }
    }
}

   


