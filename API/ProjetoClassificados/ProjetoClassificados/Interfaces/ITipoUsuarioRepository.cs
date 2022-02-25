using ProjetoClassificados.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoClassificados.Interfaces
{
    interface ITipoUsuarioRepository
    {
        void Cadastrar(TipoUsuario cadastrarTipoUsario);
    }
}
