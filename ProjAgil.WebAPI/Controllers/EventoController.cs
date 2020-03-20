using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjAgil.Dominio.Entidades;
using ProjAgil.Dominio.Interfaces.Aplicacao;
using Microsoft.AspNetCore.Http;

namespace ProjAgil.WebAPI.Controllers
{
    /// <summary>
    /// Controller de Eventos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoAppService eventoAppService;
        /// <summary>
        /// Contrutor Evento
        /// </summary>
        /// <param name="eventoAppService"></param>
        public EventoController(IEventoAppService eventoAppService)
        {
            this.eventoAppService = eventoAppService;
        }

        /// <summary>
        /// Retorna todos os eventos
        /// </summary>
        /// <returns></returns>
        // GET api/Evento
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var results = await eventoAppService.ObterEventosAsync();
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou!");
            }
        }

        /// <summary>
        /// Retorna o evento pelo id do evento
        /// </summary>
        /// <param name="eventoId"></param>
        /// <returns></returns>
        // GET api/Evento/5
        [HttpGet("{eventoId}")]
        public async Task<ActionResult> Get(int eventoId)
        {
            try
            {
                var result = await eventoAppService.ObterEventoAsyncPorEventoId(eventoId, true);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou!");
            }
        }

        /// <summary>
        /// Retorna o evento pelo nome do tema
        /// </summary>
        /// <param name="tema"></param>
        /// <returns></returns>
        // GET api/Evento/getByTema/Tema
        [HttpGet("getByTema/{tema}")]
        public async Task<ActionResult> Get(string tema)
        {
            try
            {
                var result = await eventoAppService.ObterEventoAsyncPorTema(tema, true);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou!");
            }
        }

        /// <summary>
        /// Adicionar um evento
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        // POST api/Evento
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Evento model)
        {
            try
            {
                eventoAppService.Add(model);
                if(await eventoAppService.SaveChangesAsync())
                {
                    return Created($"/api/evento/{model.Id}", model);
                }

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou!");
            }
            return BadRequest();
        }

        /// <summary>
        /// Faz a atualização do evento
        /// </summary>
        /// <param name="eventoId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        // PUT api/Evento
        [HttpPut]
        public async Task<IActionResult> Put(int eventoId, [FromBody] Evento model)
        {
            try
            {
                var evento = await eventoAppService.ObterEventoAsyncPorEventoId(eventoId, false);
                if(evento == null)
                    return NotFound();

                eventoAppService.Update(model);
                if(await eventoAppService.SaveChangesAsync())
                {
                    return Created($"/api/evento/{model.Id}", model);
                }

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou!");
            }
            return BadRequest();
        }

        /// <summary>
        /// Delete um evento
        /// </summary>
        /// <param name="eventoId"></param>
        /// <returns></returns>
        // DELETE api/Evento/5
        [HttpDelete("{eventoId}")]
        public async Task<IActionResult> Delete(int eventoId)
        {
            try
            {
                var evento = await eventoAppService.ObterEventoAsyncPorEventoId(eventoId, false);
                if(evento == null)
                    return NotFound();

                eventoAppService.Delete(evento);
                if(await eventoAppService.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou!");
            }
            return BadRequest();
        }
    }
}