using AutoMapper;
using MediatR;
using EmploymentSystem.Application.DTOs;
using EmploymentSystem.Domain;
using EmploymentSystem.Domain.Entities;
using EmploymentSystem.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using EmploymentSystem.Application.Queries.Auth.Login;

namespace EmploymentSystem.Application.Commands
{
    public class RegisterCommand : IRequest<LoginQueryResponse>
    {
        public RegisterDto obj { get; set; }
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, LoginQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Domain.Entities.User> _servicesRepository;

        public RegisterCommandHandler(
            IRepository<Domain.Entities.User> servicesRepository,
            IMapper mapper
            )
        {
            _servicesRepository = servicesRepository;
            _mapper = mapper;
        }
        public async Task<LoginQueryResponse?> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<User>(request.obj);
            if (!await IsUserExists(item))
            {
                // add default role
                item.UserRoles.Add(new UserRole { RoleId = (int)request.obj.UserType });
                var result = _servicesRepository.InsertWithEntityReturn(item);
                return new LoginQueryResponse
                {
                    IsSuccess = true,
                    UserDetails = _mapper.Map<UserDto>(result),
                    Msg = "User Registered Successfully"
                };
            }
            else
            {
                return new LoginQueryResponse
                {
                    IsSuccess = false,
                    Msg = "UserName, Email Or Phone already In Use"
                };
            }
        }

        public async Task<bool> IsUserExists(User applicationUser)
        {
            var user = await _servicesRepository.TableNoTracking.Where(p => p.Email  == applicationUser.Email 
            || p.Phone  == applicationUser.Phone 
            || p.UserName  == applicationUser.UserName 
            ).FirstOrDefaultAsync();

            if (user != null)
            {
                if (user.IsDeleted)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

    }
}



