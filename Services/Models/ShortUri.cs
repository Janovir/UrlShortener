namespace BusinessLayer.Models
{
    public class ShortUri
    {
        public string ShortenedUrl { get; set; }
        public string FormattedExpiryDate { get; set; } //Note: would be better to use Datetime, but it was done like this for simplicity
    }
}
