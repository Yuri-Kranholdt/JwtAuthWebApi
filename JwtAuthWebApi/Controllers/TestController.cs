using JwtAuthWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public ActionResult<Response<string>> Test()
        {
            Response<string> response = new Response<string>();
            response.Mensagem = "acessou";
            return Ok(response);
        }
    }
}
