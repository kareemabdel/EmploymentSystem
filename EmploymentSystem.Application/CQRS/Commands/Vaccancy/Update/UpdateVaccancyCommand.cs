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
using EmploymentSystem.Domain.Entities.Vaccancy;

namespace EmploymentSystem.Application.Commands
{
    public class UpdateVaccancyCommand : IRequest<EditVaccancyDto>
    {
        public EditVaccancyDto obj { get; set; }

    }

    public class UpdateVaccancyCommandHandler : IRequestHandler<UpdateVaccancyCommand, EditVaccancyDto>
    {        
        private readonly IMapper _mapper;
        private readonly IRepository<Vaccancy> _servicesRepository;

        public UpdateVaccancyCommandHandler(
            IRepository<Vaccancy> servicesRepository,
            IMapper mapper
            )
        {
            _servicesRepository = servicesRepository;            
            _mapper = mapper;
        }
        public async Task<EditVaccancyDto> Handle(UpdateVaccancyCommand request, CancellationToken cancellationToken)
        {
            var item = _servicesRepository.GetById(request.obj.Id);
            if (item != null)
            {
                item = _mapper.Map(request.obj, item);
                var result = _servicesRepository.UpdateWithEntityReturn(item);
                return _mapper.Map<EditVaccancyDto>(result);
            }
            throw new Exception($"Entitie with id {request.obj.Id} not found");
        }
    }
}

   

