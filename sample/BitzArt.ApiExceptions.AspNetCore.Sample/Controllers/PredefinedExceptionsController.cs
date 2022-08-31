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
            throw ApiException.NotFound("sample 'not found' message");
        }

        [HttpGet("unauthorized")]
        public IActionResult ThrowUnauthorized()
        {
            throw ApiException.Unauthorized("sample 'unauthorized' message");
        }

        [HttpGet("{statusCode}")]
        public IActionResult ThrowUserSpecified([FromRoute] int statusCode)
        {
            throw ApiException.Custom("this method returns user-specified status code", statusCode);
        }
    }
}
