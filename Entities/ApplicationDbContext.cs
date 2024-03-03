using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace URLShortnerAPI.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<ShortenedURL> ShortnedURL {  get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {
        }

        public ApplicationDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ShortenedURL>().HasData(new ShortenedURL()
            {
                Key = "test",
                LongURL = "test",
                ShortURL = "test"
            });
        }
    }
}
