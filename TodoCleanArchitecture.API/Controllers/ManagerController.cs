using Microsoft.AspNetCore.Mvc;
using TodoCleanArchitecture.Application.Abstractions.Services;
using TodoCleanArchitecture.Domain.Entities;

namespace TodoCleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _managerService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Manager request)
        {
            try
            {
                var result = await _managerService.Create(request);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
