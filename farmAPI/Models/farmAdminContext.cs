using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace farmAPI.Models
{
    public partial class farmAdminContext : DbContext
    {
        public farmAdminContext()
        {
        }

        public farmAdminContext(DbContextOptions<farmAdminContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FarmAnimal> FarmAnimals { get; set; }
        public virtual DbSet<FarmAnimalIncompatibility> FarmAnimalIncompatibilities { get; set; }
        public virtual DbSet<FarmAnimalType> FarmAnimalTypes { get; set; }
        public virtual DbSet<FarmCorral> FarmCorrals { get; set; }
        public virtual DbSet<FarmDanger> FarmDangers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=CCAV_Des02\\SQLEXPRESS;Database=farmAdmin;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<FarmAnimal>(entity =>
            {
                entity.ToTable("farm_animal");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.IdCorral).HasColumnName("idCorral");

                entity.Property(e => e.IdTipo).HasColumnName("idTipo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdCorralNavigation)
                    .WithMany(p => p.FarmAnimals)
                    .HasForeignKey(d => d.IdCorral)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__farm_anim__idCor__5535A963");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.FarmAnimals)
                    .HasForeignKey(d => d.IdTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__farm_anim__idTip__5441852A");
            });

            modelBuilder.Entity<FarmAnimalIncompatibility>(entity =>
            {
                entity.ToTable("farm_animalIncompatibility");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdTipo).HasColumnName("idTipo");

                entity.Property(e => e.IdTipoNoCompatible).HasColumnName("idTipoNoCompatible");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.FarmAnimalIncompatibilityIdTipoNavigations)
                    .HasForeignKey(d => d.IdTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__farm_anim__idTip__5070F446");

                entity.HasOne(d => d.IdTipoNoCompatibleNavigation)
                    .WithMany(p => p.FarmAnimalIncompatibilityIdTipoNoCompatibleNavigations)
                    .HasForeignKey(d => d.IdTipoNoCompatible)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__farm_anim__idTip__5165187F");
            });

            modelBuilder.Entity<FarmAnimalType>(entity =>
            {
                entity.ToTable("farm_animalType");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdPeligrosidad).HasColumnName("idPeligrosidad");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdPeligrosidadNavigation)
                    .WithMany(p => p.FarmAnimalTypes)
                    .HasForeignKey(d => d.IdPeligrosidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__farm_anim__idPel__4D94879B");
            });

            modelBuilder.Entity<FarmCorral>(entity =>
            {
                entity.ToTable("farm_corral");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Capacidad).HasColumnName("capacidad");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<FarmDanger>(entity =>
            {
                entity.ToTable("farm_danger");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
