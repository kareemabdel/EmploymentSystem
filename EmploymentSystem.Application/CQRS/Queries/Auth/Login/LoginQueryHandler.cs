using AutoMapper;
using FluentValidation;
using EmploymentSystem.Application.DTOs;
using EmploymentSystem.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EmploymentSystem.Application.Queries.Auth.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginQueryResponse>
    {
       // private readonly IValidator<LoginQuery> _validator;
        private readonly IRepository<Domain.Entities.User> _userRepository;
        private readonly IRepository<Domain.Entities.UserRole> _userRolesRepository;
        private readonly IMapper _mapper;
        //private readonly ILogger _logger;

        public LoginQueryHandler(
       //ILogger logger,
      IRepository<Domain.Entities.User> userRepository,
      IRepository<Domain.Entities.UserRole> userRolesRepository,

       IMapper mapper)
       //IValidator<LoginQuery> validator)
        {
            //_logger = logger;
            _userRepository = userRepository;
            _userRolesRepository = userRolesRepository;
            //_validator = validator;
            _mapper = mapper;

        }

        public async Task<LoginQueryResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            //var validation = _validator.Validate(request);

            //if (!validation.IsValid)
            //{
                //_logger.LogError("UserName /& Password is not valid for user", request.UserName, validation.ToString());
                //return new LoginQueryResponse
                //{
                //    IsSuccess = false,
                //    //Msg = validation.ToString()
                //};
           // }
            var user = await _userRepository.TableNoTracking.Include(e => e.UserRoles.
            Where(e => e.RoleId == (int)request.UserType)).
            Where(p => p.Phone == request.UserName
            || p.UserName == request.UserName ||
            p.Email == request.UserName).FirstOrDefaultAsync();
            if (user != null)
            {
                if (user.UserRoles.Count != 0)
                {
                    if (user.Password == request.HashedPassword && user.IsActive)
                    {
                        return new LoginQueryResponse
                        {
                            IsSuccess = true,
                            UserDetails = _mapper.Map<UserDto>(user),
                            Msg= "Logged In Successfully"
                        };
                    }

                    return new LoginQueryResponse
                    {
                        IsSuccess = false,
                        Msg = "Password is incorrect for this user or Not Active User"
                    };
                }

                return new LoginQueryResponse
                {
                    IsSuccess = false,
                    Msg = "User does not have any roles to access !!"
                };
            }
            else
            {
                return new LoginQueryResponse
                {
                    IsSuccess = false,
                    Msg = "UserName not found "
                };
            }


        }

        public async Task<LoginQueryResponse> HandleExternalLogin(string email,string hashedPassword)
        {

            var Externaluser = await _userRepository.TableNoTracking.Where(p => p.Email.ToLower() == email.ToLower() && p.Password == hashedPassword && p.IsActive).Include(e => e.UserRoles).FirstOrDefaultAsync();

            if (Externaluser == null)
            {
                //_logger.LogError("UserName is not found or password is incorrect for user or User Not Active", email);

                return new LoginQueryResponse
                {
                    IsSuccess = false
                    ,
                    Msg = "UserName is not found or password is incorrect for this user or User Not Active"

                };
            }

            else
            {

                if (Externaluser.UserRoles.Count == 0)
                {
                    //_logger.LogError("User Found But Has no rules , Error For User", Externaluser.Email);

                    return new LoginQueryResponse
                    {
                        IsSuccess = false
                        ,
                        Msg = "User Found But Has no rules , Error For This User"
                    };
                }

                else
                {
                    //TODO //Send OTP

                    return new LoginQueryResponse
                    {
                        IsSuccess = true,
                        UserDetails = _mapper.Map<UserDto>(Externaluser)

                    };
                }

            }

        }


        
    }
}
