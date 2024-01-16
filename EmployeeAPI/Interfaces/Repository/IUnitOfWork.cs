namespace EmployeeAPI.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        IGenericRepository<TEntity> repository<TEntity>() where TEntity : class;
        Task<int> Complete();
    }
}
