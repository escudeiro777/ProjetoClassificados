using System;
using System.Collections.Generic;

#nullable disable

namespace ProjetoClassificados.Domains
{
    public partial class Denuncia
    {
        public int IdDenuncia { get; set; }
        public int? IdProduto { get; set; }
        public int? IdUsuario { get; set; }
        public DateTime DataDenuncia { get; set; }
        public string Descricao { get; set; }
        public string Titulo { get; set; }

        public virtual Produto IdProdutoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
