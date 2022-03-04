using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoClassificados.Interfaces
{
    public interface IFotoProdutoRepository
    {
        void AdicionarFotoProduto(int idProduto, IFormFile fotoDoProduto);

        List<string> CarregarFotosProduto(int idProduto);

    }
}
