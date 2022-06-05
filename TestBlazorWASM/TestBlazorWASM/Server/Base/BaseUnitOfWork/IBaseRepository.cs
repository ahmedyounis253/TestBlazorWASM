
namespace TestBlazorWASM.Server
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {

        Task<TEntity> Get(Guid id);
        Task<IEnumerable<TEntity>> Get();

        Task Add(TEntity entity);
        Task Add(IEnumerable<TEntity> entities);

        Task Update(TEntity entity,bool saveChanges=true);
        Task Update(IEnumerable<TEntity> entities);

        Task Remove(Guid id);
        Task Remove(TEntity entity);
        Task Remove(IEnumerable<TEntity> entities);

        Task<IDbContextTransaction> GetTransaction();
    }
}
