using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjAgil.Model.Entidades;
using ProjAgil.Infra.Data;

namespace ProjAgil.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext dataContext;
        public ValuesController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Evento>> Get()
        {
            return dataContext.Eventos.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Evento> Get(int id)
        {
            return new Evento[] {
                new Evento() {
                    EventoId = 1,
                    Tema = "Angular e .net core",
                    Local = "São Paulo",
                    Lote = "1º lote",
                    QtdPessoas = 22,
                    DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                },
                new Evento() {
                    EventoId = 2,
                    Tema = "Angular e suas novidades",
                    Local = "São Bernado",
                    Lote = "2º lote",
                    QtdPessoas = 22,
                    DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy"),
                }
             }.FirstOrDefault(x => x.EventoId == id);
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
