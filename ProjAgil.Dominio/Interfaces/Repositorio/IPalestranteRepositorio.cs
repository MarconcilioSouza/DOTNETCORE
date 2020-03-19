using System.Collections.Generic;
using System.Threading.Tasks;
using ProjAgil.Dominio.Entidades;

namespace ProjAgil.Dominio.Interfaces.Repositorio
{
    public interface IPalestranteRepositorio : IRepositorioBase<Palestrante>
    {
         Task<Palestrante> ObterPalestranteAsyncPorPalestranteId(int palestranteId, bool incluirEventos);
         Task<List<Palestrante>> ObterPaletrantesAsyncPorNome(string nome, bool incluirEventos);
    }
}