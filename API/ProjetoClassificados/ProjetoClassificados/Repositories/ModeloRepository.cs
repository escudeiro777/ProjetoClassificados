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
    public class ModeloRepository : IModeloRepository
    {
        ECS_Context ctx = new ECS_Context();
        public Modelo BuscarPorId(int id)
        {
            return ctx.Modelos.FirstOrDefault(x => x.IdModelo == id);
        }

        public void Cadastrar(Modelo novoModelo)
        {
            ctx.Modelos.Add(novoModelo);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Modelos.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Modelo> Listar()
        {
            return ctx.Modelos
           .Include(x => x.IdMarcaNavigation) 
           .Select(x => new Modelo
           {
               IdModelo = x.IdModelo,
               IdMarcaNavigation = x.IdMarcaNavigation,
               NomeMarca = x.NomeMarca, //NomeModelo / Foi escrito errado!
           })
           .ToList();
        }
    }
}
