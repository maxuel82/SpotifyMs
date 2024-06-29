using Microsoft.AspNetCore.Mvc;
using SpotifyMs.Aplication.Admin;
using SpotifyMs.Aplication.Streaming;

namespace SpotifyMs.Admin.Controllers
{
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
    }
}
