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
    }
}
