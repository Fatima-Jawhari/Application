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
        Task <IEnumerable<ICommentRepository>> GetAsync (int id);
        Task AddAsync(CommunityMembership communityMembership);
        Task DeleteAsync (int id);
    }
}
