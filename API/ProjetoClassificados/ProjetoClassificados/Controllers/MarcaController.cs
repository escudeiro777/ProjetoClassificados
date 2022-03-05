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
    public class MarcaController : ControllerBase
    {
        private IMarcaRepository _marcaRepository { get; set; }

        public MarcaController()
        {
            _marcaRepository = new MarcaRepository();
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Marca novaMarca)
        {
            _marcaRepository.Cadastrar(novaMarca);

            return StatusCode(201);
        }

        [HttpGet]
        public IActionResult ListarModelo()
        {
            try
            {
                List<Marca> lista = _marcaRepository.Listar();

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
                _marcaRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception codErro)
            {
                return BadRequest(codErro);
            }
        }
    }
}
