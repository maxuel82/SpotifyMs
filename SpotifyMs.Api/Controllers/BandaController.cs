using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos.Serialization.HybridRow;
using SpotifyMs.Aplication.Streaming;
using SpotifyMs.Aplication.Streaming.Dto;

namespace SpotifyMs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "SpotifyMs-user")]
    public class BandaController : ControllerBase
    {
        private BandaService _bandaService;

        public BandaController(BandaService bandaService)
        {
            _bandaService = bandaService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetBandas()
        {
            var result = this._bandaService.Obter();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetBandas(Guid id)
        {
            var result = this._bandaService.Obter(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] BandaDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._bandaService.Criar(dto);

            return Created($"/banda/{result.Id}", result);
        }

        [HttpPut]
        public IActionResult Update([FromBody] BandaDto bandaDto)
        {
            try
            {
                var result = this._bandaService.Update(bandaDto);
                return Created($"/banda/{result.Id}", result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Se o registro não foi encontrado, retorna 404.
            }
            catch (Exception ex)
            {
                // Lidar com outras exceções se necessário
                return StatusCode(500, "Ocorreu um erro interno.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                this._bandaService.Delete(id);
                return NoContent(); // Retorna 204 No Content, indicando que a operação foi bem-sucedida.
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Se o registro não foi encontrado, retorna 404.
            }
            catch (Exception ex)
            {
                // Lidar com outras exceções se necessário
                return StatusCode(500, "Ocorreu um erro interno.");
            }
        }

        [HttpPost("{id}/albums")]
        public IActionResult AssociarAlbum(AlbumDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._bandaService.AssociarAlbum(dto);

            return Created($"/banda/{result.BandaId}/albums/{result.Id}", result);

        }

        [HttpGet("{idBanda}/albums/{id}")]
        public IActionResult ObterAlbumPorId(Guid idBanda, Guid id)
        {
            var result = this._bandaService.ObterAlbumPorId(idBanda, id);

            if (result == null)
                return NotFound();

            return Ok(result);

        }

        [HttpGet("{idBanda}/albums")]
        public IActionResult ObterAlbuns(Guid idBanda)
        {
            var result = this._bandaService.ObterAlbum(idBanda);

            if (result == null)
                return NotFound();

            return Ok(result);

        }

    }
}
