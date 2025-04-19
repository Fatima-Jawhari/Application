using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp1.Core.Entities;

namespace MyApp1.Core.Interfaces
{
    public interface IHashtagRepository
    {
        Task <IEnumerable<Hashtag>> GetAllAsync();
        Task<IEnumerable<Hashtag>> GetByIdAsync(int id);
        Task AddAsync (Hashtag hashtag);
        Task DeleteAsync(Hashtag hashtag);
    }
}
