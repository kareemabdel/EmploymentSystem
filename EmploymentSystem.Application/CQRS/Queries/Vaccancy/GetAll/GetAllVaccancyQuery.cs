


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
    public class GetAllVaccancyQuery : IRequest<IEnumerable<VaccancyDto>>
    {
        public bool IsAdmin { get; set; }
        public string? searchKey { get; set; }

    }

    public class GetAllVaccancyQueryHandler :IRequestHandler<GetAllVaccancyQuery, IEnumerable<VaccancyDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Vaccancy> _VaccancyRepository;
        private readonly IStringLocalizer<GetAllVaccancyQuery> _localizer;
        public GetAllVaccancyQueryHandler(IMapper mapper, IRepository<Vaccancy> VaccancyRepository, IStringLocalizer<GetAllVaccancyQuery> localizer)
        {
            _mapper = mapper;
            _VaccancyRepository = VaccancyRepository;
            _localizer = localizer;
        }

        public async Task<IEnumerable<VaccancyDto>> Handle(GetAllVaccancyQuery request, CancellationToken cancellationToken)
        {  
            var data = _VaccancyRepository.TableNoTracking.Where(x => !x.IsDeleted && (!request.IsAdmin?x.Status==Domain.Enums.VaccancyStatusEnum.Posted:true));
            if (!string.IsNullOrEmpty(request.searchKey))
                data = data.Where(e => e.Title.ToLower().Contains(request.searchKey.ToLower()));
            var res = await data.ToListAsync();
            return _mapper.Map<List<VaccancyDto>>(res);
        }
    }
}

   


