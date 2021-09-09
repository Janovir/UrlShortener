namespace UrlShortener.Models
{
    public class ShortUrlViewModel
    {
        public string ShortenedUrl { get; set; }
        public string FormattedExpiryDate { get; set; } //Note: it would be better to use Datetime, but it was done like this for simplicity of use
    }
}
