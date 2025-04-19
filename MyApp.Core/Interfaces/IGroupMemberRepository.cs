using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp1.Core.Entities;

namespace MyApp1.Core.Interfaces
{
    public interface IGroupMemberRepository
    {
        Task<IEnumerable<GroupMember>> GetAllAsync();
        Task AddAsync(GroupMember groupMember);
        Task DeleteAsync(GroupMember groupMember);
    }
}
