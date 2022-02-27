using ProjetoClassificados.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoClassificados.Interfaces
{
    interface ISituacaoRepository
    {
        void Cadastrar(Situacao novaSituacao);
        Situacao BuscarPorId(int id);
        List<Situacao> Listar();
        void Deletar(int id);
    }
}
