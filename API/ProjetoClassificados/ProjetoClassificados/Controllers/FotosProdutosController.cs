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

    public class FotosProdutosController : ControllerBase
    {
        private IFotoProdutoRepository _fotoProdutoRepository { get; set; }

        public FotosProdutosController()
        {
            _fotoProdutoRepository = new FotoProdutoRepository();
        }

        [HttpPost]
        public IActionResult postarFoto(int idProduto, IFormFile arquivo)
        {
            //idProduto = 1;
            try
            {
                if (arquivo.Length > 150000) //150KB
                    return BadRequest(new { mensagem = "O arquivo deve ter no maximo 150KB." });

                string extensao = arquivo.FileName.Split(".").Last();

                if (extensao != "jpg" && extensao != "png")
                    return BadRequest(new { mensagem = "Somente arquivos .jpg e .png sao permitidos." });


                AnuncioRepository anuncioBuscado = new AnuncioRepository();

                if (anuncioBuscado.BuscarAnuncioPorId(idProduto) == null)
                    return BadRequest(new { mensagem = "O anuncio informado nao existe" });

                _fotoProdutoRepository.AdicionarFotoProduto(idProduto, arquivo);

                return Ok();
                
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
