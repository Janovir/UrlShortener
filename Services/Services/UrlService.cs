using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using DataLayer.Repositories.Abstraction;
using BusinessLayer.Models;
using BusinessLayer.Services.Abstraction;
using System;

namespace BusinessLayer.Services
{
    public class UrlService : IUrlService
    {
        private readonly string _urlTemplate;
        private readonly IDataRepository _dataRepository;
        private readonly IKeyService _keyService;

        public UrlService(IDataRepository dataRepository, IKeyService keyService, IConfiguration configuration)
        {
            _urlTemplate = configuration["Settings:BaseUrl"];
            _dataRepository = dataRepository;
            _keyService = keyService;
        }

        public async Task<string> GetOriginalUrlAsync(string key)
        {
            // Convert key to record ID
            var id = await _keyService.GetIdAsync(key);

            // Get record's original URL by its ID
            var originalUrl = await _dataRepository.GetOriginalUrlAsync(id);

            return originalUrl;
        }

        /// <summary>
        /// Saves original URL to a db and creates a shortened url
        /// </summary>
        /// <param name="originalUrl"></param>
        /// <returns>Shortened URL object</returns>
        public async Task<ShortUri> CreateShortUrlAsync(string originalUrl)
        {
            // save to db
            var expiryDate = DateTime.Now.AddMonths(1);
            var link = await _dataRepository.CreateAsync(originalUrl, expiryDate.Date);
            
            // create a key based on record's ID
            var key = await _keyService.GetKeyAsync(link.Id);
            
            // create a shortened URL
            var newUrl = BuildUrl(key);
            var formattedDate = link.ExpiryDate.ToString("D");

            return new ShortUri
            {
                FormattedExpiryDate = formattedDate,
                ShortenedUrl = newUrl
            };
        }

        /// <summary>
        /// Build a return URL using template
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Shortened URI</returns>
        private string BuildUrl(string key) => $"{_urlTemplate}/{key}";
    }
}
