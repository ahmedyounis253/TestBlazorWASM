namespace TestBlazorWASM.Server
{
    public abstract class BaseNameRepository<TEntity> :BaseRepository<TEntity> ,IBaseNameRepository<TEntity> where TEntity : BaseNameEntity
    {

        public BaseNameRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<TEntity>> Search(string seachtext) =>
               await Task.Run(() => dbSet.Where(e => e.Name.Contains(seachtext))) ;


    }
}
