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
    [Produces("application/json")]

    [Route("api/[controller]")]
    //http://localhost:5000/api/tiposUsuarios

    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipousuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            _tipousuarioRepository = new TipoUsuarioRepository();
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(TipoUsuario novoTipo)
        {
            _tipousuarioRepository.Cadastrar(novoTipo);

            return StatusCode(201);
        }

    }
}
