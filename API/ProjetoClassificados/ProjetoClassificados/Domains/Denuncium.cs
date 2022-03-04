using System;
using System.Collections.Generic;

#nullable disable

namespace ProjetoClassificados.Domains
{
    public partial class Denuncium
    {
        public int IdDenuncia { get; set; }
        public int IdAnuncio { get; set; }
        public int IdUsuario { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataDenuncia { get; set; }

        public virtual Anuncio IdAnuncioNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
