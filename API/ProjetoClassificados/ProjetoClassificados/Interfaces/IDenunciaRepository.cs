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
        Denuncia BuscarPorId(int id);
    }
}
