using System.Collections.Generic;
using System.Threading.Tasks;
using ProjAgil.Dominio.Entidades;
using ProjAgil.Dominio.Interfaces.Aplicacao;
using ProjAgil.Dominio.Interfaces.Repositorio;

namespace ProjAgil.Application.Services
{
    public class PalestranteAppServece : IAppServeceBase<Palestrante>, IPalestranteAppServece
    {
         private readonly IPalestranteRepositorio palestranteRepositorio;
        public PalestranteAppServece(IPalestranteRepositorio palestranteRepositorio)
        {
            this.palestranteRepositorio = palestranteRepositorio;
        }

        public void Add(Palestrante entity)
        {
            palestranteRepositorio.Add(entity);
        }

        public void Update(Palestrante entity)
        {
            palestranteRepositorio.Update(entity);
        }

        public void Delete(Palestrante entity)
        {
            palestranteRepositorio.Delete(entity);
        }

        public async Task<Palestrante> ObterPalestranteAsyncPorPalestranteId(int palestranteId, bool incluirEventos)
        {
            return await palestranteRepositorio.ObterPalestranteAsyncPorPalestranteId(palestranteId, incluirEventos);
        }

        public async Task<List<Palestrante>> ObterPaletrantesAsyncPorNome(string nome, bool incluirEventos)
        {
            return await palestranteRepositorio.ObterPaletrantesAsyncPorNome(nome, incluirEventos);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await palestranteRepositorio.SaveChangesAsync();
        }
    }
}