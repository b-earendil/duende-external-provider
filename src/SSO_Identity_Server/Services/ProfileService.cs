using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Auth.Extensions;
using Duende.IdentityServer.Test;

namespace Auth.Services
{
    public class ProfileService : IProfileService
    {
        private readonly TestUserStore _users;

        public ProfileService(
            TestUserStore users
        )
        {
            _users = users;
        }


        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            string sub = context.Subject.GetSubjectId();
            TestUser user = _users.FindBySubjectId(sub);

            // ClaimsPrincipal userClaims = await _userClaimsPrincipalFactory.CreateAsync(user);
            // List<Claim> claims = userClaims.Claims.ToList();

            context.AddRequestedScopes(user.Claims.ToList());
        }

         public async Task IsActiveAsync(IsActiveContext context)
        {
            string sub = context.Subject.GetSubjectId();
            TestUser user = _users.FindBySubjectId(sub);
            context.IsActive = user != null;
        }
    }
}
