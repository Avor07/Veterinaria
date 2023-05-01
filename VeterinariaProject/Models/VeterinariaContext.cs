using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace VeterinariaProject.Models
{
    public partial class VeterinariaContext : DbContext
    {
        public VeterinariaContext()
        {
        }

        public VeterinariaContext(DbContextOptions<VeterinariaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cita> Cita { get; set; }
        public virtual DbSet<Mascota> Mascota { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("defaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Cita>(entity =>
            {
                entity.HasKey(e => e.IdCita);

                entity.Property(e => e.IdCita).HasColumnName("Id_Cita");

                entity.Property(e => e.FechaCita)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_cita");

                entity.Property(e => e.IdMascotaFk).HasColumnName("Id_MascotaFK");

                entity.Property(e => e.NombreDueño)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_dueño");

                entity.HasOne(d => d.IdMascotaFkNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdMascotaFk)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ID_Mascota");
            });

            modelBuilder.Entity<Mascota>(entity =>
            {
                entity.HasKey(e => e.IdMascota);

                entity.Property(e => e.IdMascota).HasColumnName("Id_Mascota");

                entity.Property(e => e.Especie)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
