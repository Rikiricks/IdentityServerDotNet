using Duende.IdentityModel;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Test;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace IdentityService.Configuration
{
    public static class InMemoryConfig
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
          new List<IdentityResource>
          {
              new IdentityResources.OpenId(), // subjectId or sub value
              new IdentityResources.Profile(), // profile info like given_name, family_name
              new IdentityResource("roles", "User roles", new[] { JwtClaimTypes.Role })
          };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "w.client",
                    ClientName = "w Credentials Client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials, // flow to get token
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = { "wthrApi.read", "wthrApi.write", "roles" }
                },

            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("wthrApi")
                {
                    Scopes = new List<string>{ "wthrApi.read", "wthrApi.write", "roles" },
                    ApiSecrets = new List<Secret>{ new Secret("supersecret".Sha256()) },
                    UserClaims = {JwtClaimTypes.Role}
                }
            };

        public static List<TestUser> TestUsers =>
          new List<TestUser>
          {
              new TestUser
              {
                  SubjectId = "a9ea0f25-b964-409f-bcce-c923266249b4",
                  Username = "riki",
                  Password = "riki",
                  Claims = new List<Claim>
                  {
                      new Claim(JwtClaimTypes.Name, "Riki Ricks"),
                      new Claim(JwtClaimTypes.GivenName, "Riki"),
                      new Claim(JwtClaimTypes.FamilyName, "Ricks"),
                      new Claim(JwtClaimTypes.Email, "rk@gmail.com"),
                      new Claim(JwtClaimTypes.Scope, "wthrApi.read wthrApi.write"),
                      new Claim(JwtClaimTypes.Role, "Admin"),
                  }
              },
              new TestUser
              {
                  SubjectId = "111",
                  Username = "rushik",
                  Password = "rushik",
                  Claims = new List<Claim>
                  {
                      new Claim("given_name", "Rushik"),
                      new Claim("family_name", "Lakhatariya"),
                       new Claim(JwtClaimTypes.Scope, "wthrApi.read"),
                       new Claim(JwtClaimTypes.Role, "User"),
                  }
              }
          };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("wthrApi.read",new List<string>{JwtClaimTypes.Role }),
                new ApiScope("wthrApi.write", new List<string>{JwtClaimTypes.Role }),
            };

    }
}
