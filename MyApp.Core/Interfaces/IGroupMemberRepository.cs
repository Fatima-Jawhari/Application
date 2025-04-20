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
        Task AddMemberAsync(GroupMember groupMember);
        Task RemoveMemberAsync(Guid groupId, Guid userId);
    }
}
