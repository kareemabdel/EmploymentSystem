// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


//using CleanArchitecture.Razor.Application.Vaccancys.DTOs;

using AutoMapper;
using EmploymentSystem.Application.Interfaces;
using EmploymentSystem.Domain.Entities;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using EmploymentSystem.Application.DTOs;
using System;
using EmploymentSystem.Domain;
using System.Linq;
using EmploymentSystem.Domain.Enums;
using EmploymentSystem.Domain.Entities.Vaccancy;

namespace EmploymentSystem.Application.Commands
{
    public class ChangeVacancyStatusCommand : IRequest<bool>
    {
        public Guid VaccancyId { get; set; }
        public VaccancyStatusEnum Status { get; set; }

    }

    public class ChangeVacancyStatusCommandHandler : IRequestHandler<ChangeVacancyStatusCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<JobApplication> _servicesRepository;
        private readonly IApplicationDbContext _context;

        public ChangeVacancyStatusCommandHandler(IRepository<JobApplication> servicesRepository, IMapper mapper, IApplicationDbContext context)
        {
            _servicesRepository = servicesRepository;
            _mapper = mapper;
            _context = context;
        }
        public async Task<bool> Handle(ChangeVacancyStatusCommand request, CancellationToken cancellationToken)
        {
            var vacancy = _context.Vaccancies.FirstOrDefault(e=>e.Id==request.VaccancyId);

            if (vacancy == null)
                throw new Exception("The vacancy does not exist.");

           
            vacancy.Status = request.Status;

           return await _context.SaveChangesAsync(cancellationToken)>0;
        }

       
    }
}



