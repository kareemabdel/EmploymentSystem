


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

namespace EmploymentSystem.Application.Queries
{
    public class GetAllCitiesQuery : IRequest<IEnumerable<CitiesDto>>
    {
        public bool IsAdmin { get; set; }

    }

    public class GetAllCitiesQueryHandler :IRequestHandler<GetAllCitiesQuery, IEnumerable<CitiesDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<City> _CitiesRepository;
        private readonly IStringLocalizer<GetAllCitiesQuery> _localizer;
        public GetAllCitiesQueryHandler(IMapper mapper, IRepository<City> CitiesRepository, IStringLocalizer<GetAllCitiesQuery> localizer)
        {
            _mapper = mapper;
            _CitiesRepository = CitiesRepository;
            _localizer = localizer;
        }

        public async Task<IEnumerable<CitiesDto>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
        {  
            var data =await _CitiesRepository.TableNoTracking.Where(x => !x.IsDeleted && request.IsAdmin? true:x.IsActive).ToListAsync();
            return _mapper.Map<List<CitiesDto>>(data);
        }
    }
}

   


