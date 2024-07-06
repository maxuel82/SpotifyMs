using Microsoft.AspNetCore.Mvc;
using SpotifyMs.Aplication.Streaming.Dto;
using SpotifyMs.Aplication.Streaming;
using Microsoft.AspNetCore.Authorization;

namespace SpotifyMs.Admin.Controllers
{

    [Authorize]
    public class ListagemMusicasController : Controller
    {
        private MusicaService musicaService;

        public ListagemMusicasController(MusicaService musicaService)
        {
            this.musicaService = musicaService;
        }

        public IActionResult Index()
        {
            var result = this.musicaService.GetAll();
            return View(result);
        }

    }
}
