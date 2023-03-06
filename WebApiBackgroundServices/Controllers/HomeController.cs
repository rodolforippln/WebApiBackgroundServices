
using Microsoft.AspNetCore.Mvc;

namespace WebApiBackgroundServices.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
            => Ok($"{DateTime.UtcNow:o}");
    }
}
