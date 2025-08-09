using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TroSmart.Domain.Entities;

namespace TroSmart.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/auths/")]
    public class AuthController : ControllerBase
    {
        [HttpGet("hello")]
        public IActionResult Hello()
        {
            return Ok(new
            {
                Message = "Hello nèk"
            });
        }
    }
}