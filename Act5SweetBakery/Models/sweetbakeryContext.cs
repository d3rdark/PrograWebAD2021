using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Act5SweetBakery.Models
{
    public partial class sweetbakeryContext : DbContext
    {
        public sweetbakeryContext()
        {
        }

        public sweetbakeryContext(DbContextOptions<sweetbakeryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Receta> Recetas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseMySql("server=localhost;user=root;password=adlogcat45;database=sweetbakery", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.23-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("categorias");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("productos");

                entity.HasIndex(e => e.IdCategoria, "fkca2t_idx");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkcat2");
            });

            modelBuilder.Entity<Receta>(entity =>
            {
                entity.ToTable("recetas");

                entity.HasIndex(e => e.IdCategoria, "fkcat_idx");

                entity.Property(e => e.Descripcion).HasColumnType("text");

                entity.Property(e => e.Ingredientes).HasColumnType("text");

                entity.Property(e => e.Nombre).HasMaxLength(45);

                entity.Property(e => e.Procedimiento).HasColumnType("text");

                entity.Property(e => e.Reseña).HasColumnType("text");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Receta)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("fkcat");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
