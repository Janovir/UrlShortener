using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.Repositories.Abstraction;

namespace DataLayer.Repositories
{
    /// <summary>
    /// Used for storing records
    /// </summary>
    public class DataRepository : IDataRepository
    {
        private static Dictionary<int, Link> DbTableSim { get; set; } = new Dictionary<int, Link>();

        /// <summary>
        /// Get a record's URL by ID
        /// </summary>
        /// <param name="id">ID of the record</param>
        /// <returns>URL of a record</returns>
        public Task<string> GetOriginalUrlAsync(int id) => Task.FromResult(DbTableSim[id].OriginalUrl);

        /// <summary>
        /// Create a new record
        /// </summary>
        /// <param name="originalUrl">Original URL to save</param>
        /// <returns>ID of a new record</returns>
        public Task<Link> CreateAsync(string originalUrl, DateTime expiryDate)
        {
            int newId;
            // Get the next key - this would normally be done by db
            if (DbTableSim.Keys.Any())
            {
                newId = DbTableSim.Keys.ToArray().Max() + 1;
            }
            else
            {
                newId = 1;  //NOTE: indexing starts from 1
            }

            var link = new Link
            {
                Id = newId,
                OriginalUrl = originalUrl,
                ExpiryDate = expiryDate.Date
            };

            // Create a new record
            DbTableSim.Add(newId, link);

            // Return the id of the record
            return Task.FromResult(link);
        }
    }
}
