using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp1.Core.Entities;

namespace MyApp1.Core.Interfaces
{
    public interface ILikeRepository
    {
        Task<IEnumerable<Like>> GetAlltAsync();
        Task AddAsync(Like like);
        Task Delete(Like like);
    }
}
