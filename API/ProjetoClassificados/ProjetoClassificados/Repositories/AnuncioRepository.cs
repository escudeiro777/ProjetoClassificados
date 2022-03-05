using Microsoft.EntityFrameworkCore;
using ProjetoClassificados.Contexts;
using ProjetoClassificados.Domains;
using ProjetoClassificados.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoClassificados.Repositories
{
    public class AnuncioRepository : IAnuncioRepository
    {
        ECS_Context ctx = new ECS_Context();

        

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
    }
}
