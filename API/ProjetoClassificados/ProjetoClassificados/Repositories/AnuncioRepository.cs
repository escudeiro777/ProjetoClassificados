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

        public void Atualizar(int id, Anuncio AnuncioAtualizada)
        {
            throw new NotImplementedException();
        }

        public Anuncio BuscarPorId(int id)
        {
            return ctx.Anuncios.FirstOrDefault(x => x.IdAnuncio == id);
        }

        public void Cadastrar(Anuncio novoProduto)
        {
            ctx.Anuncios.Add(novoProduto);

            ctx.SaveChanges();
        }


        public void Deletar(int id)
        {
            ctx.Anuncios.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Anuncio> Listar()
        {
            return ctx.Anuncios
           .Include(x => x.IdCorNavigation)
           .Include(x => x.IdEstadoNavigation)
           .Include(x=> x.IdModeloNavigation)
           .Include(x => x.IdSituacaoNavigation)
           .Include(x => x.IdUsuarioNavigation)
           .Select(x => new Anuncio
           {
               IdAnuncio = x.IdAnuncio,
               IdCorNavigation = x.IdCorNavigation,
               IdEstadoNavigation = x.IdEstadoNavigation,
               IdModeloNavigation = x.IdModeloNavigation,
               IdSituacaoNavigation = x.IdSituacaoNavigation,
               IdUsuarioNavigation = x.IdUsuarioNavigation
           })
           .ToList();
        }

        public List<Anuncio> ListarMinhas(int id)
        {
            throw new NotImplementedException();
        }
    }
}
