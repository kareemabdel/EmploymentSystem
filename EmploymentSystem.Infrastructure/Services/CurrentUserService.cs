using System;
using System.Collections.Generic;
using System.Security.Claims;
using EmploymentSystem.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace EmploymentSystem.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _accessor;

        public CurrentUserService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string GetUserLanguageKey()
        {
            var acceptLanguageHeader = _accessor.HttpContext?.Request.Headers["Accept-Language"].ToString();
            var languageKey = acceptLanguageHeader?.Substring(0, 2);
            if ( string.IsNullOrEmpty(languageKey))
                languageKey = "en";
           
            return languageKey;
        }
       
        public Guid GetUserId()
        {
            var identityUserId = Guid.Empty;
            if (IsAuthenticated() && _accessor.HttpContext?.User.Identity is ClaimsIdentity identity)
            {
                identityUserId = Guid.Parse(identity.FindFirst("Id").Value ?? Guid.Empty.ToString());
            }

            return identityUserId;
        }

        public string GetUserEmail()
        {
            var email = string.Empty;
            if (IsAuthenticated() && _accessor.HttpContext?.User.Identity is ClaimsIdentity identity)
            {
                email = identity.FindFirst("Email").Value ?? string.Empty;
            }

            return email;
        }

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext?.User.Identity?.IsAuthenticated ?? false;
        }

        public bool IsInRole(string role)
        {
            return _accessor.HttpContext?.User.IsInRole(role) ?? false;
        }

        public bool IsAdmin()
        {
            return _accessor.HttpContext?.User.IsInRole(UserTypes.Employer.ToString()) ?? false;
        }


        public IEnumerable<Claim> GetUserClaims()
        {
            return _accessor.HttpContext?.User.Claims;
        }

        public HttpContext GetHttpContext()
        {
            return _accessor.HttpContext;
        }

    }
}
