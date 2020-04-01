using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ProjAgil.Dominio.Entidades;
using ProjAgil.Dominio.Interfaces.Aplicacao;
using ProjAgil.Dominio.Interfaces.Repositorio;
using ProjAgil.Dominio.ViewModels;

namespace ProjAgil.Application.Services
{
    public class EventoAppService : IEventoAppService
    {
        private readonly IEventoRepositorio eventoRepositorio;
        private readonly IMapper mapper;

        public EventoAppService(IEventoRepositorio eventoRepositorio, IMapper mapper)
        {
            this.eventoRepositorio = eventoRepositorio;
            this.mapper = mapper;
        }

        public EventoViewModel Add(EventoViewModel entity)
        {
            var evento = mapper.Map<Evento>(entity);
            eventoRepositorio.Add(evento);
            return mapper.Map<EventoViewModel>(evento);
        }

        public EventoViewModel Update(EventoViewModel entity)
        {
            var evento = mapper.Map<Evento>(entity);
            eventoRepositorio.Update(evento);
            return mapper.Map<EventoViewModel>(evento);
        }

        public void Delete(EventoViewModel entity)
        {
            var evento = mapper.Map<Evento>(entity);
            eventoRepositorio.Delete(evento);
        }

        public async Task<EventoViewModel> ObterEventoAsyncPorEventoId(int eventoId, bool incluirPalestrates)
        {
            var evento = await eventoRepositorio.ObterEventoAsyncPorEventoId(eventoId, incluirPalestrates);
            return mapper.Map<EventoViewModel>(evento);
        }

        public async Task<List<EventoViewModel>> ObterEventoAsyncPorTema(string tema, bool incluirPalestrates)
        {
            var eventos = await eventoRepositorio.ObterEventoAsyncPorTema(tema, incluirPalestrates);
            return mapper.Map<List<EventoViewModel>>(eventos);
        }

        public async Task<List<EventoViewModel>> ObterEventosAsync(bool incluirPalestrates = false)
        {
            var eventos = await eventoRepositorio.ObterEventosAsync(incluirPalestrates);
            return mapper.Map<List<EventoViewModel>>(eventos);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await eventoRepositorio.SaveChangesAsync();
        }

        public void DeleteLotes(IEnumerable<LoteViewModel> lotes)
        {
            eventoRepositorio.DeleteLotes(mapper.Map<List<Lote>>(lotes));
        }

        public void DeleteRedesSociais(IEnumerable<RedeSocialViewModel> redesSociais)
        {
            eventoRepositorio.DeleteRedesSociais(mapper.Map<List<RedeSocial>>(redesSociais));
        }
    }
}