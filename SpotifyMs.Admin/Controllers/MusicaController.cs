using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpotifyMs.Aplication.Streaming;
using SpotifyMs.Aplication.Streaming.Dto;

namespace SpotifyMs.Admin.Controllers
{
    [Authorize]
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

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Salvar(MusicaDto dto)
        {
            if (ModelState.IsValid == false)
                return View("Criar");

            this.musicaService.Criar(dto);

            return RedirectToAction("Index");
        }

    }
}
