using ProjetoClassificados.Domains;
using System.Collections.Generic;

namespace ProjetoClassificados.Interfaces
{
    public interface IUsuarioRepository
    {
        void CadastrarUsuario(Usuario novoUsuario);
        Usuario Login(string email, string senha);
        List<Usuario> ListarUsuario();
    }
}
