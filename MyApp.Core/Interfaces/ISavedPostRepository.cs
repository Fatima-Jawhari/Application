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
        Task<IEnumerable<Guid>> GetByUserIdAsync(Guid userId);
        Task SaveAsync(Guid userId, Guid postId);
        Task UnsaveAsync(Guid userId, Guid postId);
    }
}
