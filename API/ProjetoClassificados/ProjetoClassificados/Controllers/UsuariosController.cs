using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoClassificados.Domains;
using ProjetoClassificados.Interfaces;
using ProjetoClassificados.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

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

        [Authorize]
        [HttpPost("imagem")]
        public IActionResult SalvarImgUsuario(IFormFile arquivo)
        {
            try
            {
                if (arquivo.Length > 150000)
                    return BadRequest(new { mensagem = "O tamanho maximo de 150KB da imagem foi atingido." });

                string extensao = arquivo.FileName.Split('.').Last();

                if (extensao != "jpg" && extensao != "png")
                    return BadRequest(new { mensagem = "Apenas arquivos .png e .jpg sao permitidos" });

                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                _usuarioRepository.SalvarFotoDiretorio(arquivo, idUsuario);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Authorize]
        [HttpGet("imagem")]
        public IActionResult MostrarImgUsuario()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                //int idUsuario = 1;

                string base64 = _usuarioRepository.CarregarFotoDiretorio(idUsuario);

                return Ok(base64);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
