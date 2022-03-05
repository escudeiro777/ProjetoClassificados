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
    public class DenunciaController : ControllerBase
    {
        private IDenunciaRepository _denunciaRepository { get; set; }

        public DenunciaController()
        {
            _denunciaRepository = new DenunciaRepository();
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Denuncia novaDenuncia)
        {
            _denunciaRepository.Cadastrar(novaDenuncia);

            return StatusCode(201);
        }

        [HttpGet]
        public IActionResult ListarModelo()
        {
            try
            {
                List<Denuncia> lista = _denunciaRepository.Listar();

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
                _denunciaRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception codErro)
            {
                return BadRequest(codErro);
            }
        }
    }
}
