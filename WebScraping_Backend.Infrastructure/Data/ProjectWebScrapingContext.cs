using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebScraping_Backend.Core;
using WebScraping_Backend.Core.Entities;

namespace WebScraping_Backend.Infrastructure.Data;

public partial class ProjectWebScrapingContext : DbContext
{
    public ProjectWebScrapingContext()
    {
    }

    public ProjectWebScrapingContext(DbContextOptions<ProjectWebScrapingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<ListaGuardado> ListaGuardado { get; set; }

    public virtual DbSet<TipoGuardado> TipoGuardado { get; set; }

    public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    public virtual DbSet<VideoGenerado> VideoGenerado { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Adan-Mesias;Initial Catalog=ProjectWebScraping;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__A3C02A109234186F");

            entity.Property(e => e.Descripcion).HasMaxLength(100);
        });

        modelBuilder.Entity<ListaGuardado>(entity =>
        {
            entity.HasKey(e => e.IdListaGuardado).HasName("PK__Lista_Gu__861B01E20ABD7AB0");

            entity.ToTable("Lista_Guardado");

            entity.Property(e => e.IdListaGuardado).HasColumnName("IdLista_Guardado");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdTipoGuardadoNavigation).WithMany(p => p.ListaGuardado)
                .HasForeignKey(d => d.IdTipoGuardado)
                .HasConstraintName("FK__Lista_Gua__IdTip__48CFD27E");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.ListaGuardado)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Lista_Gua__IdUsu__46E78A0C");

            entity.HasOne(d => d.IdVideoGeneradoNavigation).WithMany(p => p.ListaGuardado)
                .HasForeignKey(d => d.IdVideoGenerado)
                .HasConstraintName("FK__Lista_Gua__IdVid__45F365D3");
        });

        modelBuilder.Entity<TipoGuardado>(entity =>
        {
            entity.HasKey(e => e.IdTipoGuardado).HasName("PK__TipoGuar__D1EF3D692BF78B92");

            entity.Property(e => e.Descripcion).HasMaxLength(100);
        });

        modelBuilder.Entity<TipoUsuario>(entity =>
        {
            entity.HasKey(e => e.IdTipoUsuario).HasName("PK__TipoUsua__CA04062BDB0C56A5");

            entity.Property(e => e.Descripcion).HasMaxLength(100);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97C8EE9AB1");

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D10534CA4A3E83").IsUnique();

            entity.Property(e => e.Apellidos).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombres).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(15);
            entity.Property(e => e.UltimoAcceso).HasColumnType("datetime");

            entity.HasOne(d => d.IdTipoUsuarioNavigation).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.IdTipoUsuario)
                .HasConstraintName("FK__Usuario__IdTipoU__3C69FB99");
        });

        modelBuilder.Entity<VideoGenerado>(entity =>
        {
            entity.HasKey(e => e.IdVideoGenerado).HasName("PK__VideoGen__C7F2934BB6239310");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.VideoGenerado)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__VideoGene__IdCat__403A8C7D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
