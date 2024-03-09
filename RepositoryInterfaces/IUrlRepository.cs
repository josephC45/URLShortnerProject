using Entities.Entities;

namespace RepositoryInterfaces
{
    public interface IUrlRepository
    {
        Task<ShortenedURL> GetShortenedUrl(string longUrl);
        Task<ShortenedURL> CreateShortenedUrl(string longUrl);
        Task<ShortenedURL> UpdateShortenedUrl(string longUrl);
        Task<bool> DeleteUrl(string longUrl);
    }
}
