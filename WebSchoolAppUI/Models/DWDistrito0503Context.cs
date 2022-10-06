using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class DWDistrito0503Context : DbContext
    {
        public DWDistrito0503Context()
        {
        }

        public DWDistrito0503Context(DbContextOptions<DWDistrito0503Context> options)
            : base(options)
        {
        }

        public virtual DbSet<CentrosEducativo> CentrosEducativos { get; set; }
        public virtual DbSet<PersonalCentro> PersonalCentros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=DWDistrito0503;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CentrosEducativo>(entity =>
            {
                entity.HasKey(e => e.IdCentroEducativo)
                    .HasName("PK__CentrosE__0C73717DC1B23CDB");

                entity.Property(e => e.FechaCreado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificado).HasColumnType("datetime");

                entity.Property(e => e.Nombre).HasMaxLength(5);
            });

            modelBuilder.Entity<PersonalCentro>(entity =>
            {
                entity.HasKey(e => e.IdPersonalCentro)
                    .HasName("PK__Personal__53273D9EA3BF639E");

                entity.ToTable("PersonalCentro");

                entity.Property(e => e.Apellido).HasMaxLength(255);

                entity.Property(e => e.Cedula).HasMaxLength(11);

                entity.Property(e => e.FechaCreado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificado).HasColumnType("datetime");

                entity.Property(e => e.Nombre).HasMaxLength(255);

                entity.HasOne(d => d.IdCentroNavigation)
                    .WithMany(p => p.PersonalCentros)
                    .HasForeignKey(d => d.IdCentro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonalCentro");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
