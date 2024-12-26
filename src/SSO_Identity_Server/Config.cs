// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;

namespace IdentityServer;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource()
            {
                Name = "verification",
                UserClaims = new List<string> 
                { 
                    JwtClaimTypes.Email,
                    JwtClaimTypes.EmailVerified
                }
            },
            new IdentityResource()
            {
                Name = "Client1",
                UserClaims = new List<string> 
                { 
                    "Client1_UserId",
                }
            },
            new IdentityResource()
            {
                Name = "Client2",
                UserClaims = new List<string> 
                { 
                    "Client2_UserId",
                }
            }
        };

    public static IEnumerable<Client> Clients =>
        new Client[] 
        {
            // interactive ASP.NET Core Web App
            new Client
            {
                ClientId = "Client1",

                AllowedGrantTypes = GrantTypes.Code,

                RequireClientSecret = false,

                // where to redirect to after login
                RedirectUris = { "https://localhost:5001/signin-oidc" },

                // where to redirect to after logout
                PostLogoutRedirectUris = { "https://localhost:5001/signout-callback-oidc" },

                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "verification",
                    "Client1",
                }
            },
                       // interactive ASP.NET Core Web App
            new Client
            {
                ClientId = "Client2",

                AllowedGrantTypes = GrantTypes.Code,

                RequireClientSecret = false,
                
                // where to redirect to after login
                RedirectUris = { "https://localhost:6001/signin-oidc" },

                // where to redirect to after logout
                PostLogoutRedirectUris = { "https://localhost:6001/signout-callback-oidc" },

                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "verification",
                    "Client2",
                }
            
            }
        };
}