using Microsoft.AspNetCore.Mvc;

namespace BitzArt.ApiExceptions.AspNetCore.Sample.Controllers
{
    [ApiController]
    [Route("predefined")]
    public class PredefinedExceptionsController : ControllerBase
    {
        [HttpGet("notfound")]
        public IActionResult ThrowNotFound()
        {
            throw ApiException.NotFound("sample error message");
        }

        [HttpGet("badrequest")]
        public IActionResult ThrowBadRequest()
        {
            throw ApiException.BadRequest("sample error message");
        }

        [HttpGet("{statusCode}")]
        public IActionResult ThrowUserSpecified([FromRoute] int statusCode)
        {
            throw ApiException.Custom("sample error message", statusCode);
        }
    }
}
