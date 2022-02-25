using System;
using System.Collections.Generic;

#nullable disable

namespace ProjetoClassificados.Domains
{
    public partial class Situacao
    {
        public Situacao()
        {
            Produtos = new HashSet<Produto>();
        }

        public short IdSituacao { get; set; }
        public string TituloSituacao { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
