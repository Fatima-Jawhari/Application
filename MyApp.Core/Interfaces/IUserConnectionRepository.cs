using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp1.Core.Entities;

namespace MyApp1.Core.Interfaces
{
    public interface IUserConnectionRepository
    {
        Task<IEnumerable<UserConnection>> GetAllAsync();
        Task<IEnumerable<UserConnection>> GetByIdAsync(int id);
        Task<IEnumerable<Guid>> GetByUserIdAsync(Guid userId);
        Task ConnectAsync(Guid userId, Guid otherUserId);
        Task DisconnectAsync(Guid userId, Guid otherUserId);
    }
}
