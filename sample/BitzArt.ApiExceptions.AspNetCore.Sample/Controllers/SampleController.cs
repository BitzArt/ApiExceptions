using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BitzArt.ApiExceptions.AspNetCore.Sample.Controllers
{
    [ApiController]
    [Route("")]
    public class SampleController : ControllerBase
    {
        [HttpGet("notfound")]
        public IActionResult ThrowNotFound()
        {
            throw ApiException.NotFound("sample 'not found' exception message");
        }

        [HttpGet("unauthorized")]
        public IActionResult ThrowUnauthorized()
        {
            throw ApiException.Unauthorized("sample 'unauthorized' exception message");
        }

        [HttpGet("basic")]
        public IActionResult ThrowBasicCustom()
        {
            throw new BasicCustomApiException();
        }

        [HttpGet("custom")]
        public IActionResult ThrowMyVeryCustom()
        {
            throw new MyVeryCustomApiException("additional details");
        }

        [HttpGet("custom/{statusCode}")]
        public IActionResult ThrowUserSpecified([FromRoute] HttpStatusCode statusCode)
        {
            throw ApiException.Custom("sample custom status code", statusCode);
        }
    }
}
