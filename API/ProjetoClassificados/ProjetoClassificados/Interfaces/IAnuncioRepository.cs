using ProjetoClassificados.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoClassificados.Interfaces
{
    interface IAnuncioRepository
    {
        void Cadastrar(Anuncio novoAnuncio);
        List<Anuncio> ListarMinhas(int id);
        List<Anuncio> Listar();
        void Atualizar(int id, Anuncio AnuncioAtualizada);
        void Deletar(int id);
        Anuncio BuscarPorId(int id);
    }
}
