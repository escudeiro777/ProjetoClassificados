using ProjetoClassificados.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoClassificados.Interfaces
{
    interface IMarcaRepository
    {
        void Cadastrar(Marca novaMarca);
        Marca BuscarPorId(int id);
        List<Marca> Listar();
        void Deletar(int id);
    }
}
