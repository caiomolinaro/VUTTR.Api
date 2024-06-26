using Api.Models;
using Api.Models.DTOs;
using Api.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<ActionResult> CreateTool(ToolsDTO tools, CancellationToken cancellationToken)
        {
            var toolEntity = _mapper.Map<ToolsEntity>(tools);
            var toolCreated = await _toolsData.CreateAsync(toolEntity, cancellationToken);
            return Created("Crated tool", toolCreated);
        }
    }
}