using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Act3MapCurricular.Models
{
    public partial class mapa_curricularContext : DbContext
    {
        public mapa_curricularContext()
        {
        }

        public mapa_curricularContext(DbContextOptions<mapa_curricularContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Carrera> Carreras { get; set; }
        public virtual DbSet<Materia> Materias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseMySql("server=localhost;user=root;password=adlogcat45;database=mapa_curricular", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.23-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.ToTable("carreras");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.Clave, "Clave_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength(true);

                entity.Property(e => e.Descripcion).HasColumnType("text");

                entity.Property(e => e.Especialidad)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Plan)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Materia>(entity =>
            {
                entity.ToTable("materias");

                entity.HasIndex(e => e.IdCarrera, "fkmat_idx1");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(65);

                entity.HasOne(d => d.IdCarreraNavigation)
                    .WithMany(p => p.Materia)
                    .HasForeignKey(d => d.IdCarrera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkmat");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
