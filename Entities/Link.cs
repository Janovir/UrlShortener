using System;

namespace Entities
{
    public class Link
    {
        public int Id { get; set; }
        public string OriginalUrl { get; set; }
        public DateTime ExpiryDate { get; set; }

        // Note: The following could be included for enhanced functionality (not part of this scope)
        //public DateTime CreatedDate { get; set; }
        //public Guid UserId { get; set; }

        public Link(int id, string originalUrl, DateTime expiryDate)
        {
            Id = id;
            OriginalUrl = originalUrl;
            ExpiryDate = expiryDate.Date;
        }
    }
}
