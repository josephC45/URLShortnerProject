using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace URLShortnerAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            String s = "Hello World";
            return JsonSerializer.Serialize(s);
        }

        [HttpPut]
        public string Put()
        {
            return "Hello world";

        }

        [HttpPost]
        public string Post()
        {
            return "Hello world";

        }

        [HttpDelete]
        public string Delete()
        {
            return "Hello world";

        }



    }
}
