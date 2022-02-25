using System;
using System.Collections.Generic;

#nullable disable

namespace ProjetoClassificados.Domains
{
    public partial class Produto
    {
        public Produto()
        {
            Denuncia = new HashSet<Denuncia>();
        }

        public int IdProduto { get; set; }
        public short? IdFotosProduto { get; set; }
        public short? IdSituacao { get; set; }
        public int? IdModelo { get; set; }
        public int? IdUsuario { get; set; }
        public DateTime DataAnuncio { get; set; }
        public string Descricao { get; set; }
        public string Titulo { get; set; }
        public string Ano { get; set; }
        public double Km { get; set; }
        public string Cor { get; set; }

        public virtual FotosProduto IdFotosProdutoNavigation { get; set; }
        public virtual Modelo IdModeloNavigation { get; set; }
        public virtual Situacao IdSituacaoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Denuncia> Denuncia { get; set; }
    }
}
