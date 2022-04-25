using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebSchoolAppUI.Models;

#nullable disable

namespace WebSchoolAppUI.Data
{
    public partial class WebSchoolProjectDBContext : DbContext
    {
        public WebSchoolProjectDBContext()
        {
        }

        public WebSchoolProjectDBContext(DbContextOptions<WebSchoolProjectDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Condicion> Condicions { get; set; }
        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Estudiante> Estudiantes { get; set; }
        public virtual DbSet<EstudianteCurso> EstudianteCursos { get; set; }
        public virtual DbSet<Modalidad> Modalidads { get; set; }
        public virtual DbSet<Nivel> Nivels { get; set; }
        public virtual DbSet<Profesor> Profesors { get; set; }
        public virtual DbSet<Seccion> Seccions { get; set; }
        public virtual DbSet<Sexo> Sexos { get; set; }
        public virtual DbSet<Tutor> Tutors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=WebSchoolProjectDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Condicion>(entity =>
            {
                entity.HasKey(e => e.IdCondicion)
                    .HasName("PK__Condicio__7BCB6514FEE67C38");

                entity.Property(e => e.NombreCondicion).IsUnicode(false);
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__Curso__085F27D6CFCDFBC4");

                entity.Property(e => e.IdCurso).ValueGeneratedNever();

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.HasOne(d => d.NivelNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.Nivel)
                    .HasConstraintName("FK__Curso__Nivel__37A5467C");

                entity.HasOne(d => d.ProfesorNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.Profesor)
                    .HasConstraintName("FK__Curso__Profesor__38996AB5");

                entity.HasOne(d => d.SeccionNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.Seccion)
                    .HasConstraintName("FK__Curso__Seccion__398D8EEE");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__Estado__FBB0EDC182936051");

                entity.Property(e => e.NombreEstado).IsUnicode(false);
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.IdSigerd)
                    .HasName("PK__Estudian__360197AFC90329A2");

                entity.Property(e => e.IdSigerd).ValueGeneratedNever();

                entity.Property(e => e.Apellido).IsUnicode(false);

                entity.Property(e => e.Contacto).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.HasOne(d => d.CondicionNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.Condicion)
                    .HasConstraintName("FK__Estudiant__Condi__3A81B327");

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("FK__Estudiant__Estad__3B75D760");

                entity.HasOne(d => d.MadreNavigation)
                    .WithMany(p => p.EstudianteMadreNavigations)
                    .HasForeignKey(d => d.Madre)
                    .HasConstraintName("FK__Estudiant__Madre__3C69FB99");

                entity.HasOne(d => d.ModalidadNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.Modalidad)
                    .HasConstraintName("FK__Estudiant__Modal__3D5E1FD2");

                entity.HasOne(d => d.PadreNavigation)
                    .WithMany(p => p.EstudiantePadreNavigations)
                    .HasForeignKey(d => d.Padre)
                    .HasConstraintName("FK__Estudiant__Padre__3E52440B");

                entity.HasOne(d => d.SexoNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.Sexo)
                    .HasConstraintName("FK__Estudiante__Sexo__3F466844");
            });

            modelBuilder.Entity<EstudianteCurso>(entity =>
            {
                entity.HasKey(e => new { e.IdSigerd, e.Curso })
                    .HasName("PK__Estudian__D4BB989FA6FCBB56");

                entity.HasOne(d => d.CursoNavigation)
                    .WithMany(p => p.EstudianteCursos)
                    .HasForeignKey(d => d.Curso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Estudiant__Curso__403A8C7D");

                entity.HasOne(d => d.IdSigerdNavigation)
                    .WithMany(p => p.EstudianteCursos)
                    .HasForeignKey(d => d.IdSigerd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Estudiant__IdSig__412EB0B6");
            });

            modelBuilder.Entity<Modalidad>(entity =>
            {
                entity.HasKey(e => e.IdModalidad)
                    .HasName("PK__Modalida__6A257DAEA6E380E0");

                entity.Property(e => e.NombreModalidad).IsUnicode(false);
            });

            modelBuilder.Entity<Nivel>(entity =>
            {
                entity.HasKey(e => e.IdNivel)
                    .HasName("PK__Nivel__A7F93DECE7DB1318");

                entity.Property(e => e.NombreNivel).IsUnicode(false);
            });

            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.HasKey(e => e.IdProfesor)
                    .HasName("PK__Profesor__C377C3A1DA98D808");

                entity.Property(e => e.ApellidoProfesor).IsUnicode(false);

                entity.Property(e => e.NombreProfesor).IsUnicode(false);
            });

            modelBuilder.Entity<Seccion>(entity =>
            {
                entity.HasKey(e => e.IdSeccion)
                    .HasName("PK__Seccion__CD2B049F00C6E0BF");

                entity.Property(e => e.NombreSeccion).IsUnicode(false);
            });

            modelBuilder.Entity<Sexo>(entity =>
            {
                entity.HasKey(e => e.IdSexo)
                    .HasName("PK__Sexo__A7739FA269EA7B0F");

                entity.Property(e => e.NombreSexo).IsUnicode(false);
            });

            modelBuilder.Entity<Tutor>(entity =>
            {
                entity.HasKey(e => e.IdTutor)
                    .HasName("PK__Tutor__C168D38816047E00");

                entity.Property(e => e.Contacto).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
