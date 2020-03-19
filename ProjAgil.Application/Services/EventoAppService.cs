using System.Collections.Generic;
using System.Threading.Tasks;
using ProjAgil.Dominio.Entidades;
using ProjAgil.Dominio.Interfaces.Aplicacao;
using ProjAgil.Dominio.Interfaces.Repositorio;

namespace ProjAgil.Application.Services
{
    public class EventoAppService : IAppServeceBase<Evento>, IEventoAppService
    {
        private readonly IEventoRepositorio eventoRepositorio;
        public EventoAppService(IEventoRepositorio eventoRepositorio)
        {
            this.eventoRepositorio = eventoRepositorio;
        }

        public void Add(Evento entity)
        {
            eventoRepositorio.Add(entity);
        }

        public void Update(Evento entity)
        {
            eventoRepositorio.Update(entity);
        }

        public void Delete(Evento entity)
        {
            eventoRepositorio.Delete(entity);
        }

        public async Task<Evento> ObterEventoAsyncPorEventoId(int eventoId, bool incluirPalestrates)
        {
            return await eventoRepositorio.ObterEventoAsyncPorEventoId(eventoId, incluirPalestrates);
        }

        public async Task<List<Evento>> ObterEventoAsyncPorTema(string tema, bool incluirPalestrates)
        {
            return await eventoRepositorio.ObterEventoAsyncPorTema(tema, incluirPalestrates);
        }

        public async Task<List<Evento>> ObterEventosAsync(bool incluirPalestrates = false)
        {
            return await eventoRepositorio.ObterEventosAsync(incluirPalestrates);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await eventoRepositorio.SaveChangesAsync();
        }
    }
}