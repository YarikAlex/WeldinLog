namespace MyWeldingLog.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> Insert(T entity, CancellationToken token);
        
        Task<IEnumerable<T>> Select(CancellationToken token);

        Task<bool> Delete(T entity, CancellationToken token);
    }
}