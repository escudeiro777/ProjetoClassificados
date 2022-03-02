using Microsoft.AspNetCore.Http;
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
    public class FotoProdutoRepository : IFotoProdutoRepository
    {
        ECS_Context ctx = new ECS_Context();

        public void AdicionarFotoProduto(int idProduto, IFormFile fotoDoProduto)
        {
            FotoProduto novaImg = new FotoProduto();

            using (var ms = new MemoryStream())
            {
                FotoProduto n_seq = ctx.FotoProdutos.OrderBy(n => n.IdFotoProduto).Last();
                int indice = n_seq.IdFotoProduto + 1;

                fotoDoProduto.CopyTo(ms);

                novaImg.ImgBinario = ms.ToArray();
                novaImg.NomeArquivo = idProduto + "_" + indice.ToString() + "_" + fotoDoProduto.FileName;
                novaImg.MimeType = fotoDoProduto.FileName.Split('.').Last();
                novaImg.DataInclusao = DateTime.Now;
                novaImg.IdAnuncio = idProduto;
            }
            ctx.FotoProdutos.Add(novaImg);
            ctx.SaveChanges();
        }

        public List<string> CarregarFotosProduto(int idProduto)
        {
            throw new NotImplementedException();
        }
    }
}
