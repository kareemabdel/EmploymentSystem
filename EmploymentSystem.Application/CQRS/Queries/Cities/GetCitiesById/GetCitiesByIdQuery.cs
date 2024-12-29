


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
    public class GetCitiesByIdQuery : IRequest<CitiesDto>
    {
        public Guid CitiesId { get; set; }
    }

    public class GetCitiesByIdQueryHandler :
         IRequestHandler<GetCitiesByIdQuery, CitiesDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<City> _CitiesRepository;

        public GetCitiesByIdQueryHandler(
            IMapper mapper,
            IRepository<City> CitiesRepository)
        {
            _mapper = mapper;
            _CitiesRepository = CitiesRepository;
        }

        public async Task<CitiesDto> Handle(GetCitiesByIdQuery request, CancellationToken cancellationToken)
        {            
            var data = _CitiesRepository.TableNoTracking.FirstOrDefaultAsync(x => x.Id==request.CitiesId);
            return _mapper.Map<CitiesDto>(data.Result);
        }
    }
}

   


