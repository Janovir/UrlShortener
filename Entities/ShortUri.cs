using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class ShortUri
    {
        public string ShortenedUrl { get; set; }
        public string FormattedExpiryDate { get; set; } //Not the best approach, done like this for simplicity

        public ShortUri(string shortenedUrl, string formattedExpiryDate)
        {
            ShortenedUrl = shortenedUrl;
            FormattedExpiryDate = formattedExpiryDate;
        }

        //public DateTime ExpiryDate { get; set; }

        //public ShortUrl(string shortenedUrl, DateTime expiryDate)
        //{
        //    ShortenedUrl = shortenedUrl;
        //    ExpiryDate = expiryDate;
        //}
    }
}
