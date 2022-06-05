namespace TestBlazorWASM.Server
{
    public abstract class BaseRepository<TEntity>: IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected DbSet<TEntity> dbSet;

        private readonly ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            dbSet = _context.Set<TEntity>();
           
        }

        public virtual async Task<TEntity> Get(Guid id) => await
                                            dbSet.FirstOrDefaultAsync(e => e.Id == id) ?? Activator.CreateInstance<TEntity>();

        public virtual async Task<IEnumerable<TEntity>> Get()=> await dbSet.ToListAsync();

        public virtual async Task Add(TEntity entity)
        {
            CheckNullParameter(entity);
            await dbSet.AddAsync(entity);
            await SaveChangesAsync();
        }

        public virtual async Task Add(IEnumerable<TEntity> entities)
        {
            CheckNullParameter(entities);

            await dbSet.AddRangeAsync(entities);
            await SaveChangesAsync();
        }

        public virtual async Task Update(IEnumerable<TEntity> entities)
        {
            CheckNullParameter(entities);

            foreach (TEntity entity in entities)
                await Update(entity,false);
            await SaveChangesAsync();
        }

        public virtual async Task Update(TEntity entity, bool saveChanges = true)
        {
            CheckNullParameter(entity);
            await CheckIfInDatabaseAsync(entity);

            await Task.Run(() => { dbSet.Update(entity); });
            
            if(saveChanges)
                await SaveChangesAsync();
        }


        public virtual async Task Remove(Guid id)
        {
            TEntity? entity = await CheckIfInDatabaseAsync(id);

            await Task.Run(() => dbSet.Remove(entity));
            await SaveChangesAsync();

        }

        public virtual async Task Remove(TEntity entity)
        {
            CheckNullParameter(entity);
            TEntity? entityfromDB = await CheckIfInDatabaseAsync(entity);

            await Task.Run(() => dbSet.Remove(entityfromDB));
            await SaveChangesAsync();

        }

        public virtual async Task Remove(IEnumerable<TEntity> entities)
        {
            CheckNullParameter(entities);
            foreach(TEntity entity in entities)
                await CheckIfInDatabaseAsync(entity);
            
            await Task.Run(() => dbSet.RemoveRange(entities));
            await SaveChangesAsync();
        }

        public virtual async Task<IDbContextTransaction> GetTransaction() => await _context.Database.BeginTransactionAsync();

        protected async Task SaveChangesAsync() => await _context.SaveChangesAsync(); 
        
        public void Dispose()=> _context.Dispose();

        private  async Task<TEntity> CheckIfInDatabaseAsync(TEntity entity)
        {
            TEntity? ent = await Get(entity.Id.Value);
            if (ent == null) 
                throw new ArgumentNullException($"{nameof(TEntity)} was not found in DB");
            return ent;

        }
        private  async Task<TEntity> CheckIfInDatabaseAsync(Guid id)
        {
            TEntity? ent = await Get(id);
            if (ent == null)
                throw new ArgumentNullException($"{nameof(TEntity)} was not found in DB");
            return ent;

        }

        private  void CheckNullParameter(TEntity entity)
        {
            if (entity == null) 
                throw new ArgumentNullException($"{nameof(TEntity)} was not provided");
        }
        private  void CheckNullParameter(IEnumerable<TEntity> entities)
        {
            if (entities == null || !entities.Any()) 
                throw new ArgumentNullException($"{nameof(TEntity)} was not provided");
        }

    }
}
