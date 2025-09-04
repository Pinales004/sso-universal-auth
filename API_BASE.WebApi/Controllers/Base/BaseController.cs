using Microsoft.AspNetCore.Mvc;
using API_BASE.Application.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;

namespace API_BASE.WebApi.Controllers
{
    [ApiController]
    public abstract class BaseController<TDto, TCreateDto, TUpdateDto, TEntity, TId> : ControllerBase
    {
        protected readonly IRepository<TEntity, TId> _repository;
        protected readonly IMapper _mapper;

        protected BaseController(IRepository<TEntity, TId> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<ActionResult<List<TDto>>> GetAll(CancellationToken ct = default)
        {
            var entities = await _repository.GetAllAsync(ct);
            var dtos = _mapper.Map<List<TDto>>(entities);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TDto>> GetById(TId id, CancellationToken ct = default)
        {
            var entity = await _repository.GetByIdAsync(id, ct);
            if (entity == null) return NotFound();
            var dto = _mapper.Map<TDto>(entity);
            return Ok(dto);
        }

        [HttpPost]
        public virtual async Task<ActionResult<TDto>> Create([FromBody] TCreateDto dto, CancellationToken ct = default)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _repository.AddAsync(entity, ct);
            await _repository.SaveChangesAsync(ct);
            var resultDto = _mapper.Map<TDto>(entity);
            return CreatedAtAction(nameof(GetById), new { id = GetId(resultDto) }, resultDto);
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update(TId id, [FromBody] TUpdateDto dto, CancellationToken ct = default)
        {
            var entity = await _repository.GetByIdAsync(id, ct);
            if (entity == null) return NotFound();
            _mapper.Map(dto, entity);
            _repository.Update(entity);
            await _repository.SaveChangesAsync(ct);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(TId id, CancellationToken ct = default)
        {
            var entity = await _repository.GetByIdAsync(id, ct);
            if (entity == null) return NotFound();
            _repository.Remove(entity);
            await _repository.SaveChangesAsync(ct);
            return NoContent();
        }

        protected abstract TId GetId(TDto dto);
    }
}
