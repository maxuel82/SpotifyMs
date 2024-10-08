﻿using System.ComponentModel.DataAnnotations;

namespace SpotifyMs.Aplication.Admin.Dto
{
    public class UsuarioAdminDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Campo Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Campo Email não está em um formato correto")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Campo Senha é obrigatório")]
        public String Senha { get; set; }

        [Required(ErrorMessage = "Campo Perfil é obrigatório")]
        public int? Perfil { get; set; }
    }
}
