using System;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer.Repositories.Abstraction
{
    /// <summary>
    /// Used for storing records
    /// </summary>
    public interface IDataRepository
    {
        /// <summary>
        /// Get a record's URL by ID
        /// </summary>
        /// <param name="id">ID of the record</param>
        /// <returns>URL of a record</returns>
        Task<string> GetOriginalUrlAsync(int id);

        /// <summary>
        /// Creates a new record
        /// </summary>
        /// <param name="originalUrl">Original URL to save</param>
        /// <returns>ID of a new record</returns>
        Task<Link> CreateAsync(string longUrl, DateTime expiryDate);
    }
}
