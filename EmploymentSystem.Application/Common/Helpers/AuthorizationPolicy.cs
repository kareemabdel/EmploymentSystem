using Microsoft.AspNetCore.Authorization;

namespace EmploymentSystem.Application.Common.Extensions.Helpers
{
    public class Policies
    {
        public const string Employer =  "Employer";
        public const string Applicant = "Applicant";
       


        public static AuthorizationPolicy AdminPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                .RequireRole(Employer).Build();
        }

        public static AuthorizationPolicy AuditorPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                .RequireRole(Applicant).Build();
        }

       


    }
}
