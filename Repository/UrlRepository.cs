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
            ShortenedURL shortUrl = new ShortenedURL();
            /* Key and ShortUrl values are 
             * placeholders until I work out the hashing
            */
            shortUrl.Key = "1";
            shortUrl.ShortURL = "t1";
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
            //calculate new hash
            //matchingUrl.shortUrl = new url generated with hash
            await _db.SaveChangesAsync();
            return matchingUrl;

        }
    }
}
