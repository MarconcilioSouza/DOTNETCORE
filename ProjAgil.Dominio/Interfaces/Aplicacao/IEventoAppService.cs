using System.Collections.Generic;
using System.Threading.Tasks;
using ProjAgil.Dominio.Entidades;

namespace ProjAgil.Dominio.Interfaces.Aplicacao
{
    public interface IEventoAppService
    {
        Task<List<Evento>> ObterEventosAsync(bool incluirPalestrates = false);
        Task<List<Evento>> ObterEventoAsyncPorTema(string tema, bool incluirPalestrates);
        Task<Evento> ObterEventoAsyncPorEventoId(int eventoId, bool incluirPalestrates);
    }
}