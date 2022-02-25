using System;
using System.Collections.Generic;

#nullable disable

namespace ProjetoClassificados.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Denuncia = new HashSet<Denuncia>();
            FotosProdutos = new HashSet<FotosProduto>();
            Produtos = new HashSet<Produto>();
        }

        public int IdUsuario { get; set; }
        public short? IdTipoUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public byte? NotaComprador { get; set; }
        public byte? NotaVendedor { get; set; }
        public string CaminhoImagemUsuario { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Denuncia> Denuncia { get; set; }
        public virtual ICollection<FotosProduto> FotosProdutos { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
