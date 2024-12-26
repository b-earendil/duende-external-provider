using System.Text.RegularExpressions;
using Duende.IdentityServer.Models;
using System.Security.Claims;


namespace Auth.Extensions
{
    public static class ProfileServiceExtensions
    {
        public static bool AddRequestedScopes(this ProfileDataRequestContext context, List<Claim> claims)
        {
            // Get the requested scopes.
            ICollection<IdentityResource> requestedScopes = context.RequestedResources.Resources.IdentityResources;

            foreach (IdentityResource scope in requestedScopes)
            {
                foreach (string claimType in scope.UserClaims)
                {
                    // Add to claims
                    if (claims.Any(c => c.Type == claimType))
                    {
                        context.IssuedClaims.Add(claims.FirstOrDefault(c => c.Type == claimType));
                    }
                }
            }

            return true;
        }
    }
}
