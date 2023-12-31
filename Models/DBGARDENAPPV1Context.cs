using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GardenAppV1.Models
{
    public partial class DBGARDENAPPV1Context : DbContext
    {
        public DBGARDENAPPV1Context()
        {
        }

        public DBGARDENAPPV1Context(DbContextOptions<DBGARDENAPPV1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Jardin> Jardins { get; set; } = null!;
        public virtual DbSet<Sensorhumedad> Sensorhumedads { get; set; } = null!;
        public virtual DbSet<Sensorriego> Sensorriegos { get; set; } = null!;
        public virtual DbSet<Sensortemperatura> Sensortemperaturas { get; set; } = null!;
        public virtual DbSet<Tipodocumento> Tipodocumentos { get; set; } = null!;
        public virtual DbSet<Tiporole> Tiporoles { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jardin>(entity =>
            {
                entity.HasKey(e => e.IdJardin)
                    .HasName("PK__JARDIN__7E67FC6DA46C5C91");

                entity.ToTable("JARDIN");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_at");

                entity.Property(e => e.ValorSensor)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sensorhumedad>(entity =>
            {
                entity.HasKey(e => e.IdHumedad)
                    .HasName("PK__SENSORHU__9C0EACCFD0C92436");

                entity.ToTable("SENSORHUMEDAD");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_at");

                entity.Property(e => e.ValorHumedad)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.oJardin)
                    .WithMany(p => p.Sensorhumedads)
                    .HasForeignKey(d => d.IdJardin)
                    .HasConstraintName("FK_IdJardinHumedad");
            });

            modelBuilder.Entity<Sensorriego>(entity =>
            {
                entity.HasKey(e => e.IdRiego)
                    .HasName("PK__SENSORRI__741E2BBFB9AB5543");

                entity.ToTable("SENSORRIEGO");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_at");

                entity.Property(e => e.FinalicedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Finaliced_at");

                entity.HasOne(d => d.oJardin)
                    .WithMany(p => p.Sensorriegos)
                    .HasForeignKey(d => d.IdJardin)
                    .HasConstraintName("FK_IdJardinRiego");
            });

            modelBuilder.Entity<Sensortemperatura>(entity =>
            {
                entity.HasKey(e => e.IdTemperatura)
                    .HasName("PK__SENSORTE__9DF79783C73D1EB1");

                entity.ToTable("SENSORTEMPERATURA");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_at");

                entity.Property(e => e.ValorTemperatura)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.oJardin)
                    .WithMany(p => p.Sensortemperaturas)
                    .HasForeignKey(d => d.IdJardin)
                    .HasConstraintName("FK_IdJardinTemperatura");
            });

            modelBuilder.Entity<Tipodocumento>(entity =>
            {
                entity.HasKey(e => e.IdTipoDocumento)
                    .HasName("PK__TIPODOCU__3AB3332FE5044E8B");

                entity.ToTable("TIPODOCUMENTO");

                entity.Property(e => e.TipoDocumento1)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("TipoDocumento");
            });

            modelBuilder.Entity<Tiporole>(entity =>
            {
                entity.HasKey(e => e.IdTipoRoles)
                    .HasName("PK__TIPOROLE__EFE553C266B49BDD");

                entity.ToTable("TIPOROLES");

                entity.Property(e => e.TipoRoles)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__USUARIOS__5B65BF975225E306");

                entity.ToTable("USUARIOS");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdJardinNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdJardin)
                    .HasConstraintName("FK_IdJardin");

                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .HasConstraintName("FK_TipoDocumento");

                entity.HasOne(d => d.IdTipoRolesNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoRoles)
                    .HasConstraintName("FK_TipoRoles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
