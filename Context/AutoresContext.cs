using System;
using System.Collections.Generic;
using ApiAutores.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiAutores.Context
{
    public partial class AutoresContext : DbContext
    {
        public AutoresContext()
        {
        }

        public AutoresContext(DbContextOptions<AutoresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autors { get; set; } = null!;
        public virtual DbSet<Libro> Libros { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>(entity =>
            {
                entity.HasKey(e => e.IdAutor)
                    .HasName("PK__Autor__DD33B0317B2AFBBD");

                entity.ToTable("Autor");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.IdLibro)
                    .HasName("PK__Libros__3E0B49AD427BD097");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAutorNavigation)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.IdAutor)
                    .HasConstraintName("Fk_Libros_Refe_Autores");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
