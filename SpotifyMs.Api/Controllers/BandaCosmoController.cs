using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpotifyMs.Aplication.Streaming;
using SpotifyMs.Aplication.Streaming.Dto;

namespace SpotifyMs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "SpotifyMs-user")]
    public class BandaCosmoController : ControllerBase
    {
        private BandaCosmoService _bandaService;

        public BandaCosmoController(BandaCosmoService bandaService)
        {
            _bandaService = bandaService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllBandasCosmo()
        {
            var result = await this._bandaService.Obter();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBandasCosmo(Guid id)
        {
            var result = await this._bandaService.Obter(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CriarCosmo([FromBody] BandaDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = await this._bandaService.Criar(dto);

            return Created($"/banda/{result.Id}", result);
        }



    }
}
