using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp1.Core.Entities;

namespace MyApp1.Core.Interfaces
{
    public interface ICommunityRepository
    {
        Task<IEnumerable<Community>> GetAllAsync();
        Task<IEnumerable<Community>> GetByIdAsync(int id);
        Task AddAsync(Community community);
        Task UpdateAsync(Community community);
        Task DeleteAsync(int id);
    }
}
