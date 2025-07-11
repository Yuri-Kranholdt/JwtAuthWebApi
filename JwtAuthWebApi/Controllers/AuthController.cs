using JwtAuthWebApi.Dto;
using JwtAuthWebApi.Services.AuthService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthInterface _authInterface;
        public AuthController(AuthInterface ai) 
        { 
            _authInterface = ai;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(UsuarioLoginDto loginDto) 
        {
            var auth = await _authInterface.Login(loginDto);
            return Ok(auth);
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UsuarioDto UserDto)
        {
            var user = await _authInterface.Registrar(UserDto);
            return Ok(user);
        }
    }
}
