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
    public class MarcaRepository : IMarcaRepository
    {
        ECS_Context ctx = new ECS_Context();

        public Marca BuscarPorId(int id)
        {
            return ctx.Marcas.FirstOrDefault(x => x.IdMarca == id);
        }

        public void Cadastrar(Marca novaMarca)
        {
            ctx.Marcas.Add(novaMarca);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Marcas.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Marca> Listar()
        {
            return ctx.Marcas
          .Select(x => new Marca
          {
              IdMarca = x.IdMarca,
              NomeMarca = x.NomeMarca, //NomeModelo / Foi escrito errado! //Atualizado
           })
          .ToList();
        }
    }
}
