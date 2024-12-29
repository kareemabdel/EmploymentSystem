
using EmploymentSystem.Application.DTOs;
using MediatR;
using System.Text.Json.Serialization;
using EmploymentSystem.Domain.Enums;

namespace EmploymentSystem.Application.Queries.Auth.Login
{
    public class LoginQuery : IRequest<LoginQueryResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserTypes UserType { get; set; }
        [JsonIgnore]
        public string? HashedPassword { get; set; }
    }

    public class LoginQueryResponse
    {

        public bool IsSuccess { get; set; }
        public string Msg { get; set; }
        public string Token { get; set; }
        public UserDto UserDetails { get; set; }


    }
}
