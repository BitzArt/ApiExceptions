using Microsoft.AspNetCore.Mvc;

namespace BitzArt.ApiExceptions.AspNetCore.Sample.Controllers
{
    [ApiController]
    [Route("custom")]
    public class CustomExceptionsController : ControllerBase
    {
        [HttpGet("basic")]
        public IActionResult ThrowMyCustomApiException()
        {
            throw new MyCustomApiException();
        }

        [HttpGet("payload")]
        public IActionResult ThrowMyCustomPayloadApiException()
        {
            throw new MyCustomPayloadApiException();
        }
    }
}
