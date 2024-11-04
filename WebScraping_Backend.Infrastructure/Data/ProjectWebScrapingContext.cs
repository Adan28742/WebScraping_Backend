using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__A3C02A1069217585");

            entity.Property(e => e.IdCategoria).ValueGeneratedNever();
            entity.Property(e => e.Descripcion).HasMaxLength(100);
        });

        modelBuilder.Entity<ListaGuardado>(entity =>
        {
            entity.HasKey(e => new { e.IdVideoGenerado, e.IdUsuario }).HasName("PK__Lista_Gu__A244C8B2EAEDFC1E");

            entity.ToTable("Lista_Guardado");

            entity.Property(e => e.Estado).HasMaxLength(20);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion");

            entity.HasOne(d => d.IdTipoGuardadoNavigation).WithMany(p => p.ListaGuardado)
                .HasForeignKey(d => d.IdTipoGuardado)
                .HasConstraintName("FK__Lista_Gua__IdTip__48CFD27E");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.ListaGuardado)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Lista_Gua__IdUsu__46E78A0C");

            entity.HasOne(d => d.IdVideoGeneradoNavigation).WithMany(p => p.ListaGuardado)
                .HasForeignKey(d => d.IdVideoGenerado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Lista_Gua__IdVid__45F365D3");
        });

        modelBuilder.Entity<TipoGuardado>(entity =>
        {
            entity.HasKey(e => e.IdTipoGuardado).HasName("PK__TipoGuar__D1EF3D69A4F037AF");

            entity.Property(e => e.IdTipoGuardado).ValueGeneratedNever();
            entity.Property(e => e.Descripcion).HasMaxLength(100);
        });

        modelBuilder.Entity<TipoUsuario>(entity =>
        {
            entity.HasKey(e => e.IdTipoUsuario).HasName("PK__TipoUsua__CA04062BD9220D13");

            entity.Property(e => e.IdTipoUsuario).ValueGeneratedNever();
            entity.Property(e => e.Descripcion).HasMaxLength(100);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97E86AF5C6");

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D105345F750B73").IsUnique();

            entity.Property(e => e.IdUsuario).ValueGeneratedNever();
            entity.Property(e => e.Apellidos).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Estado).HasMaxLength(20);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion");
            entity.Property(e => e.Nombres).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(15);
            entity.Property(e => e.UltimoAcceso)
                .HasColumnType("datetime")
                .HasColumnName("Ultimo_acceso");

            entity.HasOne(d => d.IdTipoUsuarioNavigation).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.IdTipoUsuario)
                .HasConstraintName("FK__Usuario__IdTipoU__3C69FB99");
        });

        modelBuilder.Entity<VideoGenerado>(entity =>
        {
            entity.HasKey(e => e.IdVideoGenerado).HasName("PK__VideoGen__C7F2934BCC3E755B");

            entity.Property(e => e.IdVideoGenerado).ValueGeneratedNever();
            entity.Property(e => e.Estado).HasMaxLength(20);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.VideoGenerado)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__VideoGene__IdCat__403A8C7D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
