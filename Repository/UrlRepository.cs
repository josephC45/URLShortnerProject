using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using URLShortnerAPI.DatabaseContext;

namespace Repository
{
    public class UrlRepository : IUrlRepository
    {
        private readonly ApplicationDbContext _db;
        public UrlRepository(ApplicationDbContext db)
        {
            this._db = db;
        }

        public async Task<ShortenedURL> CreateShortenedUrl(string longUrl)
        {
            ShortenedURL? url = await GetShortenedUrl(longUrl);
            if(url == null) return await UpdateShortenedUrl(url.LongURL);
            //Generate new shorturl with hash, and return shorturl obj
            return null;
            
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
            return await _db.ShortnedURL.FirstOrDefaultAsync(url => url.Equals(longUrl));
        }

        public async Task<ShortenedURL> UpdateShortenedUrl(string longUrl)
        {
            ShortenedURL matchingUrl = await _db.ShortnedURL.FirstAsync(url => url.LongURL.Equals(longUrl));
            //calculate new hash
            //matchingUrl.shortUrl = new url generated with hash
            await _db.SaveChangesAsync();
            return matchingUrl;

        }
    }
}
