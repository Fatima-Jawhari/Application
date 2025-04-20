using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp1.Core.Entities;

namespace MyApp1.Core.Interfaces
{
    public interface INotificationRepository
    {
        Task<IEnumerable<Notification>> GetAllAsync();
        Task<IEnumerable<Notification>> GetByUserIdAsync(Guid userId);
        Task SendAsync(Notification notification);
        Task MarkReadAsync(Notification notification);
        Task DeleteAsync(Guid id);
    }
}
