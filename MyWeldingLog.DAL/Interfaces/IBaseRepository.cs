namespace MyWeldingLog.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task Insert(T entity);
        
        Task<T[]> Select();

        Task<bool> Delete(T entity);

        Task Update(T entity);
    }
}