using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpotifyMs.Aplication.Admin;
using SpotifyMs.Aplication.Admin.Dto;

namespace SpotifyMs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "SpotifyMs-user")]
    public class SegredoController : ControllerBase
    {
        private SegredoService _segredoService;

        public SegredoController(SegredoService segredoService)
        {
            _segredoService = segredoService;
        }

        [HttpGet("{chave}")]
        public IActionResult Get(String chave)
        {
            var result = this._segredoService.Obter(chave);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        
        [HttpGet]
        public IActionResult GetSegredos()
        {
            var result = this._segredoService.Obter();

            return Ok(result);
        }


        [HttpPost]
        public IActionResult Criar([FromBody] SegredoDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._segredoService.Criar(dto);

            return Created($"/banda/{result.Chave}", result);
        }

    }
}
