using Microsoft.AspNetCore.Mvc;
using Utilities.Services;

namespace ChuckNorrisJokesWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JokesController : Controller
    {
        [HttpGet]
        public async Task<JsonResult> GetJokes()
        {
            ServiceJoke serviceJoke = new ServiceJoke();
           
            return Json(await serviceJoke.GetJokes());
        }
    }
}
