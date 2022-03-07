using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ProjetoClassificados.Contexts;
using ProjetoClassificados.Domains;
using ProjetoClassificados.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoClassificados.Repositories
{
    public class AnuncioRepository : IAnuncioRepository
    {
        ECS_Context ctx = new ECS_Context();
        private readonly string path = "StaticFiles\\Fotos_Produtos";


        public Anuncio BuscarAnuncioPorId(int idAnuncio)
        {
            return ctx.Anuncios.FirstOrDefault(a => a.IdAnuncio == idAnuncio);
        }



        public void CadastrarAnuncio(Anuncio novoAnuncio)
        {
            ctx.Anuncios.Add(novoAnuncio);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Anuncios.Remove(BuscarAnuncioPorId(id));

            ctx.SaveChanges();
        }

        public List<Anuncio> Listar()
        {
            return ctx.Anuncios
           .Include(x => x.IdUsuarioNavigation)
           .Include(x => x.IdSituacaoNavigation)
           .Include(x => x.IdModeloNavigation)
           .Include(x => x.IdCorNavigation)
           .Include(x => x.IdEstadoNavigation)
           .Select(x => new Anuncio
           {
               IdAnuncio = x.IdAnuncio,
               IdUsuarioNavigation = x.IdUsuarioNavigation,
               IdSituacaoNavigation = x.IdSituacaoNavigation,
               IdModeloNavigation = x.IdModeloNavigation,
               IdCorNavigation = x.IdCorNavigation,
               IdEstadoNavigation = x.IdEstadoNavigation,
               TituloAnuncio = x.TituloAnuncio,
               Descricao = x.Descricao,
               DataAnuncio = x.DataAnuncio,
               AnoVeiculo = x.AnoVeiculo,
               Km = x.Km,
               Cidade = x.Cidade,
               Preco = x.Preco,
               Troca = x.Troca
           })
           .ToList();
        }
        public void AtualizarAnuncio(Anuncio anuncioAtualizado)
        {
            Anuncio anuncioBuscado = ctx.Anuncios.Find(anuncioAtualizado.IdUsuario);

            if (anuncioBuscado != null)
            {
                anuncioBuscado.IdUsuario = anuncioAtualizado.IdUsuario;
                anuncioBuscado.IdSituacao = anuncioAtualizado.IdSituacao;
                anuncioBuscado.IdModelo = anuncioAtualizado.IdModelo;
                anuncioBuscado.IdCor = anuncioAtualizado.IdCor;
                anuncioBuscado.IdEstado = anuncioAtualizado.IdEstado;
                anuncioBuscado.TituloAnuncio = anuncioAtualizado.TituloAnuncio;
                anuncioBuscado.Descricao = anuncioAtualizado.Descricao;
                anuncioBuscado.DataAnuncio = anuncioAtualizado.DataAnuncio;
                anuncioBuscado.AnoVeiculo = anuncioAtualizado.AnoVeiculo;
                anuncioBuscado.Km = anuncioAtualizado.Km;
                anuncioBuscado.Cidade = anuncioAtualizado.Cidade;
                anuncioBuscado.Preco = anuncioAtualizado.Preco;
                anuncioBuscado.Troca = anuncioAtualizado.Troca;
                anuncioBuscado.CaminhoImagemAnuncio = anuncioAtualizado.CaminhoImagemAnuncio;

                ctx.Anuncios.Update(anuncioBuscado);
                ctx.SaveChanges();
            }
        }

        public void SalvarFotoAnuncio(IFormFile fotoAnuncio, int idAnuncio)
        {
            Anuncio infos = ctx.Anuncios.FirstOrDefault(u => u.IdAnuncio == idAnuncio);

            string nomeArquivo = infos.IdAnuncio.ToString() + ".png";

            infos.CaminhoImagemAnuncio = Directory.GetCurrentDirectory() + "\\" + path + "\\" + nomeArquivo;

            this.AtualizarAnuncio(infos);

            using (var stream = new FileStream(Path.Combine(path, nomeArquivo), FileMode.Create))
            {
                fotoAnuncio.CopyTo(stream);
            }

        }

        public string CarregarFotoDiretorio(int idUsuario)
        {
            Anuncio infos = ctx.Anuncios.FirstOrDefault(u => u.IdUsuario == idUsuario);

            byte[] foto_em_bytes = File.ReadAllBytes(infos.CaminhoImagemAnuncio);

            return Convert.ToBase64String(foto_em_bytes);
        }
    }
}
