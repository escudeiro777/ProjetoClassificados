using ProjetoClassificados.Contexts;
using ProjetoClassificados.Domains;
using ProjetoClassificados.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoClassificados.Repositories
{
    public class SituacaoRepository : ISituacaoRepository
    {
        ECS_Context ctx = new ECS_Context();

        public Situacao BuscarPorId(int id)
        {
            return ctx.Situacaos.FirstOrDefault(x => x.IdSituacao == id);
        }

        public void Cadastrar(Situacao novaSituacao)
        {
            ctx.Situacaos.Add(novaSituacao);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Situacaos.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Situacao> Listar()
        {
            throw new NotImplementedException();
            //Arrumando banco de Dados..... Ainda não é possivel fazer este 
        }
    }
}
