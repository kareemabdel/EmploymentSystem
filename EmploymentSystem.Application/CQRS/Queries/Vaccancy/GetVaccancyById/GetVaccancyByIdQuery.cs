


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
using EmploymentSystem.Domain.Entities.Vaccancy;

namespace EmploymentSystem.Application.Queries
{
    public class GetVaccancyByIdQuery : IRequest<VaccancyDto>
    {
        public Guid VaccancyId { get; set; }
    }

    public class GetVaccancyByIdQueryHandler :
         IRequestHandler<GetVaccancyByIdQuery, VaccancyDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Vaccancy> _VaccancyRepository;

        public GetVaccancyByIdQueryHandler(
            IMapper mapper,
            IRepository<Vaccancy> VaccancyRepository)
        {
            _mapper = mapper;
            _VaccancyRepository = VaccancyRepository;
        }

        public async Task<VaccancyDto> Handle(GetVaccancyByIdQuery request, CancellationToken cancellationToken)
        {            
            var data = _VaccancyRepository.TableNoTracking.FirstOrDefaultAsync(x => x.Id==request.VaccancyId);
            return _mapper.Map<VaccancyDto>(data.Result);
        }
    }
}

   


