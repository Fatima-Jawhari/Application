using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp1.Core.Entities;

namespace MyApp1.Core.Interfaces
{
    public interface ICommunityMembershipRepository
    {
        Task <IEnumerable<ICommentRepository>> GetAsync(Guid id);
        Task JoinAsync(CommunityMembership communityMembership);
        Task LeaveAsync(int id);
    }
}
