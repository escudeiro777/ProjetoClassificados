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
        private readonly string path = "StaticFiles\\Fotos_Usuarios";

        ECS_Context ctx = new();
        public void CadastrarUsuario(Usuario novoUsuario)
        {
            string senhaHash = Criptografia.gerarHash(novoUsuario.Senha);
            novoUsuario.Senha = senhaHash;
            novoUsuario.IdTipoUsuario = 1;
            novoUsuario.CaminhoImagemUsuario = Directory.GetCurrentDirectory() + "\\" + path + "\\" + "imgPadrao.png";
            ctx.Usuarios.Add(novoUsuario);
            ctx.SaveChanges();
        }

        public Usuario Login(string email, string senha)
        {
            Usuario usuario = ctx.Usuarios.FirstOrDefault(u => u.Email == email);


            if (usuario != null)
            {

                if (usuario.Senha == senha)
                {


                    string senhaHash = Criptografia.gerarHash(usuario.Senha);
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

            string nomeArquivo = infos.IdUsuario.ToString() + "_" + infos.Nome + "." + fotoUsuario.FileName.Split('.').Last();

            infos.CaminhoImagemUsuario = Directory.GetCurrentDirectory() + "\\" + path + "\\" + nomeArquivo;

            this.AtualizarUsuario(infos);

            using (var stream = new FileStream(Path.Combine(path, nomeArquivo), FileMode.Create))
            {
                fotoUsuario.CopyTo(stream);
            }
        }

        public string CarregarFotoDiretorio(int idUsuario)
        {
            Usuario infos = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

            byte[] foto_em_bytes = File.ReadAllBytes(infos.CaminhoImagemUsuario);

            return Convert.ToBase64String(foto_em_bytes);
        }

       
    }
}
