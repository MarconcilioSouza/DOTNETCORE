using System.Collections.Generic;
using System.Threading.Tasks;
using ProjAgil.Model.Entidades;
using ProjAgil.Model.Interfaces.Aplicacao;
using ProjAgil.Model.Interfaces.Repositorio;

namespace ProjAgil.Application.Services
{
    public class EventoAppService : IEventoAppService
    {
        private readonly IEventoRepositorio eventoRepositorio;
        public EventoAppService(IEventoRepositorio eventoRepositorio)
        {
            this.eventoRepositorio = eventoRepositorio;
        }

        public async Task<Evento> ObterByEventoId(int eventoId)
        {
            return await eventoRepositorio.ObterByEventoId(eventoId);
        }

        public async Task<List<Evento>> ObterTodos()
        {
            return await eventoRepositorio.ObterTodos();
        }
    }
}