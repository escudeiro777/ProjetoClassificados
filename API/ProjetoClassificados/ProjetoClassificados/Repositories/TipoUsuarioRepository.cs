using ProjetoClassificados.Contexts;
using ProjetoClassificados.Domains;
using ProjetoClassificados.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoClassificados.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        ECS_Context ctx = new ECS_Context();
        public void Cadastrar(TipoUsuario cadastrarTipoUsario)
        {
            ctx.TipoUsuarios.Add(cadastrarTipoUsario);

            ctx.SaveChanges();
        }
    }
}
