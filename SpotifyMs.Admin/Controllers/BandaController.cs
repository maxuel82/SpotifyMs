using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpotifyMs.Aplication.Admin;
using SpotifyMs.Aplication.Admin.Dto;
using SpotifyMs.Aplication.Streaming;
using SpotifyMs.Aplication.Streaming.Dto;

namespace SpotifyMs.Admin.Controllers
{
    [Authorize]
    public class BandaController : Controller
    {
        private BandaService bandaService;

        public BandaController(BandaService bandaService)
        {
            this.bandaService = bandaService;
        }

        public IActionResult Index()
        {
            var result = this.bandaService.Obter();
            return View(result);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Salvar(BandaDto dto)
        {
            if (ModelState.IsValid == false)
                return View("Criar");

            this.bandaService.Criar(dto);

            return RedirectToAction("Index");
        }

    }
}
