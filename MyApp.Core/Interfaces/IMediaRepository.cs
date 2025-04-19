using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp1.Core.Entities;

namespace MyApp1.Core.Interfaces
{
    public interface IMediaRepository
    {
        Task<IEnumerable<Media>> GetAllAsync();
        Task AddAsync(Media media);
        Task UpdateAsync(Media media);
        Task DeleteAsync(Media media);
    }
}
