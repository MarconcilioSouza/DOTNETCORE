using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ProjAgil.Dominio.Entidades;
using ProjAgil.Dominio.Interfaces.Aplicacao;
using ProjAgil.Dominio.Interfaces.Repositorio;
using ProjAgil.Dominio.ViewModels;

namespace ProjAgil.Application.Services
{
    public class PalestranteAppServece : IPalestranteAppServece
    {
         private readonly IPalestranteRepositorio palestranteRepositorio;
        private readonly IMapper mapper;

        public PalestranteAppServece(IPalestranteRepositorio palestranteRepositorio, IMapper mapper)
        {
            this.palestranteRepositorio = palestranteRepositorio;
            this.mapper = mapper;
        }

        public void Add(PalestranteViewModel entity)
        {
            var palestrante = mapper.Map<Palestrante>(entity);
            palestranteRepositorio.Add(palestrante);
        }

        public void Update(PalestranteViewModel entity)
        {
            var palestrante = mapper.Map<Palestrante>(entity);
            palestranteRepositorio.Update(palestrante);
        }

        public void Delete(PalestranteViewModel entity)
        {
            var palestrante = mapper.Map<Palestrante>(entity);
            palestranteRepositorio.Delete(palestrante);
        }

        public async Task<PalestranteViewModel> ObterPalestranteAsyncPorPalestranteId(int palestranteId, bool incluirEventos)
        {
            var palestrante = await palestranteRepositorio.ObterPalestranteAsyncPorPalestranteId(palestranteId, incluirEventos);
            return mapper.Map<PalestranteViewModel>(palestrante);
        }

        public async Task<List<PalestranteViewModel>> ObterPaletrantesAsyncPorNome(string nome, bool incluirEventos)
        {
            var palestrantes= await palestranteRepositorio.ObterPaletrantesAsyncPorNome(nome, incluirEventos);
            return mapper.Map<List<PalestranteViewModel>>(palestrantes);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await palestranteRepositorio.SaveChangesAsync();
        }
    }
}