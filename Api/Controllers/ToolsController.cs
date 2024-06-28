using Api.Models;
using Api.Models.DTOs;
using Api.Repositories;

namespace Api.Controllers
{
    [Route("tools")]
    [ApiController]
    public class ToolsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IToolsData _toolsData;

        public ToolsController(IMapper mapper, IToolsData toolsData)
        {
            _mapper = mapper;
            _toolsData = toolsData;
        }

        [HttpPost]
        public async Task<ActionResult> Create(ToolsDTO tools, IValidator<ToolsDTO> validator, CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(tools, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var toolEntity = _mapper.Map<ToolsEntity>(tools);
            var toolCreated = await _toolsData.CreateAsync(toolEntity, cancellationToken);
            return Created("Crated tool", toolCreated);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToolsDTO>>> GetTools(CancellationToken cancellationToken, [FromQuery] string? tag = null)
        {
            if (tag is null)
            {
                var tools = await _toolsData.GetAllAsync(cancellationToken);

                if (tools is null)
                {
                    return NotFound("There is no tool registered");
                }

                return Ok(tools);
            }

            var toolsByTag = await _toolsData.GetByTagAsync(tag, cancellationToken);

            if (toolsByTag is null)
            {
                return NotFound("There is no tool with this tag registered");
            }

            return Ok(toolsByTag);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<IEnumerable<ToolsDTO>>> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var toolById = await _toolsData.GetByIdAsync(id, cancellationToken);

            if (toolById is null)
            {
                return NotFound("Tool not found");
            }

            await _toolsData.DeleteAsync(toolById, cancellationToken);
            return Ok();
        }
    }
}