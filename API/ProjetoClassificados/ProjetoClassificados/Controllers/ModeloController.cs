using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoClassificados.Domains;
using ProjetoClassificados.Interfaces;
using ProjetoClassificados.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoClassificados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloController : ControllerBase
    {
        private IModeloRepository _modeloRepository { get; set; }

        public ModeloController()
        {
            _modeloRepository = new ModeloRepository();
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Modelo novoModelo)
        {
            _modeloRepository.Cadastrar(novoModelo);

            return StatusCode(201);
        }

        [HttpGet]
        public IActionResult ListarModelo()
        {
            try
            {
                List<Modelo> lista = _modeloRepository.Listar();

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
                _modeloRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception codErro)
            {
                return BadRequest(codErro);
            }
        }

    }
}
