using Entities.Entities;

namespace RepositoryInterfaces
{
    public interface IUrlRepository
    {
        //Will be initially called GET
        Task<ShortenedURL> GetShortenedUrl(string longUrl);
        /*If the long url does not exist already in the db then we will create a hash and shortenedURL with a post command
         * POST
         */
        Task<ShortenedURL> CreateShortenedUrl(String longUrl);
        /*Once the get is called if the longurl exists 
         * a new hash will be created, we will then be calling the update with a put.
         * PUT
         */
        Task<ShortenedURL> UpdateShortenedUrl(string longUrl);
        /*Will only be called if the delete button is pressed and the long url exists.
         */
        Task<bool> DeleteUrl(string longUrl);

    }
}
