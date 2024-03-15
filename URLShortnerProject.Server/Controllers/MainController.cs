﻿using Entities.Entities;
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
            else
            {
                return JsonSerializer.Serialize(returningUrl.LongURL);

            }
            return JsonSerializer.Serialize(returningUrl.ShortURL);
        }

        [HttpPut]
        public async Task<ActionResult<string>> Put(string longUrl)
        {
            ShortenedURL newShortUrl = await _urlRepository.CreateShortenedUrl(longUrl);
            return JsonSerializer.Serialize(newShortUrl.ShortURL);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(string longUrl)
        {
            bool result = await _urlRepository.DeleteUrl(longUrl);
            return result;
        }
    }
}
