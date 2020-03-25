using System.Linq;
using System.Collections.Generic;
using ProjAgil.Infra.Data.Context;
using ProjAgil.Dominio.Entidades;
using ProjAgil.Dominio.Interfaces.Repositorio;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjAgil.Infra.Data.Repositorio
{
    public class EventoRepositorio : RepositorioBase<Evento>, IEventoRepositorio
    {
        public EventoRepositorio(ProAgilContext proAgilContext) : base(proAgilContext) {}

        public async Task<List<Evento>> ObterEventosAsync(bool incluirPalestrates = false)
        {
            IQueryable<Evento> query = proAgilContext.Eventos
                .Include(c => c.Lotes)
                .Include(c => c.RedesSociais);

            if(incluirPalestrates)
                query.Include(c => c.PalestrantesEventos)
                    .ThenInclude(c => c.Palestrante);

            query = query
                .AsNoTracking()
                .OrderBy(c => c.Id);

            return await query.ToListAsync();
        }

        public async Task<List<Evento>> ObterEventoAsyncPorTema(string tema, bool incluirPalestrates)
        {
            IQueryable<Evento> query = proAgilContext.Eventos
                .Include(c => c.Lotes)
                .Include(c => c.RedesSociais);

            if(incluirPalestrates)
                query.Include(c => c.PalestrantesEventos)
                    .ThenInclude(c => c.Palestrante);

            query = query
                .AsNoTracking()
                .Where(c => c.Tema.ToLower().Contains(tema.ToLower()))
                .OrderByDescending(c => c.DataEvento);

            return await query.ToListAsync();
        }

        public async Task<Evento> ObterEventoAsyncPorEventoId(int eventoId, bool incluirPalestrates)
        {
            IQueryable<Evento> query = proAgilContext.Eventos
                .Include(c => c.Lotes)
                .Include(c => c.RedesSociais);

            if(incluirPalestrates)
                query.Include(c => c.PalestrantesEventos)
                    .ThenInclude(c => c.Palestrante);

            query = query
                .AsNoTracking()
                .Where(c => c.Id == eventoId)
                .OrderByDescending(c => c.DataEvento);

            return await query.FirstOrDefaultAsync();
        }
    }
}