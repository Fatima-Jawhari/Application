using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp1.Core.Entities;

namespace MyApp1.Core.Interfaces
{
    public interface ISavedPostRepository
    {
        Task<IEnumerable<SavedPost>> GetAllAsync();
        Task<IEnumerable<SavedPost>> GetByIdAsync(int id);
        Task AddAsync(SavedPost savedPost);
        Task DeleteAsync(SavedPost savedPost);
    }
}
