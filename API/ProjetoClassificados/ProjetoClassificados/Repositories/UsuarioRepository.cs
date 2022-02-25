using ProjetoClassificados.Contexts;
using ProjetoClassificados.Domains;
using ProjetoClassificados.Interfaces;
using ProjetoClassificados.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoClassificados.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        ECS_Context ctx = new();
        public void CadastrarUsuario(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);
            ctx.SaveChanges();
        }

        public List<Usuario> ListarUsuario()
        {
            return ctx.Usuarios.Select(u => new Usuario
            {
                Nome = u.Nome,
                Email = u.Email,
                Senha = u.Senha,
                NotaComprador = u.NotaComprador,
                NotaVendedor = u.NotaVendedor

            }).ToList();
        }

        public Usuario Login(string email, string senha)
        {
            Usuario usuario = ctx.Usuarios.FirstOrDefault(u => u.Email == email);

            if (usuario != null)
            {
                if (usuario.Senha.Length != 60 && usuario.Senha[0].ToString() != "$")
                {
                    string senhaHash = Criptografia.gerarHash(senha);
                    usuario.Senha = senhaHash;
                    ctx.Usuarios.Update(usuario);
                    ctx.SaveChanges();
                    return usuario;
                }
                bool confere = Criptografia.compararSenha(senha, usuario.Senha);
                if (confere)
                {
                    return usuario;
                }
            }
            return null;
        }
    }
}
