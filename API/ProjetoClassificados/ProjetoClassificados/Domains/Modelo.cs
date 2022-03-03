using System;
using System.Collections.Generic;

#nullable disable

namespace ProjetoClassificados.Domains
{
    public partial class Modelo
    {
        public Modelo()
        {
            Anuncios = new HashSet<Anuncio>();
        }

        public int IdModelo { get; set; }
        public short? IdMarca { get; set; }
        public string NomeModelo { get; set; }
        public string Descricao { get; set; }

        public virtual Marca IdMarcaNavigation { get; set; }
        public virtual ICollection<Anuncio> Anuncios { get; set; }
    }
}
