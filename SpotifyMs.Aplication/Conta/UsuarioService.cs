using AutoMapper;
using SpotifyMs.Aplication.Conta.Dto;
using SpotifyMs.Domain.Conta.Agreggates;
using SpotifyMS.Domain.Core.Extension;
using SpotifyMs.Domain.Streaming.Aggregates;
using SpotifyMs.Domain.Transacao.Agreggates;
using SpotifyMS.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyMs.Domain.Notificacao;
using System.Numerics;

namespace SpotifyMs.Aplication.Conta
{
    public class UsuarioService
    {
        private IMapper Mapper { get; set; }
        private UsuarioRepository UsuarioRepository { get; set; }
        private PlanoRepository PlanoRepository { get; set; }

        private AzureServiceBusService ServiceBusService { get; set; }



        public UsuarioService(IMapper mapper, UsuarioRepository usuarioRepository, PlanoRepository planoRepository, AzureServiceBusService serviceBusService)
        {
            Mapper = mapper;
            UsuarioRepository = usuarioRepository;
            PlanoRepository = planoRepository;
            ServiceBusService = serviceBusService;
        }

        public async Task<UsuarioDto> Criar(UsuarioDto dto)
        {
            if (this.UsuarioRepository.Exists(x => x.Email == dto.Email)) 
                throw new Exception("Usuario já existente na base");
            
            
            Plano plano = this.PlanoRepository.GetById(dto.PlanoId);

            if (plano == null)
                throw new Exception("Plano não existente ou não encontrado");

            Cartao cartao = this.Mapper.Map<Cartao>(dto.Cartao);

            Usuario usuario = Usuario.CriarConta(dto.Nome, dto.Email, dto.Senha, dto.DtNascimento, plano, cartao);

            //TODO: GRAVAR MA BASE DE DADOS
            this.UsuarioRepository.Save(usuario);
            var result = this.Mapper.Map<UsuarioDto>(usuario);

            //Notificar o usuário
            Notificacao notificacao = Notificacao.Criar("BEM VINDO", "Chega bem vindo você acaba de aderir os Plano: " + plano.Nome, TipoNotificacao.Sistema, usuario, null);

            await this.ServiceBusService.SendMessage(notificacao);

            return result;

        }

        public UsuarioDto Obter(Guid id)
        {
            var usuario = this.UsuarioRepository.GetById(id);
            var result = this.Mapper.Map<UsuarioDto>(usuario);
            return result;
        }

        public async Task<UsuarioDto> Autenticar(String email, String senha)
        {
            var usuario = this.UsuarioRepository.Find(x => x.Email == email && x.Senha == senha.HashSHA256()).FirstOrDefault();
            var result = this.Mapper.Map<UsuarioDto>(usuario);


            //Notificar login o usuário         
            Notificacao notificacao = Notificacao.Criar("NOVO LOGIN", $"Alerta: {usuario.Nome} acabou de fazer login as {DateTime.Now}", TipoNotificacao.Sistema, usuario, null);


            await this.ServiceBusService.SendMessage(notificacao);

            return result;
        }
    }
}
