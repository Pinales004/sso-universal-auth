using API_BASE.Application.Interfaces;
using API_BASE.Shared.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_BASE.API.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController<TEntity, TDto> : ControllerBase
        where TEntity : class
        where TDto : class
    {
        protected readonly IRepository<TEntity, Guid> _repository;
        protected readonly IMapper _mapper;

        public BaseController(IRepository<TEntity, Guid> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<TDto>>>> GetAll()
        {
            var entities = await _repository.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<TDto>>(entities);
            return Ok(ApiResponse<IEnumerable<TDto>>.Ok(dtos));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ApiResponse<TDto>>> GetById(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return NotFound(ApiResponse<TDto>.Fail("No encontrado"));
            var dto = _mapper.Map<TDto>(entity);
            return Ok(ApiResponse<TDto>.Ok(dto));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<TDto>>> Create([FromBody] TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();

            // Usar reflexión para extraer el Id (supone propiedad Guid llamada "Id")
            var entityId = (Guid)entity.GetType().GetProperty("Id")!.GetValue(entity)!;
            var result = _mapper.Map<TDto>(entity);

            return CreatedAtAction(nameof(GetById), new { id = entityId }, ApiResponse<TDto>.Ok(result));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ApiResponse<TDto>>> Update(Guid id, [FromBody] TDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return NotFound(ApiResponse<TDto>.Fail("No encontrado"));

            _mapper.Map(dto, entity);
            _repository.Update(entity);
            await _repository.SaveChangesAsync();

            return Ok(ApiResponse<TDto>.Ok(_mapper.Map<TDto>(entity)));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ApiResponse<bool>>> Delete(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return NotFound(ApiResponse<bool>.Fail("No encontrado"));

            _repository.Remove(entity);
            await _repository.SaveChangesAsync();
            return Ok(ApiResponse<bool>.Ok(true));
        }
    }
}
