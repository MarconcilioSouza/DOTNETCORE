using System.Collections.Generic;
using System.Threading.Tasks;
using ProjAgil.Dominio.Entidades;
using ProjAgil.Dominio.ViewModels;

namespace ProjAgil.Dominio.Interfaces.Aplicacao
{
    public interface IEventoAppService : IAppServeceBase<EventoViewModel>
    {
        Task<List<EventoViewModel>> ObterEventosAsync(bool incluirPalestrates = false);
        Task<List<EventoViewModel>> ObterEventoAsyncPorTema(string tema, bool incluirPalestrates);
        Task<EventoViewModel> ObterEventoAsyncPorEventoId(int eventoId, bool incluirPalestrates);
    }
}