using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyWeldingLog.Models.Hierarchy;

namespace MyWeldingLog.DAL.Interfaces.Hierarchy
{
    public interface IProjectCodeRepository : IBaseRepository<ProjectCode>
    {
        Task<ProjectCode?> Get(int id, CancellationToken token);
        
        Task<EntityEntry<ProjectCode>> Update(ProjectCode projectCode, CancellationToken token);
    }
}