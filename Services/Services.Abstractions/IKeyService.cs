using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstraction
{
    /// <summary>
    /// Handles key creation and conversion to/from integer
    /// </summary>
    public interface IKeyService
    {
        /// <summary>
        /// Provides records's id converted to a key
        /// </summary>
        /// <param name="id">Id of a record</param>
        /// <returns></returns>
        Task<string> GetKeyAsync(int id);

        /// <summary>
        /// Provides integer representation of a key
        /// </summary>
        /// <param name="key">Key to convert</param>
        /// <returns>Integer representation of the key</returns>
        Task<int> GetIdAsync(string key);
    }
}
