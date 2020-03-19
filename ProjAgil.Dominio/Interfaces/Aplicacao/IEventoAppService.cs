using System.Collections.Generic;
using System.Threading.Tasks;
using ProjAgil.Model.Entidades;

namespace ProjAgil.Model.Interfaces.Aplicacao
{
    public interface IEventoAppService
    {
         Task<List<Evento>> ObterTodos();
         Task<Evento> ObterByEventoId(int eventoId);
    }
}