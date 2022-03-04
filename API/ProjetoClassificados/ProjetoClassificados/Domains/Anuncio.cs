using System;
using System.Collections.Generic;

#nullable disable

namespace ProjetoClassificados.Domains
{
    public partial class Anuncio
    {
        public Anuncio()
        {
            Denuncia = new HashSet<Denuncium>();
            FotoProdutos = new HashSet<FotoProduto>();
        }

        public int IdAnuncio { get; set; }
        public int IdUsuario { get; set; }
        public short IdSituacao { get; set; }
        public int IdModelo { get; set; }
        public byte IdCor { get; set; }
        public byte IdEstado { get; set; }
        public string TituloAnuncio { get; set; }
        public string Descricao { get; set; }
        public DateTime DataAnuncio { get; set; }
        public string AnoVeiculo { get; set; }
        public short Km { get; set; }
        public string Cidade { get; set; }
        public decimal Preco { get; set; }
        public byte Troca { get; set; }

        public virtual Cor IdCorNavigation { get; set; }
        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual Modelo IdModeloNavigation { get; set; }
        public virtual Situacao IdSituacaoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Denuncium> Denuncia { get; set; }
        public virtual ICollection<FotoProduto> FotoProdutos { get; set; }
    }
}
