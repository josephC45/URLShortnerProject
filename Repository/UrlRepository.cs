using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using URLShortnerAPI.DatabaseContext;
using HashGenerator;

namespace Repository
{
    public class UrlRepository : IUrlRepository
    {
        private readonly ApplicationDbContext _db;
        public UrlRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<ShortenedURL> CreateShortenedUrl(string longUrl)
        {
            ShortenedURL shortUrl = new ShortenedURL();

            shortUrl.Key = GenerateHash.GenerateNewHash();
            shortUrl.ShortURL = $"https://localhost/{shortUrl.Key}";
            shortUrl.LongURL = longUrl;

            await _db.AddAsync(shortUrl);
            await _db.SaveChangesAsync();
            return shortUrl;
        }
        public async Task<bool> DeleteUrl(string longUrl)
        {
            ShortenedURL? record = await GetShortenedUrl(longUrl);
            if (record is not null)
            {
                _db.ShortnedURL.Remove(record);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<ShortenedURL?> GetShortenedUrl(string longUrl)
        {
            return await _db.ShortnedURL.FirstOrDefaultAsync(url => url.LongURL.Equals(longUrl));
        }
        public async Task<ShortenedURL> UpdateShortenedUrl(string longUrl)
        {
            ShortenedURL matchingUrl = await _db.ShortnedURL.FirstAsync(url => url.LongURL.Equals(longUrl));
            matchingUrl.Key = GenerateHash.GenerateNewHash();
            await _db.SaveChangesAsync();
            return matchingUrl;
        }
    }
}
