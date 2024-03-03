using System.ComponentModel.DataAnnotations;

namespace Entities.Entities
{
    public class ShortenedURL
    {
        [Key]
        public string Key { get; set; }

        [Required]
        //[Url]
        public string LongURL { get; set; }

        //[Url]
        public string ShortURL { get; set; }
    }
}
