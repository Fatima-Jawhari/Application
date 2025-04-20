using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp1.Core.Entities;

namespace MyApp1.Core.Interfaces
{
    public interface IGroupRepository
    {
        Task <IEnumerable<Group>> GetAllAsync ();
        Task AddAsync (Group group);
        Task UpdateAsync (Group group);
        Task DeleteAsync (int id);

    }
}
