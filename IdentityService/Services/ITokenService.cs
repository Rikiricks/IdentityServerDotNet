using Duende.IdentityModel.Client;

namespace IdentityService.Services
{
    public interface ITokenService
    {
        Task<TokenResponse> GetToken(string scope);
        Task<TokenResponse> GetTokenByPwd(string scope, string userName, string password);
    }
}
