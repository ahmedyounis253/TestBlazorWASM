
namespace TestBlazorWASM.Server
{
    public interface IBaseNameRepository<TEntity> :IBaseRepository<TEntity>, IDisposable where TEntity : BaseNameEntity  
    {
        Task<IEnumerable<TEntity>> Search(string seachtext);
    }
}
