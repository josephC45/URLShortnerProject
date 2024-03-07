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
            ShortenedURL? returningUrl = await _urlRepository.GetShortenedUrl(longUrl);
            if(returningUrl == null)
            {
                returningUrl = await _urlRepository.CreateShortenedUrl(longUrl);
            }
            return JsonSerializer.Serialize(returningUrl.ShortURL);
        }

        [HttpPut]
        /*
         * My idea is that the put command will handle creating
         * and updating records within db depending on whether the longUrl exists or not.
         * The return of a string is a placeholder for now. May be returning the entire ShortUrl obj since my plan is to have a link showing the shorturl that then redirects to the original longurl. Will need to look into whether I am able to redirect to this action from the get method above ^
         */
        public async Task<ActionResult<string>> Put(string longUrl)
        {
            ShortenedURL newShortUrl = await _urlRepository.CreateShortenedUrl(longUrl);
            return JsonSerializer.Serialize(newShortUrl.ShortURL);
        }

        [HttpDelete]
        public string Delete()
        {
            return "Hello world";

        }
    }
}
