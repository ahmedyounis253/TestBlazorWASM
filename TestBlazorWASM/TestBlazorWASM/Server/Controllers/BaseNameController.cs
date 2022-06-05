namespace TestBlazorWASM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseNameController<TEntity> : BaseGenericController<TEntity> where TEntity : BaseNameEntity

    {
        private readonly IBaseNameUnitOfWork<TEntity> _unitOfWork;

        public BaseNameController(IBaseNameUnitOfWork<TEntity> unitOfWork) : base(unitOfWork) => _unitOfWork = unitOfWork;

        [HttpGet("Search/{searchText}")]
        public virtual async Task<IEnumerable<TEntity>?> Get(string searchText) => await _unitOfWork.Search(searchText);

    }
}
