﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpotifyLike.Api.Controllers.Request;
using SpotifyMs.Aplication.Conta;
using SpotifyMs.Aplication.Conta.Dto;

namespace SpotifyMs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize(Roles = "spotifylike-user")]
    public class UserController : ControllerBase
    {
        private UsuarioService _usuarioService;

        public UserController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public IActionResult Criar(UsuarioDto dto)
        {
            if (ModelState is { IsValid: false})
                return BadRequest();
           
            var result = this._usuarioService.Criar(dto);

            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult Obter(Guid id)
        {
            var result = this._usuarioService.Obter(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("login")] 
        public IActionResult Login([FromBody] LoginRequest login)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            var result = this._usuarioService.Autenticar(login.Email, login.Senha);

            if (result == null)
            {
                return BadRequest(new
                {
                    Error = "email ou senha inválidos"
                });
            }

            return Ok(result);

        }

    }
}
