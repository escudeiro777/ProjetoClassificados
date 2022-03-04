using System;
using System.Collections.Generic;

#nullable disable

namespace ProjetoClassificados.Domains
{
    public partial class Situacao
    {
        public Situacao()
        {
            Anuncios = new HashSet<Anuncio>();
        }

        public short IdSituacao { get; set; }
        public string TituloSituacao { get; set; }

        public virtual ICollection<Anuncio> Anuncios { get; set; }
    }
}
