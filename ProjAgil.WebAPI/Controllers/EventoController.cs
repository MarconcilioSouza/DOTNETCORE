using System.Security.AccessControl;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjAgil.Dominio.Entidades;
using ProjAgil.Dominio.Interfaces.Aplicacao;
using Microsoft.AspNetCore.Http;
using ProjAgil.Dominio.ViewModels;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ProjAgil.WebAPI.Controllers
{
    /// <summary>
    /// Controller de Eventos
    /// [ApiController] é do decorador da classe, isso faz é a nova forma de fazer as
    /// validações como o FromBody e o ModelState.IsValid.
    /// Já faz a validação dos data anotation
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
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou {ex.Message}");
            }
        }

        /// <summary>
        /// Post de imagens
        /// </summary>
        /// <returns></returns>
        [HttpPost("upload")]
        public async Task<IActionResult> Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName;
                    var fullPath = Path.Combine(pathToSave, filename.Replace("\"", " ").Trim());

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                return Ok();
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }

            return BadRequest("Erro ao tentar realizar upload");
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
        public async Task<IActionResult> Post([FromBody] EventoViewModel model)
        {
            try
            {
                var evento = eventoAppService.Add(model);
                if (await eventoAppService.SaveChangesAsync())
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
        [HttpPut("{eventoId}")]
        public async Task<IActionResult> Put(int eventoId, [FromBody] EventoViewModel model)
        {
            try
            {
                var idLotes = new List<int>();
                var idRedesSociais = new List<int>();

                idLotes.AddRange(model.Lotes.Select(x => x.Id));
                idRedesSociais.AddRange(model.RedesSociais.Select(x => x.Id));

                var evento = await eventoAppService.ObterEventoAsyncPorEventoId(eventoId, false);
                if (evento == null)
                    return NotFound();

                var lotes = evento.Lotes.Where(x => !idLotes.Contains(x.Id));
                var redesSociais = evento.RedesSociais.Where(x => !idRedesSociais.Contains(x.Id));

                if (lotes.Any())
                {
                    eventoAppService.DeleteLotes(lotes);
                }

                if (redesSociais.Any())
                {
                    eventoAppService.DeleteRedesSociais(redesSociais);
                }

                evento = eventoAppService.Update(model);
                if (await eventoAppService.SaveChangesAsync())
                {
                    return Created($"/api/evento/{evento.Id}", evento);
                }

            }
            catch (System.Exception ex)
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
                if (evento == null)
                    return NotFound();

                eventoAppService.Delete(evento);
                if (await eventoAppService.SaveChangesAsync())
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