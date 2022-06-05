namespace TestBlazorWASM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseGenericController<TEntity> : ControllerBase where TEntity : BaseEntity
    {
        private readonly IBaseUnitOfWork<TEntity> _unitOfWork;

        public  BaseGenericController(IBaseUnitOfWork<TEntity> unitOfWork) => _unitOfWork=unitOfWork;

        [HttpPost]
        public virtual async Task Post([FromBody] TEntity entity) => await _unitOfWork.Create(entity);

        [HttpGet]
        public virtual async Task<IEnumerable<TEntity>?> Get() => await _unitOfWork.Read();
        [HttpGet("{id}")]
        public virtual async Task<TEntity> Get(Guid id) => await _unitOfWork.Read(id);

        [HttpPut]
        public virtual async Task Put( [FromBody]  TEntity entity)=> await _unitOfWork.Update(entity);

        [HttpDelete("{id}")]
        public virtual async Task DeleteAsync(Guid id) => await _unitOfWork.Delete(id);
    }
}
