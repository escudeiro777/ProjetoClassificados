using System;
using System.Collections.Generic;

#nullable disable

namespace ProjetoClassificados.Domains
{
    public partial class Marca
    {
        public Marca()
        {
            Modelos = new HashSet<Modelo>();
        }

        public short IdMarca { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Modelo> Modelos { get; set; }
    }
}
