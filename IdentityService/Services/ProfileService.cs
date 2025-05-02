using Duende.IdentityServer.AspNetIdentity;
using Duende.IdentityServer.Models;
using IdentityService.Models;
using Microsoft.AspNetCore.Identity;
using Duende.IdentityServer.Services;
using System.Security.Claims;
using Duende.IdentityModel;
using Duende.IdentityServer.Extensions;

namespace IdentityService.Services
{
    //public class CustomProfileService : ProfileService<ApplicationUser>
    //{
    //    private readonly UserManager<ApplicationUser> _userManager;
    //    public CustomProfileService(UserManager<ApplicationUser> userManager, IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory) : base(userManager, claimsFactory)
    //    {
    //        _userManager = userManager;
    //    }

    //    protected override async Task GetProfileDataAsync(ProfileDataRequestContext context, ApplicationUser user)
    //    {
    //        var principal = await GetUserClaimsAsync(user);
    //        var id = (ClaimsIdentity)principal.Identity;
    //        //if (!string.IsNullOrEmpty(user.FavoriteColor))
    //        //{
    //        //    id.AddClaim(new Claim("favorite_color", user.FavoriteColor));
    //        //}

    //        context.AddRequestedClaims(principal.Claims);
    //    }
    //}

    //public sealed class ProfileService : IProfileService
    //{
    //    //private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
    //    private readonly UserManager<ApplicationUser> _userMgr;
    //    private readonly RoleManager<IdentityRole> _roleMgr;

    //    public ProfileService(
    //        UserManager<ApplicationUser> userMgr,
    //        RoleManager<IdentityRole> roleMgr,
    //        IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory)
    //    {
    //        _userMgr = userMgr;
    //        _roleMgr = roleMgr;
    //        //_userClaimsPrincipalFactory = userClaimsPrincipalFactory;
    //    }

    //    public async Task GetProfileDataAsync(ProfileDataRequestContext context)
    //    {
    //        string sub = context.Subject.GetSubjectId();
    //        ApplicationUser user = await _userMgr.FindByIdAsync(sub);
    //        //ClaimsPrincipal userClaims = await _userClaimsPrincipalFactory.CreateAsync(user);

    //        //List<Claim> claims = userClaims.Claims.ToList();
    //        //claims = claims.Where(claim => context.RequestedClaimTypes.Contains(claim.Type)).ToList();

    //        //if (_userMgr.SupportsUserRole)
    //        //{
    //        //    IList<string> roles = await _userMgr.GetRolesAsync(user);
    //        //    foreach (var roleName in roles)
    //        //    {
    //        //        claims.Add(new Claim(JwtClaimTypes.Role, roleName));
    //        //        if (_roleMgr.SupportsRoleClaims)
    //        //        {
    //        //            IdentityRole role = await _roleMgr.FindByNameAsync(roleName);
    //        //            if (role != null)
    //        //            {
    //        //                claims.AddRange(await _roleMgr.GetClaimsAsync(role));
    //        //            }
    //        //        }
    //        //    }
    //        //}

    //        //context.IssuedClaims = claims;
    //    }

    //    public async Task IsActiveAsync(IsActiveContext context)
    //    {
    //        string sub = context.Subject.GetSubjectId();
    //        ApplicationUser user = await _userMgr.FindByIdAsync(sub);
    //        context.IsActive = user != null;
    //    }
    //}

}
