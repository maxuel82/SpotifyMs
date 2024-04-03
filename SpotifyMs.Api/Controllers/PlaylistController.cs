using Microsoft.AspNetCore.Mvc;
using SpotifyMs.Aplication.Streaming;
using SpotifyMs.Aplication.Streaming.Dto;

namespace SpotifyMs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PlaylistController : Controller
    {

        private PlaylistService _playlistService;

        public PlaylistController(PlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

/*        [HttpGet]
        public IActionResult GetPlaylis()
        {
            var result = this._playlistService.GetAll();

            return Ok(result);
        }
*/

        [HttpPost("AddMusica")]
        public IActionResult AssociarMusicaAPlaylist(PlaylistDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._playlistService.AssociarMusicaAPlaylist(dto);

            return Ok(result);

        }

    }
}
