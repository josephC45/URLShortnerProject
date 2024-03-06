using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryInterfaces;
using System.Text.Json;

namespace URLShortnerAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IUrlRepository _urlRepository;
        public MainController(IUrlRepository urlRepository)
        {
            _urlRepository = urlRepository;
        }

        [HttpGet]
        public async Task<ActionResult<string>> Get(string longUrl)
        {
            ShortenedURL returningUrl = await _urlRepository.GetShortenedUrl(longUrl);
            if(returningUrl == null )
            {
                String error = "Error occurred did not find record";
                return JsonSerializer.Serialize(error);

            }
            //For testing purposes
            String s = returningUrl.ShortURL + "1";
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
