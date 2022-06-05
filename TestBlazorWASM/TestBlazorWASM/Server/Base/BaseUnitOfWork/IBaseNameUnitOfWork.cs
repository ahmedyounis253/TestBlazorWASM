namespace TestBlazorWASM.Server
{
    public interface IBaseNameUnitOfWork<TEntity> :IBaseUnitOfWork<TEntity>, IDisposable where TEntity : BaseNameEntity
    {
        Task<IEnumerable<TEntity>> Search(string seachText);

    }
}
