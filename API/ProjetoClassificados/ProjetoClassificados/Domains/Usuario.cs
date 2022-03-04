using System;
using System.Collections.Generic;

#nullable disable

namespace ProjetoClassificados.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Anuncios = new HashSet<Anuncio>();
            Denuncia = new HashSet<Denuncium>();
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
        public virtual ICollection<Anuncio> Anuncios { get; set; }
        public virtual ICollection<Denuncium> Denuncia { get; set; }
    }
}
