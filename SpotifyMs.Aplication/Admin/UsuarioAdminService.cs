﻿using AutoMapper;
using SpotifyMs.Aplication.Admin.Dto;
using SpotifyMS.Domain.Admin.Aggregates;
using SpotifyMS.Domain.Core.Extension;
using SpotifyMS.Repository.Repository;

namespace SpotifyMs.Aplication.Admin
{
    public class UsuarioAdminService
    {
        private UsuarioAdminRepository Repository { get; set; }
        private IMapper mapper { get; set; }
        public UsuarioAdminService(UsuarioAdminRepository repository, IMapper mapper)
        {
            Repository = repository;
            this.mapper = mapper;
        }

        public IEnumerable<UsuarioAdminDto> ObterTodos()
        {
            var result = this.Repository.GetAll();
            return this.mapper.Map<IEnumerable<UsuarioAdminDto>>(result);
        }

        public void Salvar(UsuarioAdminDto dto)
        {
            var usuario = this.mapper.Map<UsuarioAdmin>(dto);
            usuario.CriptografarSenha();
            this.Repository.Save(usuario);
        }

        public UsuarioAdmin Authenticate(string email, string password)
        {
            var passwordCipher = password.HashSHA256();
            var user = this.Repository.GetUsuarioAdminByEmailAndPassword(email, passwordCipher);
            return user;
        }
    }
}
