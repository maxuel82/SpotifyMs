﻿using SpotifyMs.Aplication.Conta.Dto;
using SpotifyMs.Domain.Conta.Agreggates;
using SpotifyMs.Domain.Transacao.Agreggates;

namespace SpotifyMs.Aplication.Conta.Profile
{
    public class UsuarioProfile : AutoMapper.Profile
    {
        public UsuarioProfile() 
        {
            CreateMap<UsuarioDto, Usuario>();

            CreateMap<Usuario, UsuarioDto>()
            .AfterMap((s, d) =>
             {
                 var plano = s.Assinaturas?.FirstOrDefault(a => a.Ativo)?.Plano;

                 if (plano != null)
                     d.PlanoId = plano.Id;

                 d.Senha = "xxxxxxxxx";
                 
             });

            CreateMap<CartaoDto, Cartao>()
                .ForPath(x => x.Limite.Valor, m => m.MapFrom(f => f.Limite))
                .ReverseMap();
        }
    }
}
