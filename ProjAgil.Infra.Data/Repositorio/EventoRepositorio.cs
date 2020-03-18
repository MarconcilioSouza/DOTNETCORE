using System.Collections.Generic;
using ProjAgil.Infra.Data.Context;
using ProjAgil.Model.Entidades;
using ProjAgil.Model.Interfaces.Repositorio;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjAgil.Infra.Data.Repositorio
{
    public class EventoRepositorio : IEventoRepositorio
    {
        private readonly DataContext dataContext;
        public EventoRepositorio(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<Evento> ObterByEventoId(int eventoId)
        {
            return await dataContext.Eventos.FirstOrDefaultAsync(x => x.EventoId == eventoId);
        }

        public async Task<List<Evento>> ObterTodos()
        {
            return await dataContext.Eventos.ToListAsync();
        }
    }
}