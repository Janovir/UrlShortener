using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IUrlService
    {
        Task<ShortUri> CreateShortUrlAsync(string originalUrl);
        Task<string> GetOriginalUrlAsync(string key);
    }
}
