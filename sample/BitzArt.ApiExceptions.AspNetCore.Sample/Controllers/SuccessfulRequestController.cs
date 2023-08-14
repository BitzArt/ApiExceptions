using Microsoft.AspNetCore.Mvc;

namespace BitzArt.ApiExceptions.AspNetCore.Sample.Controllers
{
    [ApiController]
    [Route("success")]
    public class SuccessfulRequestController : ControllerBase
    {
        [HttpGet]
        public IActionResult ReturnOk()
        {
            return Ok("Success");
        }
    }
}
