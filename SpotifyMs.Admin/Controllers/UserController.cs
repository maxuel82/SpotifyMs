using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpotifyMs.Aplication.Admin;
using SpotifyMs.Aplication.Admin.Dto;

namespace SpotifyMs.Admin.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private UsuarioAdminService usuarioAdminService;

        public UserController(UsuarioAdminService usuarioAdminService)
        {
            this.usuarioAdminService = usuarioAdminService;
        }

        public IActionResult Index()
        {
            var result = this.usuarioAdminService.ObterTodos();
            return View(result);
        }
        
        [AllowAnonymous]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Salvar(UsuarioAdminDto dto)
        {
            if (ModelState.IsValid == false)
                return View("Criar");

            this.usuarioAdminService.Salvar(dto);

            return RedirectToAction("Index");
        }
    }
}
