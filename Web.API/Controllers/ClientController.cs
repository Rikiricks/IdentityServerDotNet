using IdentityService.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public ClientController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpGet]
        [Route("/GetToken")]
        public async Task<IActionResult> GetToken([FromForm] string scope = "wthrApi.read")
        {
            var token = await _tokenService.GetToken(scope);

            return Ok(token);
        }

        [HttpPost]
        [Route("/GetTokenByPassword")]
        public async Task<IActionResult> GetTokenByPassword([FromForm] string userName, [FromForm] string password, [FromForm] string scope = "wthrApi.read")
        {
            var token = await _tokenService.GetTokenByPwd(scope, userName, password);

            return Ok(token);
        }
    }
}
