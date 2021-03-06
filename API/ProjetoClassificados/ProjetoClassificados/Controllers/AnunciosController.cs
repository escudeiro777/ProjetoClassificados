using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoClassificados.Domains;
using ProjetoClassificados.Interfaces;
using ProjetoClassificados.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoClassificados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AnunciosController : ControllerBase
    {
        private IAnuncioRepository _anuncioRepository { get; set; }

        public AnunciosController()
        {
            _anuncioRepository = new AnuncioRepository();
        }

        [HttpPost]
        public IActionResult CadastrarAnuncio(Anuncio novoAnuncio)
        {
            try
            {
                if (novoAnuncio == null)
                {
                    return BadRequest(new
                    {
                        mensagem = "Os dados estão inválidos!"
                    });
                }
                _anuncioRepository.CadastrarAnuncio(novoAnuncio);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet]
        public IActionResult ListarModelo()
        {
            try
            {
                List<Anuncio> lista = _anuncioRepository.Listar();

                return Ok(lista);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _anuncioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception codErro)
            {
                return BadRequest(codErro);
            }
        }
    }
}
