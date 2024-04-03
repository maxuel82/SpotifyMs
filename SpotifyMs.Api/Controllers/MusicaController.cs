﻿using Microsoft.AspNetCore.Mvc;
using SpotifyMs.Aplication.Streaming;
using SpotifyMs.Aplication.Streaming.Dto;
using SpotifyMs.Domain.Conta.Agreggates;
using SpotifyMs.Domain.Streaming.Aggregates;

namespace SpotifyMs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MusicaController : Controller
    {
        private MusicaService _musicaService;

        public MusicaController(MusicaService musicaService)
        {
            _musicaService = musicaService;
        }

        [HttpGet]
        public IActionResult GetMusicas()
        {
            var result = this._musicaService.GetAll();

            return Ok(result);
        }

        //Buscar  
        [HttpGet("{nome}")]
        public IActionResult GetMusicas(String nome)
        {
            var result = this._musicaService.Buscar(nome);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        
    }

 }
