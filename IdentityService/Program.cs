using Duende.IdentityServer.Services;
using IdentityService.Configuration;
using IdentityService.Models;
using IdentityService.Services;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddIdentity<ApplicationUser, IdentityRole>();
//builder.Services.AddScoped<IProfileService, ProfileService>();



builder.Services.AddIdentityServer()
                    .AddInMemoryIdentityResources(InMemoryConfig.IdentityResources)
                    .AddInMemoryApiResources(InMemoryConfig.ApiResources)
                    .AddTestUsers(InMemoryConfig.TestUsers)
                    .AddInMemoryClients(InMemoryConfig.Clients)
                    .AddInMemoryApiScopes(InMemoryConfig.ApiScopes)
                    .AddDeveloperSigningCredential();

var app = builder.Build();

app.UseIdentityServer();

app.MapGet("/", () => "Hello World!");

app.Run();
