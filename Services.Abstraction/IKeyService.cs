using System;
using System.Threading.Tasks;

namespace Services
{
    public interface IKeyService
    {
        ValueTask<string> GetKeyAsync(int id);
        Task<int> GetIdAsync(string key);
    }
}
