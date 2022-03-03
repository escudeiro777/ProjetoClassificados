using System;
using System.Collections.Generic;

#nullable disable

namespace ProjetoClassificados.Domains
{
    public partial class FotoProduto
    {
        public short IdFotoProduto { get; set; }
        public int IdAnuncio { get; set; }
        public byte[] ImgBinario { get; set; }
        public string MimeType { get; set; }
        public string NomeArquivo { get; set; }
        public DateTime? DataInclusao { get; set; }

        public virtual Anuncio IdAnuncioNavigation { get; set; }
    }
}
