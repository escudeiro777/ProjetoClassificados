using Microsoft.AspNetCore.Http;
using ProjetoClassificados.Contexts;
using ProjetoClassificados.Domains;
using ProjetoClassificados.Interfaces;
using ProjetoClassificados.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjetoClassificados.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        ECS_Context ctx = new();
        public void CadastrarUsuario(Usuario novoUsuario)
        {
            string senhaHash = Criptografia.gerarHash(novoUsuario.Senha);
            novoUsuario.Senha = senhaHash;
            ctx.Usuarios.Add(novoUsuario);
            ctx.SaveChanges();
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


        public Usuario BuscarPorId(int idUsuarioBuscado)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuarioBuscado);
        }

        public List<Usuario> ListarUsuario()
        {
            return ctx.Usuarios.Select(u => new Usuario
            {
                Nome = u.Nome,
                Email = u.Email,
                Senha = u.Senha,
                NotaComprador = u.NotaComprador,
                NotaVendedor = u.NotaVendedor,
                CaminhoImagemUsuario = u.CaminhoImagemUsuario

            }).ToList();
        }

        public void AtualizarUsuario(Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(usuarioAtualizado.IdUsuario);

            if (usuarioBuscado != null)
            {
                usuarioBuscado.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;
                usuarioBuscado.Nome = usuarioAtualizado.Nome;
                usuarioBuscado.Email = usuarioAtualizado.Email;
                usuarioBuscado.Senha = usuarioAtualizado.Senha;
                usuarioBuscado.NotaVendedor = usuarioAtualizado.NotaVendedor;
                usuarioBuscado.NotaComprador = usuarioAtualizado.NotaComprador;
                usuarioBuscado.CaminhoImagemUsuario = usuarioAtualizado.CaminhoImagemUsuario;

                ctx.Usuarios.Update(usuarioBuscado);
                ctx.SaveChanges();
            }
        }

        public void DeletarUsuario(int idUsuario)
        {
            ctx.Usuarios.Remove(BuscarPorId(idUsuario));
            ctx.SaveChanges();
        }

        public void SalvarFotoDiretorio(IFormFile fotoUsuario, int idUsuario)
        {
            Usuario infos = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

            string nomeArquivo = infos.IdUsuario.ToString() + "_" + infos.Nome + "_" + fotoUsuario.FileName.Split('.').Last();
            
            infos.CaminhoImagemUsuario = nomeArquivo;

            this.AtualizarUsuario(infos);

            using (var stream = new FileStream(Path.Combine("StaticFiles\\Fotos_Usuarios", nomeArquivo), FileMode.Create))
            {
                fotoUsuario.CopyTo(stream);
            }
        }

        public string CarregarFotoDiretorio(int idUsuario)
        {
            throw new NotImplementedException();
        }

       
    }
}
