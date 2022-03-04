using ProjetoClassificados.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoClassificados.Interfaces
{
    interface IDenunciaRepository
    {
        void Cadastrar(Denuncia novaDenuncia);
        void Deletar(int id);
        List<Denuncia> Listar();
        Denuncia BuscarPorId(int id);
    }
}
