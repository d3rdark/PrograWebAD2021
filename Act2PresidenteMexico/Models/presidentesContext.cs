using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Act2PresidenteMexico.Models
{
    public partial class presidentesContext : DbContext
    {
        public presidentesContext()
        {
        }

        public presidentesContext(DbContextOptions<presidentesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Estadorepublica> Estadorepublicas { get; set; }
        public virtual DbSet<Partidopolitico> Partidopoliticos { get; set; }
        public virtual DbSet<Presidente> Presidentes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;user=root;password=adlogcat45;database=presidentes", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.23-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            modelBuilder.Entity<Estadorepublica>(entity =>
            {
                entity.ToTable("estadorepublica");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Partidopolitico>(entity =>
            {
                entity.ToTable("partidopolitico");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Presidente>(entity =>
            {
                entity.ToTable("presidente");

                entity.HasIndex(e => e.IdEstadoRepublica, "IdEstadoRepublica_idx");

                entity.HasIndex(e => e.IdPartidoPolitico, "IdPartidoPolitico_idx");

                entity.Property(e => e.Biografia).IsRequired();

                entity.Property(e => e.CiudadNacimiento).HasColumnType("text");

                entity.Property(e => e.FechaFallecimiento).HasColumnType("date");

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.InicioGobierno).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Ocupacion).HasColumnType("text");

                entity.Property(e => e.TerminoGobierno).HasColumnType("date");

                entity.HasOne(d => d.IdEstadoRepublicaNavigation)
                    .WithMany(p => p.Presidentes)
                    .HasForeignKey(d => d.IdEstadoRepublica)
                    .HasConstraintName("IdEstadoRepublica");

                entity.HasOne(d => d.IdPartidoPoliticoNavigation)
                    .WithMany(p => p.Presidentes)
                    .HasForeignKey(d => d.IdPartidoPolitico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IdPartidoPolitico");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
