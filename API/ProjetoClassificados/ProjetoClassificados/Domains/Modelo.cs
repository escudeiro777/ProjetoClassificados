using System;
using System.Collections.Generic;

#nullable disable

namespace ProjetoClassificados.Domains
{
    public partial class Modelo
    {
        public Modelo()
        {
            Produtos = new HashSet<Produto>();
        }

        public int IdModelo { get; set; }
        public short? IdMarca { get; set; }
        public string NomeMarca { get; set; }

        public virtual Marca IdMarcaNavigation { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
