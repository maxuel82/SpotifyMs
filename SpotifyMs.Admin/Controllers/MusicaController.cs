using Microsoft.AspNetCore.Mvc;
using SpotifyMs.Aplication.Streaming;

namespace SpotifyMs.Admin.Controllers
{
    public class MusicaController : Controller
    {
        private MusicaService musicaService;

        public MusicaController(MusicaService musicaService)
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
