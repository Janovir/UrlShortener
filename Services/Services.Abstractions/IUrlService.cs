using System.Threading.Tasks;
using BusinessLayer.Models;

namespace BusinessLayer.Services.Abstraction
{
    public interface IUrlService
    {
        /// <summary>
        /// Saves original URL to a db and creates a shortened URL
        /// </summary>
        /// <param name="originalUrl">original URL</param>
        /// <returns>Shortened URL entity</returns>
        Task<ShortUri> CreateShortUrlAsync(string originalUrl);


        /// <summary>
        /// Retrieves original URL 
        /// </summary>
        /// <param name="key">A key used for identification</param>
        /// <returns>Original URL</returns>
        Task<string> GetOriginalUrlAsync(string key);
    }
}
