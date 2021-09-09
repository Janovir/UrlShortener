using System;

namespace DataLayer.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string OriginalUrl { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
