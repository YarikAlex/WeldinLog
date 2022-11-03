namespace MyWeldingLog.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> Insert(T entity);
        
        Task<T[]> Select();

        Task<bool> Delete(T entity);
    }
}