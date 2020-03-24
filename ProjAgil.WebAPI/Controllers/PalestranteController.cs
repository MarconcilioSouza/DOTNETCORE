using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjAgil.Dominio.Entidades;
using ProjAgil.Dominio.Interfaces.Aplicacao;
using ProjAgil.Dominio.ViewModels;

namespace ProjAgil.WebAPI.Controllers
{
    /// <summary>
    /// Controller de palestrantes
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PalestranteController : ControllerBase
    {
        private readonly IPalestranteAppServece palestranteAppServece;

        /// <summary>
        /// Contrutor de palestrantes
        /// </summary>
        /// <param name="palestranteAppServece"></param>
        public PalestranteController(IPalestranteAppServece palestranteAppServece)
        {
            this.palestranteAppServece = palestranteAppServece;
        }

        /// <summary>
        ///  GET: api/Palestrante
        /// </summary>
        /// <param name="palestranteId"></param>
        /// <returns></returns>
        [HttpGet("{palestranteId}")]
        public async Task<IActionResult> Get(int palestranteId)
        {
            try
            {
                var result = await palestranteAppServece.ObterPalestranteAsyncPorPalestranteId(palestranteId, true);
                return Ok(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou!");
            }
        }

        /// <summary>
        /// GET: api/Palestrante/nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet("getPorNome/{nome}")]
        public async Task<IActionResult> Get(string nome)
        {
            try
            {
                var result = await palestranteAppServece.ObterPaletrantesAsyncPorNome(nome, true);
                return Ok(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou!");
            }
        }

        /// <summary>
        /// POST: api/Palestrante
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PalestranteViewModel model)
        {
            try
            {
                palestranteAppServece.Add(model);
                if(await palestranteAppServece.SaveChangesAsync())
                {
                    return Created($"/api/palestrante/{model.Id}", model);
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco de Dados");
            }
            return BadRequest();
        }

        /// <summary>
        /// PUT: api/Palestrante/5
        /// </summary>
        /// <param name="palestranteId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{palestranteId}")]
        public async Task<IActionResult> Put(int palestranteId, [FromBody] PalestranteViewModel model)
        {
            try
            {
                var result = palestranteAppServece.ObterPalestranteAsyncPorPalestranteId(palestranteId, false);
                if (result == null)
                    return NotFound();

                palestranteAppServece.Update(model);
                if (await palestranteAppServece.SaveChangesAsync())
                {
                    return Created($"/api/palestrante/{model.Id}", model);
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no banco de dados");
            }
            return BadRequest();
        }

        /// <summary>
        /// DELETE: api/ApiWithActions/5
        /// </summary>
        /// <param name="palestranteId"></param>
        /// <returns></returns>
        [HttpDelete("{palestranteId}")]
        public async Task<IActionResult> Delete(int palestranteId)
        {
            try
            {
                var result = palestranteAppServece.ObterPalestranteAsyncPorPalestranteId(palestranteId, false);
                if (result == null)
                    return NotFound();

                palestranteAppServece.Delete(result.Result);
                if (await palestranteAppServece.SaveChangesAsync())
                    return Ok();
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no banco de dados");
            }
            return BadRequest();
        }
    }
}
