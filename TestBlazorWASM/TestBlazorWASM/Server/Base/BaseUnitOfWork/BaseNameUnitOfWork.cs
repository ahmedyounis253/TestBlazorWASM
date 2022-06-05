namespace TestBlazorWASM.Server
{
    public class BaseNameUnitOfWork<TEntity> : BaseUnitOfWork<TEntity>, IBaseNameUnitOfWork<TEntity> where TEntity : BaseNameEntity
    {
        private readonly IBaseNameRepository<TEntity> _repository;

        public BaseNameUnitOfWork(IBaseNameRepository<TEntity> repository) : base(repository) => _repository = repository;

        public async Task<IEnumerable<TEntity>> Search(string searchText) => await _repository.Search(searchText);

    }
}
