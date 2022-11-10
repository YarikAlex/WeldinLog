using MyWeldingLog.Models.Hierarchy;

namespace MyWeldingLog.DAL.Interfaces.Hierarchy
{
    public interface ISubObjectRepository : IBaseRepository<SubObject>
    {
        Task<SubObject?> Get(int id);
    }
}