using Microsoft.AspNetCore.Http;
using ProjetoClassificados.Domains;
using System.Collections.Generic;

namespace ProjetoClassificados.Interfaces
{
    public interface IUsuarioRepository
    {
        void CadastrarUsuario(Usuario novoUsuario);

        List<Usuario> ListarUsuario();

        void AtualizarUsuario(Usuario usuarioAtualizado);

        Usuario BuscarPorId(int idUsuarioBuscado);

        void DeletarUsuario(int idUsuario);

        void SalvarFotoDiretorio(IFormFile fotoUsuario, int idUsuario);

        string CarregarFotoDiretorio(int idUsuario);



        Usuario Login(string email, string senha);

    }
}
