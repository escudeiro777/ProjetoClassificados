using ProjetoClassificados.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoClassificados.Interfaces
{
    interface IModeloRepository
    {
        void Cadastrar(Modelo novoModelo);
        List<Modelo> Listar();
        void Deletar(int id);
        Modelo BuscarPorId(int id);
    }
}
