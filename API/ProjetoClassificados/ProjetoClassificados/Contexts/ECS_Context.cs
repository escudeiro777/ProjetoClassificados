using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjetoClassificados.Domains;

#nullable disable

namespace ProjetoClassificados.Contexts
{
    public partial class ECS_Context : DbContext
    {
        public ECS_Context()
        {
        }

        public ECS_Context(DbContextOptions<ECS_Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Anuncio> Anuncios { get; set; }
        public virtual DbSet<Cor> Cors { get; set; }
        public virtual DbSet<Denuncium> Denuncia { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<FotoProduto> FotoProdutos { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<Modelo> Modelos { get; set; }
        public virtual DbSet<Situacao> Situacaos { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=PANZERII\\SQLEXPRESS; initial catalog=ESCUDERIA_CAR_SALE; user id=sa; pwd=senai@#132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Anuncio>(entity =>
            {
                entity.HasKey(e => e.IdAnuncio)
                    .HasName("PK__anuncio__0BC1EC3ECC841600");

                entity.ToTable("anuncio");

                entity.Property(e => e.IdAnuncio).HasColumnName("idAnuncio");

                entity.Property(e => e.AnoVeiculo)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("anoVeiculo")
                    .IsFixedLength(true);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("cidade");

                entity.Property(e => e.DataAnuncio)
                    .HasColumnType("datetime")
                    .HasColumnName("dataAnuncio");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.IdCor).HasColumnName("idCor");

                entity.Property(e => e.IdEstado).HasColumnName("idEstado");

                entity.Property(e => e.IdModelo).HasColumnName("idModelo");

                entity.Property(e => e.IdSituacao).HasColumnName("idSituacao");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Km).HasColumnName("km");

                entity.Property(e => e.Preco)
                    .HasColumnType("money")
                    .HasColumnName("preco");

                entity.Property(e => e.TituloAnuncio)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tituloAnuncio");

                entity.Property(e => e.Troca).HasColumnName("troca");

                entity.HasOne(d => d.IdCorNavigation)
                    .WithMany(p => p.Anuncios)
                    .HasForeignKey(d => d.IdCor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__anuncio__idCor__3A81B327");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Anuncios)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__anuncio__idEstad__3B75D760");

                entity.HasOne(d => d.IdModeloNavigation)
                    .WithMany(p => p.Anuncios)
                    .HasForeignKey(d => d.IdModelo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__anuncio__idModel__398D8EEE");

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.Anuncios)
                    .HasForeignKey(d => d.IdSituacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__anuncio__idSitua__38996AB5");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Anuncios)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__anuncio__idUsuar__37A5467C");
            });

            modelBuilder.Entity<Cor>(entity =>
            {
                entity.HasKey(e => e.IdCor)
                    .HasName("PK__cor__398F1E9092717B90");

                entity.ToTable("cor");

                entity.Property(e => e.IdCor)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idCor");

                entity.Property(e => e.NomeCor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomeCor");
            });

            modelBuilder.Entity<Denuncium>(entity =>
            {
                entity.HasKey(e => e.IdDenuncia)
                    .HasName("PK__denuncia__D5515747176C89F0");

                entity.ToTable("denuncia");

                entity.Property(e => e.IdDenuncia).HasColumnName("idDenuncia");

                entity.Property(e => e.DataDenuncia)
                    .HasColumnType("datetime")
                    .HasColumnName("dataDenuncia");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.IdAnuncio).HasColumnName("idAnuncio");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.HasOne(d => d.IdAnuncioNavigation)
                    .WithMany(p => p.Denuncia)
                    .HasForeignKey(d => d.IdAnuncio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__denuncia__idAnun__4316F928");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Denuncia)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__denuncia__idUsua__440B1D61");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__estado__62EA894AA6AA3D90");

                entity.ToTable("estado");

                entity.Property(e => e.IdEstado)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idEstado");

                entity.Property(e => e.NomeEstado)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomeEstado");
            });

            modelBuilder.Entity<FotoProduto>(entity =>
            {
                entity.HasKey(e => e.IdFotoProduto)
                    .HasName("PK__fotoProd__D382A2399CFF7C46");

                entity.ToTable("fotoProduto");

                entity.Property(e => e.IdFotoProduto).HasColumnName("idFotoProduto");

                entity.Property(e => e.DataInclusao)
                    .HasColumnType("datetime")
                    .HasColumnName("dataInclusao")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdAnuncio).HasColumnName("idAnuncio");

                entity.Property(e => e.ImgBinario)
                    .IsRequired()
                    .HasColumnName("imgBinario");

                entity.Property(e => e.MimeType)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("mimeType");

                entity.Property(e => e.NomeArquivo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nomeArquivo");

                entity.HasOne(d => d.IdAnuncioNavigation)
                    .WithMany(p => p.FotoProdutos)
                    .HasForeignKey(d => d.IdAnuncio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__fotoProdu__idAnu__3F466844");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("PK__marca__703318129F58CBA6");

                entity.ToTable("marca");

                entity.Property(e => e.IdMarca).HasColumnName("idMarca");

                entity.Property(e => e.NomeMarca)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomeMarca");
            });

            modelBuilder.Entity<Modelo>(entity =>
            {
                entity.HasKey(e => e.IdModelo)
                    .HasName("PK__modelo__13A52CD13DFD5E6F");

                entity.ToTable("modelo");

                entity.Property(e => e.IdModelo).HasColumnName("idModelo");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.IdMarca).HasColumnName("idMarca");

                entity.Property(e => e.NomeModelo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomeModelo");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Modelos)
                    .HasForeignKey(d => d.IdMarca)
                    .HasConstraintName("FK__modelo__idMarca__30F848ED");
            });

            modelBuilder.Entity<Situacao>(entity =>
            {
                entity.HasKey(e => e.IdSituacao)
                    .HasName("PK__situacao__12AFD197EE6E4B29");

                entity.ToTable("situacao");

                entity.Property(e => e.IdSituacao).HasColumnName("idSituacao");

                entity.Property(e => e.TituloSituacao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tituloSituacao")
                    .HasDefaultValueSql("('Ativo')");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__tipoUsua__03006BFF45AB4F26");

                entity.ToTable("tipoUsuario");

                entity.HasIndex(e => e.Titulo, "UQ__tipoUsua__38FA640F032B6DF4")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("titulo");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuario__645723A6FB58B78E");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.Email, "UQ__usuario__AB6E616426A7D2E0")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.CaminhoImagemUsuario)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("caminhoImagemUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.NotaComprador).HasColumnName("notaComprador");

                entity.Property(e => e.NotaVendedor).HasColumnName("notaVendedor");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuario__idTipoU__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
