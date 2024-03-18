using Microsoft.AspNetCore.Mvc;

namespace BitzArt.ApiExceptions.AspNetCore.Sample.Controllers
{
    [ApiController]
    [Route("inner")]
    public class InnerExceptionController : ControllerBase
    {
        [HttpGet]
        public IActionResult ThrowExceptionWithInner()
        {
            var outter = new Exception("See inner exception for details",
                innerException: new("inner exception level 1",
                    innerException: new("inner exception level 2",
                        innerException: new ("inner exception level 3",
                            innerException: new ("etc.")))));

            throw outter;
        }
    }
}
