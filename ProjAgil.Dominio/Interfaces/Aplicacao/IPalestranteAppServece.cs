using System.Collections.Generic;
using System.Threading.Tasks;
using ProjAgil.Dominio.Entidades;

namespace ProjAgil.Dominio.Interfaces.Aplicacao
{
    public interface IPalestranteAppServece
    {
         Task<Palestrante> ObterPalestranteAsyncPorPalestranteId(int palestranteId, bool incluirEventos);
         Task<List<Palestrante>> ObterPaletrantesAsyncPorNome(string nome, bool incluirEventos);  
    }
}