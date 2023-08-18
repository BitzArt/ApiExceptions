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
            var innerLevel3 = new Exception("Level 3");
            var innerLevel2 = new Exception("Level 2", innerLevel3);
            var innerLevel1 = new Exception("Level 1", innerLevel2);
            var outter = new Exception("Outter", innerLevel1);

            throw outter;
        }
    }
}
