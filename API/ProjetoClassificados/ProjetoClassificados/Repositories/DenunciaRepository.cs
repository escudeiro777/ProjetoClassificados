using ProjetoClassificados.Contexts;
using ProjetoClassificados.Domains;
using ProjetoClassificados.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoClassificados.Repositories
{
    public class DenunciaRepository : IDenunciaRepository
    {
        ECS_Context ctx = new ECS_Context();

        public Denuncium BuscarPorId(int id)
        {
            return ctx.Denuncia.FirstOrDefault(x => x.IdAnuncio == id);
        }

        public void Cadastrar(Denuncium novaDenuncia)
        {
            ctx.Denuncia.Add(novaDenuncia);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Denuncia.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }
    }
}
