using ProjetoClassificados.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoClassificados.Interfaces
{
    interface IProdutoRepository
    {
        void Cadastrar( Produto novoProduto);
        List<Produto> ListarMinhas(int id);
        List<Produto> Listar();
        void Atualizar(int id, Produto produtoAtualizada);
        void Deletar(int id);
        Produto BuscarPorId(int id);
    }
}
