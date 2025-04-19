using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp1.Core.Entities;

namespace MyApp1.Core.Interfaces
{
    public interface ISettingRepository
    {
        Task<IEnumerable<Setting>> GetAllAsync();
        Task AddAsync(Setting setting);
        Task UpdateAsync(Setting setting);
    }
}
