using ProjetoClassificados.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoClassificados.Interfaces
{
    interface IDenunciaRepository
    {
        void Cadastrar(Denuncium novaDenuncia);
        void Deletar(int id);
        Denuncium BuscarPorId(int id);
    }
}
