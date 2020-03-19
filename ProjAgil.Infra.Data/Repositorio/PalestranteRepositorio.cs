using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjAgil.Dominio.Entidades;
using ProjAgil.Dominio.Interfaces.Repositorio;
using ProjAgil.Infra.Data.Context;

namespace ProjAgil.Infra.Data.Repositorio
{
    public class PalestranteRepositorio : RepositorioBase<Palestrante>, IPalestranteRepositorio
    {
        public PalestranteRepositorio(ProAgilContext proAgilContext) : base(proAgilContext) {}

        public async Task<Palestrante> ObterPalestranteAsyncPorPalestranteId(int palestranteId, bool incluirEventos)
        {
            IQueryable<Palestrante> query = proAgilContext.Palestrantes
                .Include(c => c.RedesSociais);

            if(incluirEventos)
                query.Include(c => c.PalestrantesEventos)
                    .ThenInclude(c => c.Evento);

            query = query
                .Where(c => c.Id == palestranteId)
                .OrderBy(c => c.Nome);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<Palestrante>> ObterPaletrantesAsyncPorNome(string nome, bool incluirEventos)
        {
            IQueryable<Palestrante> query = proAgilContext.Palestrantes
                .Include(c => c.RedesSociais);

            if(incluirEventos)
                query.Include(c => c.PalestrantesEventos)
                    .ThenInclude(c => c.Evento);

            query = query
                .Where(c => c.Nome.ToLower().Contains(nome.ToLower()))
                .OrderBy(c => c.Nome);

            return await query.ToListAsync();
        }
    }
}