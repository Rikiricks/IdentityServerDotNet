using Duende.IdentityModel.Client;

namespace IdentityService.Services
{
    public class TokenService : ITokenService
    {
        private DiscoveryDocumentResponse _discDocument { get; set; }
        public TokenService()
        {
            using (var client = new HttpClient())
            {
                _discDocument = client.GetDiscoveryDocumentAsync("http://localhost:5287/.well-known/openid-configuration").Result;
            }
        }
       
        public async Task<TokenResponse> GetToken(string scope)
        {
            using (var client = new HttpClient())
            {
                var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    Address = _discDocument.TokenEndpoint,
                    ClientId = "w.client",
                    Scope = scope,
                    ClientSecret = "secret"
                });
                if (tokenResponse.IsError)
                {
                    throw new Exception("Token Error");
                }
                return tokenResponse;
            }
           
        }

        public async Task<TokenResponse> GetTokenByPwd(string scope, string userName, string password)
        {
            using (var client = new HttpClient())
            {
                var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
                {
                    Address = _discDocument.TokenEndpoint,

                    ClientId = "w.client",
                    ClientSecret = "secret",
                    Scope = scope,

                    UserName = userName,
                    Password = password
                });
                if (tokenResponse.IsError)
                {
                    throw new Exception("Token Error");
                }
                return tokenResponse;
            }

        }
    }
}
