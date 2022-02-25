﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ProjetoClassificados.Domains
{
    public partial class FotosProduto
    {
        public FotosProduto()
        {
            Produtos = new HashSet<Produto>();
        }

        public short IdFotosProduto { get; set; }
        public int? IdUsuario { get; set; }
        public byte[] ImgBinario { get; set; }
        public string MimeType { get; set; }
        public string NomeArquivo { get; set; }
        public DateTime? DataInclusao { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
