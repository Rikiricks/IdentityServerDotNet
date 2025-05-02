using Duende.IdentityModel;
using Microsoft.AspNetCore.Identity;

namespace IdentityService.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string role { get; set; }
    }
    
 
}
