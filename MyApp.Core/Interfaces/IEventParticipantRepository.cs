using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp1.Core.Entities;

namespace MyApp1.Core.Interfaces
{
    public interface IEventParticipantRepository
    {
        Task <IEnumerable<EventParticipant>> GetAsync (Guid id);
        Task JoinAsync (Guid user_id,Guid event_id);
        Task LeaveAsync (Guid id ,Guid event_id);
    }
}
