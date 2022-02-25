using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoClassificados.Domains;
using ProjetoClassificados.Interfaces;
using ProjetoClassificados.ViewModels;
using System;
using System.Collections.Generic;

namespace ProjetoClassificados.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioRepository repo)
        {
            _usuarioRepository = repo;
        }

        [HttpGet]
        public IActionResult ListarUsuarios()
        {
            try
            {
               List<Usuario> lista = _usuarioRepository.ListarUsuario();

               return Ok(lista);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CadastrarUsuario(CadastroUsuarioViewModel novoUsuarioForm)
        {
            try
            {
                if (novoUsuarioForm == null)
                {
                    return BadRequest(new
                    {
                        mensagem = "Os dados estão inválidos!"
                    });
                }

                Usuario novoUsuario = new();

                if (novoUsuarioForm.Senha.Length < 8)
                {
                    return BadRequest(new
                    {
                        mensagem = "A senha precisa ter mais de 8 caracteres"
                    });
                }
                novoUsuario.Email = novoUsuarioForm.Email;
                novoUsuario.Senha = novoUsuarioForm.Senha;
                novoUsuario.Nome = novoUsuarioForm.Nome;

                _usuarioRepository.CadastrarUsuario(novoUsuario);
                return StatusCode(201, novoUsuario);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
