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
    public class ApplyForVacancyCommand : IRequest<bool>
    {
        public Guid VaccancyId { get; set; }
        public Guid UserId { get; set; }

    }

    public class ApplyForVaccancyCommandHandler : IRequestHandler<ApplyForVacancyCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<JobApplication> _servicesRepository;
        private readonly IApplicationDbContext _context;

        public ApplyForVaccancyCommandHandler(IRepository<JobApplication> servicesRepository, IMapper mapper, IApplicationDbContext context)
        {
            _servicesRepository = servicesRepository;
            _mapper = mapper;
            _context = context;
        }
        public async Task<bool> Handle(ApplyForVacancyCommand request, CancellationToken cancellationToken)
        {

            bool hasApplied = _context.JobApplications
           .Any(e => e.UserId == request.UserId && e.VaccancyId == request.VaccancyId);

            if (hasApplied)
                throw new Exception("You have already applied for this vacancy.");


            if (!CanApply(request.UserId))
            {
                throw new Exception("You can only apply for one vacancy per day. Please try again later.");
            }

            var vacancy = _context.Vaccancies.FirstOrDefault(e=>e.Id==request.VaccancyId);

            if (vacancy == null)
                throw new Exception("The vacancy does not exist.");

            if (vacancy.CurrentApplications >= vacancy.MaxApplications)
                throw new Exception("This vacancy has reached the maximum number of applications.");

           

            var newApplication = new JobApplication
            {
                UserId = request.UserId,
                VaccancyId = request.VaccancyId,
                CreationDate = DateTime.Now
            };

            _context.JobApplications.Add(newApplication);

            // Increment the CurrentApplications count
            vacancy.CurrentApplications += 1;

           return await _context.SaveChangesAsync(cancellationToken)>0;
        }

        private bool CanApply(Guid userId)
        {    
                var lastApplication = _context.JobApplications
                    .Where(j => j.UserId == userId)
                    .OrderByDescending(j => j.CreationDate)
                    .FirstOrDefault();

                if (lastApplication != null && lastApplication.CreationDate > DateTime.Now.AddHours(-24))
                {
                    return false; // Not allowed
                }

                return true; // Allowed
           
        }
    }
}



