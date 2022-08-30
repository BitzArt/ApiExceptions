using Microsoft.AspNetCore.Mvc;

namespace BitzArt.ApiExceptions.AspNetCore.Sample.Controllers
{
    [ApiController]
    [Route("")]
    public class SampleController : ControllerBase
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
        public IActionResult ThrowUserSpecified([FromRoute] int statusCode)
        {
            throw ApiException.Custom("this method returns user-specified status code", statusCode);
        }
    }
}
