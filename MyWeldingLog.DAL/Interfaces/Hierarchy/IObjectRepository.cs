using Microsoft.EntityFrameworkCore.ChangeTracking;
using Object = MyWeldingLog.Models.Hierarchy.Object;

namespace MyWeldingLog.DAL.Interfaces.Hierarchy
{
    public interface IObjectRepository : IBaseRepository<Object>
    {
        Task<Object?> Get(int id);
        Task<EntityEntry<Object>> Update(Object obj);
    }
}