using Microsoft.AspNetCore.Mvc;
using SBcredito.Domain.Contracts.Services;
using SBcredito.Domain.Models;

namespace SBcredito.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TituloAnaliseController : ControllerBase
    {
        private readonly ITituloAnaliseService _tituloAnaliseService;

        public TituloAnaliseController(ITituloAnaliseService tituloAnaliseService)
        {
            _tituloAnaliseService = tituloAnaliseService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TituloAnaliseModel tituloAnaliseModel)
        {
            var model = await _tituloAnaliseService.Add(tituloAnaliseModel);

            return Ok(model);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var model = await _tituloAnaliseService.GetbyId(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var model = await _tituloAnaliseService.GetAll();

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TituloAnaliseModel tituloAnaliseModel)
        {
            var modelUpdated = await _tituloAnaliseService.Update(id, tituloAnaliseModel);

            return Ok(modelUpdated);
        }

        [HttpDelete("{id:int}")]
        public async Task<NoContentResult> Delete(int id)
        {
            await _tituloAnaliseService.Remove(id);

            return NoContent();
        }

        [HttpGet("total")]
        public async Task<IActionResult> GetTotal()
        {
            var model = await _tituloAnaliseService.GetTotal();

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }
    }
}
