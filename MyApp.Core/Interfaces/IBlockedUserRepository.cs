using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp1.Core.Entities;

namespace MyApp1.Core.Interfaces
{
    public interface IBlockedUserRepository
    {
        Task<IEnumerable<BlockedUser>> GetAllAsync();
        Task BlockUserAsync(BlockedUser blockedUser);
        Task UnblockUserAsync(BlockedUser blockedUser);
    }
}
