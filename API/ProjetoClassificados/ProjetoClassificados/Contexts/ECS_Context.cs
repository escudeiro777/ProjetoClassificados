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

        public virtual DbSet<Denuncia> Denuncia { get; set; }
        public virtual DbSet<FotosProduto> FotosProdutos { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<Modelo> Modelos { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Situacao> Situacaos { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.

                //optionsBuilder.UseSqlServer("Data Source=NOTE0113B2\\SQLEXPRESS; initial catalog=ESCUDERIA_CAR_SALE; user id=SA; pwd=Senai@132;");
                optionsBuilder.UseSqlServer("Data Source=NOTE0113D1\\SQLEXPRESS; initial catalog=ESCUDERIA_CAR_SALE; user id=SA; pwd=Senai@132;");
                //optionsBuilder.UseSqlServer("Data Source=DESKTOP-KCJ0MKP; initial catalog=ESCUDERIA_CAR_SALE; Integrated Security=True");

                //Scaffold-DbContext "Data Source=PANZERII\SQLEXPRESS; initial catalog=ESCUDERIA_CAR_SALE; user id=sa; pwd=senai@#132;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Domains -ContextDir Contexts -Context ECS_Context
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Denuncia>(entity =>
            {
                entity.HasKey(e => e.IdDenuncia)
                    .HasName("PK__denuncia__D55157477FD0EFB5");

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

                entity.Property(e => e.IdProduto).HasColumnName("idProduto");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.Denuncia)
                    .HasForeignKey(d => d.IdProduto)
                    .HasConstraintName("FK__denuncia__idProd__3E52440B");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Denuncia)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__denuncia__idUsua__3F466844");
            });

            modelBuilder.Entity<FotosProduto>(entity =>
            {
                entity.HasKey(e => e.IdFotosProduto)
                    .HasName("PK__fotosPro__ADBF6CFA69FD5A0E");

                entity.ToTable("fotosProduto");

                entity.Property(e => e.IdFotosProduto).HasColumnName("idFotosProduto");

                entity.Property(e => e.DataInclusao)
                    .HasColumnType("datetime")
                    .HasColumnName("dataInclusao")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

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
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("nomeArquivo");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.FotosProdutos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__fotosProd__idUsu__34C8D9D1");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("PK__marca__7033181278E3065F");

                entity.ToTable("marca");

                entity.Property(e => e.IdMarca).HasColumnName("idMarca");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Modelo>(entity =>
            {
                entity.HasKey(e => e.IdModelo)
                    .HasName("PK__modelo__13A52CD1DC60D075");

                entity.ToTable("modelo");

                entity.Property(e => e.IdModelo).HasColumnName("idModelo");

                entity.Property(e => e.IdMarca).HasColumnName("idMarca");

                entity.Property(e => e.NomeMarca)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomeMarca");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Modelos)
                    .HasForeignKey(d => d.IdMarca)
                    .HasConstraintName("FK__modelo__idMarca__31EC6D26");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.IdProduto)
                    .HasName("PK__produto__5EEDF7C3B1989E67");

                entity.ToTable("produto");

                entity.Property(e => e.IdProduto).HasColumnName("idProduto");

                entity.Property(e => e.Ano)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("ano");

                entity.Property(e => e.Cor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cor");

                entity.Property(e => e.DataAnuncio)
                    .HasColumnType("datetime")
                    .HasColumnName("dataAnuncio");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.IdFotosProduto).HasColumnName("idFotosProduto");

                entity.Property(e => e.IdModelo).HasColumnName("idModelo");

                entity.Property(e => e.IdSituacao).HasColumnName("idSituacao");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Km).HasColumnName("km");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.HasOne(d => d.IdFotosProdutoNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdFotosProduto)
                    .HasConstraintName("FK__produto__idFotos__38996AB5");

                entity.HasOne(d => d.IdModeloNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdModelo)
                    .HasConstraintName("FK__produto__idModel__3A81B327");

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdSituacao)
                    .HasConstraintName("FK__produto__idSitua__398D8EEE");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__produto__idUsuar__3B75D760");
            });

            modelBuilder.Entity<Situacao>(entity =>
            {
                entity.HasKey(e => e.IdSituacao)
                    .HasName("PK__situacao__12AFD197AE92F137");

                entity.ToTable("situacao");

                entity.HasIndex(e => e.TituloSituacao, "UQ__situacao__A379E97695205195")
                    .IsUnique();

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
                    .HasName("PK__tipoUsua__03006BFFB942077D");

                entity.ToTable("tipoUsuario");

                entity.HasIndex(e => e.Titulo, "UQ__tipoUsua__38FA640FC4D7B879")
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
                    .HasName("PK__usuario__645723A623A3E51B");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.Email, "UQ__usuario__AB6E61643669C63F")
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
                    .HasConstraintName("FK__usuario__idTipoU__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
