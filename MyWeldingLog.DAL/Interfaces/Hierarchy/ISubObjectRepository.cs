using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyWeldingLog.Models.Hierarchy;

namespace MyWeldingLog.DAL.Interfaces.Hierarchy
{
    public interface ISubObjectRepository : IBaseRepository<SubObject>
    {
        Task<SubObject?> Get(int id, CancellationToken token);
        
        Task<EntityEntry<SubObject>> Update(SubObject subObject, CancellationToken token);
    }
}