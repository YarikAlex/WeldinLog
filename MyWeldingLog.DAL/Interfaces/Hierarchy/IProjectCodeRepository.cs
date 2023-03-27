using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyWeldingLog.Models.Hierarchy;

namespace MyWeldingLog.DAL.Interfaces.Hierarchy
{
    public interface IProjectCodeRepository : IBaseRepository<ProjectCode>
    {
        Task<ProjectCode> GetById(int id, CancellationToken token);
        
        Task<ProjectCode> Update(ProjectCode projectCode, CancellationToken token);
    }
}