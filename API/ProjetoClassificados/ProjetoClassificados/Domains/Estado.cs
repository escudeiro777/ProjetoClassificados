using System;
using System.Collections.Generic;

#nullable disable

namespace ProjetoClassificados.Domains
{
    public partial class Estado
    {
        public Estado()
        {
            Anuncios = new HashSet<Anuncio>();
        }

        public byte IdEstado { get; set; }
        public string NomeEstado { get; set; }

        public virtual ICollection<Anuncio> Anuncios { get; set; }
    }
}
