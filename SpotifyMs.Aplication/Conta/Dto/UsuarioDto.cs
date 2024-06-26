﻿using System.ComponentModel.DataAnnotations;

namespace SpotifyMs.Aplication.Conta.Dto
{
    public class UsuarioDto
    {

        public Guid Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        public DateTime DtNascimento { get; set; }

        public Guid PlanoId { get; set; }


        [Required]
        public CartaoDto Cartao { get; set; }

    }

}
