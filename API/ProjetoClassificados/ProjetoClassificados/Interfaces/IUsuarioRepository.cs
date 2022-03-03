using ProjetoClassificados.Domains;

namespace ProjetoClassificados.Interfaces
{
    public interface IUsuarioRepository
    {
        void CadastrarUsuario(Usuario novoUsuario);
        Usuario Login(string email, string senha);
    }
}
