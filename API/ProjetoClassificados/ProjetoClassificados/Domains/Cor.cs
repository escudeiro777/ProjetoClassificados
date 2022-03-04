using System;
using System.Collections.Generic;

#nullable disable

namespace ProjetoClassificados.Domains
{
    public partial class Cor
    {
        public Cor()
        {
            Anuncios = new HashSet<Anuncio>();
        }

        public byte IdCor { get; set; }
        public string NomeCor { get; set; }

        public virtual ICollection<Anuncio> Anuncios { get; set; }
    }
}
