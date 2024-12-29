// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


//using CleanArchitecture.Razor.Application.ApplicationUsers.DTOs;

using AutoMapper;
using MediatR;
using EmploymentSystem.Domain;
using EmploymentSystem.Domain.Enums;

namespace EmploymentSystem.Application.Commands
{
    public class DeleteApplicationUserCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

    }

    public class DeleteApplicationUserCommandHandler : IRequestHandler<DeleteApplicationUserCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Domain.Entities.User> _servicesRepository;

        public DeleteApplicationUserCommandHandler(IRepository<Domain.Entities.User> servicesRepository, IMapper mapper)
        {
            _servicesRepository = servicesRepository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteApplicationUserCommand request, CancellationToken cancellationToken)
        {
            var item = _servicesRepository.GetById(request.Id);
            if (item != null)
            {
                //soft delete;
                item.IsDeleted = true;
                item.IsActive = false;
                item.DeletionDate = DateTimeOffset.Now;
                return (_servicesRepository.Update(item) == Result.Success);
            }
            throw new Exception($"Entitie with id {request.Id} not found");
        }
    }
}



