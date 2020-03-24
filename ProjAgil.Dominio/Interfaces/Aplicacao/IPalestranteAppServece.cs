using System.Collections.Generic;
using System.Threading.Tasks;
using ProjAgil.Dominio.ViewModels;

namespace ProjAgil.Dominio.Interfaces.Aplicacao
{
    public interface IPalestranteAppServece : IAppServeceBase<PalestranteViewModel>
    {
         Task<PalestranteViewModel> ObterPalestranteAsyncPorPalestranteId(int palestranteId, bool incluirEventos);
         Task<List<PalestranteViewModel>> ObterPaletrantesAsyncPorNome(string nome, bool incluirEventos);  
    }
}