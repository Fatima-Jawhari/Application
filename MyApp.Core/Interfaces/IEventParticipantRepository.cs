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
        Task <IEnumerable<EventParticipant>> GetAsync (string id);
        Task AddAsync (EventParticipant eventParticipant);
        Task DeleteAsync (string id);
    }
}
