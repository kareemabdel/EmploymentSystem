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
    public class DeleteVaccancyCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

    }

    public class DeleteVaccancyCommandHandler : IRequestHandler<DeleteVaccancyCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Vaccancy> _servicesRepository;

        public DeleteVaccancyCommandHandler(IRepository<Vaccancy> servicesRepository, IMapper mapper)
        {
            _servicesRepository = servicesRepository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteVaccancyCommand request, CancellationToken cancellationToken)
        {
            var item = _servicesRepository.GetById(request.Id);
            if (item != null)
            {
                //soft delete;
                item.IsDeleted = true;
                //item.IsActive = false;
                item.DeletionDate = DateTimeOffset.Now;
                return (_servicesRepository.Update(item) == Result.Success);
            }
            throw new Exception($"Entitie with id {request.Id} not found");
        }
    }
}



