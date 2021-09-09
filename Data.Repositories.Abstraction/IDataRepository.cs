using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IDataRepository
    {
        Task<string> GetOriginalUrlAsync(int id);
        Task<Link> CreateAsync(string longUrl); 
    }
}
