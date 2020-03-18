using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjAgil.Model.Entidades;
using ProjAgil.Infra.Data;
using ProjAgil.Model.Interfaces.Aplicacao;
using Microsoft.AspNetCore.Http;

namespace ProjAgil.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IEventoAppService eventoAppService;
        public ValuesController(IEventoAppService eventoAppService)
        {
            this.eventoAppService = eventoAppService;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evento>>> Get()
        {
            try
            {
                var results = await eventoAppService.ObterTodos();
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou!");
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task< ActionResult<Evento>> Get(int id)
        {
            try
            {
                var result = await eventoAppService.ObterByEventoId(id);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou!");
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
