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

        public virtual DbSet<AnioEscolar> AnioEscolars { get; set; }
        public virtual DbSet<Asignatura> Asignaturas { get; set; }
        public virtual DbSet<CentrosEducativo> CentrosEducativos { get; set; }
        public virtual DbSet<CentrosProfesore> CentrosProfesores { get; set; }
        public virtual DbSet<Condicione> Condiciones { get; set; }
        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<CursosProfesore> CursosProfesores { get; set; }
        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<Distrito> Distritos { get; set; }
        public virtual DbSet<Edade> Edades { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Estudiante> Estudiantes { get; set; }
        public virtual DbSet<EstudiantesTipo> EstudiantesTipos { get; set; }
        public virtual DbSet<FactInscripcion> FactInscripcions { get; set; }
        public virtual DbSet<ModalidadesTipo> ModalidadesTipos { get; set; }
        public virtual DbSet<Municipio> Municipios { get; set; }
        public virtual DbSet<Nivele> Niveles { get; set; }
        public virtual DbSet<Perfile> Perfiles { get; set; }
        public virtual DbSet<PersonalCentro> PersonalCentros { get; set; }
        public virtual DbSet<PersonalDistrito> PersonalDistritos { get; set; }
        public virtual DbSet<Profesore> Profesores { get; set; }
        public virtual DbSet<Provincia> Provincias { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Seccione> Secciones { get; set; }
        public virtual DbSet<Sexo> Sexos { get; set; }
        public virtual DbSet<TipoCentro> TipoCentros { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=DWDistrito0503;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AnioEscolar>(entity =>
            {
                entity.HasKey(e => e.IdAnioEscolar)
                    .HasName("PK__AnioEsco__48B63D2538A5AAA1");

                entity.ToTable("AnioEscolar");

                entity.Property(e => e.Anio).HasMaxLength(20);

                entity.Property(e => e.FechaCreado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificado).HasColumnType("datetime");

                entity.HasOne(d => d.CreadoPorNavigation)
                    .WithMany(p => p.AnioEscolarCreadoPorNavigations)
                    .HasForeignKey(d => d.CreadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CreadoAnioEscolar");

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.AnioEscolars)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("FK_EstadoAnio");

                entity.HasOne(d => d.ModificadoPorNavigation)
                    .WithMany(p => p.AnioEscolarModificadoPorNavigations)
                    .HasForeignKey(d => d.ModificadoPor)
                    .HasConstraintName("FK_ModificadoAnioEscolar");
            });

            modelBuilder.Entity<Asignatura>(entity =>
            {
                entity.HasKey(e => e.IdAsignatura)
                    .HasName("PK__Asignatu__94F174B8796641F2");

                entity.Property(e => e.FechaCreado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificado).HasColumnType("datetime");

                entity.Property(e => e.Nombre).HasMaxLength(255);

                entity.HasOne(d => d.CreadoPorNavigation)
                    .WithMany(p => p.AsignaturaCreadoPorNavigations)
                    .HasForeignKey(d => d.CreadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CreadoAsignatura");

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.Asignaturas)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("FK_EstadoAsignatura");

                entity.HasOne(d => d.ModificadoPorNavigation)
                    .WithMany(p => p.AsignaturaModificadoPorNavigations)
                    .HasForeignKey(d => d.ModificadoPor)
                    .HasConstraintName("FK_ModificadoAsignatura");
            });

            modelBuilder.Entity<CentrosEducativo>(entity =>
            {
                entity.HasKey(e => e.IdCentroEducativo)
                    .HasName("PK__CentrosE__0C73717DE682A4EB");

                entity.Property(e => e.FechaCreado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificado).HasColumnType("datetime");

                entity.Property(e => e.Nombre).HasMaxLength(255);

                entity.HasOne(d => d.CreadoPorNavigation)
                    .WithMany(p => p.CentrosEducativoCreadoPorNavigations)
                    .HasForeignKey(d => d.CreadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CreadoCentro");

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.CentrosEducativos)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("FK_EstadoCentro");

                entity.HasOne(d => d.IdDistritoNavigation)
                    .WithMany(p => p.CentrosEducativos)
                    .HasForeignKey(d => d.IdDistrito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CentroDistrito");

                entity.HasOne(d => d.IdTipoCentroNavigation)
                    .WithMany(p => p.CentrosEducativos)
                    .HasForeignKey(d => d.IdTipoCentro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TipoCentro");

                entity.HasOne(d => d.ModificadoPorNavigation)
                    .WithMany(p => p.CentrosEducativoModificadoPorNavigations)
                    .HasForeignKey(d => d.ModificadoPor)
                    .HasConstraintName("FK_ModificadoCentro");
            });

            modelBuilder.Entity<CentrosProfesore>(entity =>
            {
                entity.HasKey(e => e.IdCentroProf)
                    .HasName("PK__CentrosP__67E456A9F500B2C6");

                entity.Property(e => e.FechaCreado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificado).HasColumnType("datetime");

                entity.HasOne(d => d.CentroNavigation)
                    .WithMany(p => p.CentrosProfesores)
                    .HasForeignKey(d => d.Centro)
                    .HasConstraintName("FK_CentroCentroProf");

                entity.HasOne(d => d.CreadoPorNavigation)
                    .WithMany(p => p.CentrosProfesoreCreadoPorNavigations)
                    .HasForeignKey(d => d.CreadoPor)
                    .HasConstraintName("FK_CreadoPorCentroProf");

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.CentrosProfesores)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("FK_EstadoCentroProf");

                entity.HasOne(d => d.ModificadoPorNavigation)
                    .WithMany(p => p.CentrosProfesoreModificadoPorNavigations)
                    .HasForeignKey(d => d.ModificadoPor)
                    .HasConstraintName("FK_ModificadoPorCentroProf");

                entity.HasOne(d => d.ProfesorNavigation)
                    .WithMany(p => p.CentrosProfesores)
                    .HasForeignKey(d => d.Profesor)
                    .HasConstraintName("FK_ProfCentroProf");
            });

            modelBuilder.Entity<Condicione>(entity =>
            {
                entity.HasKey(e => e.IdCondicion)
                    .HasName("PK__Condicio__7BCB6514CED7B05F");

                entity.Property(e => e.FechaCreado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificado).HasColumnType("datetime");

                entity.Property(e => e.Nombre).HasMaxLength(150);

                entity.HasOne(d => d.CreadoPorNavigation)
                    .WithMany(p => p.CondicioneCreadoPorNavigations)
                    .HasForeignKey(d => d.CreadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CreadoCondiciones");

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.Condiciones)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("FK_EstadoCondiciones");

                entity.HasOne(d => d.ModificadoPorNavigation)
                    .WithMany(p => p.CondicioneModificadoPorNavigations)
                    .HasForeignKey(d => d.ModificadoPor)
                    .HasConstraintName("FK_ModificadoCondiciones");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__Cursos__085F27D6AFB7008C");

                entity.Property(e => e.Nombre).HasMaxLength(255);

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("FK_EstadoCurso");

                entity.HasOne(d => d.IdNivelNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdNivel)
                    .HasConstraintName("FK_CursoNivel");

                entity.HasOne(d => d.IdSeccionNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdSeccion)
                    .HasConstraintName("FK_CursoSeccion");
            });

            modelBuilder.Entity<CursosProfesore>(entity =>
            {
                entity.HasKey(e => e.IdCursoProf)
                    .HasName("PK__CursosPr__398C32F3E518CBC0");

                entity.Property(e => e.FechaCreado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificado).HasColumnType("datetime");

                entity.HasOne(d => d.CentroNavigation)
                    .WithMany(p => p.CursosProfesores)
                    .HasForeignKey(d => d.Centro)
                    .HasConstraintName("FK_CentroCursosProf");

                entity.HasOne(d => d.CreadoPorNavigation)
                    .WithMany(p => p.CursosProfesoreCreadoPorNavigations)
                    .HasForeignKey(d => d.CreadoPor)
                    .HasConstraintName("FK_CreadoPorCursosProf");

                entity.HasOne(d => d.CursoNavigation)
                    .WithMany(p => p.CursosProfesores)
                    .HasForeignKey(d => d.Curso)
                    .HasConstraintName("FK_CursoCursosProf");

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.CursosProfesores)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("FK_EstadoCursosProf");

                entity.HasOne(d => d.ModificadoPorNavigation)
                    .WithMany(p => p.CursosProfesoreModificadoPorNavigations)
                    .HasForeignKey(d => d.ModificadoPor)
                    .HasConstraintName("FK_ModificadoPorCursosProf");

                entity.HasOne(d => d.ProfesorNavigation)
                    .WithMany(p => p.CursosProfesores)
                    .HasForeignKey(d => d.Profesor)
                    .HasConstraintName("FK_ProfCursosProf");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento)
                    .HasName("PK__Departam__787A433DDD03EB05");

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificado).HasColumnType("datetime");

                entity.Property(e => e.Nombre).HasMaxLength(255);

                entity.HasOne(d => d.CreadoPorNavigation)
                    .WithMany(p => p.DepartamentoCreadoPorNavigations)
                    .HasForeignKey(d => d.CreadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CreadoDpto");

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.Departamentos)
                    .HasForeignKey(d => d.Estado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DptoEstado");

                entity.HasOne(d => d.IdCentroNavigation)
                    .WithMany(p => p.Departamentos)
                    .HasForeignKey(d => d.IdCentro)
                    .HasConstraintName("FK_CentrosDpto");

                entity.HasOne(d => d.ModificadoPorNavigation)
                    .WithMany(p => p.DepartamentoModificadoPorNavigations)
                    .HasForeignKey(d => d.ModificadoPor)
                    .HasConstraintName("FK_ModificadoDpto");
            });

            modelBuilder.Entity<Distrito>(entity =>
            {
                entity.HasKey(e => e.IdDistrito)
                    .HasName("PK__Distrito__DE8EED59B38C2C0C");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificado).HasColumnType("datetime");

                entity.HasOne(d => d.CreadoPorNavigation)
                    .WithMany(p => p.DistritoCreadoPorNavigations)
                    .HasForeignKey(d => d.CreadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CreadoDistrito");

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.Distritos)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("FK_EstadoDistrito");

                entity.HasOne(d => d.IdMunicipioNavigation)
                    .WithMany(p => p.Distritos)
                    .HasForeignKey(d => d.IdMunicipio)
                    .HasConstraintName("FK_MunicipioDistrito");

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Distritos)
                    .HasForeignKey(d => d.IdProvincia)
                    .HasConstraintName("FK_ProvinciaDistrito");

                entity.HasOne(d => d.ModificadoPorNavigation)
                    .WithMany(p => p.DistritoModificadoPorNavigations)
                    .HasForeignKey(d => d.ModificadoPor)
                    .HasConstraintName("FK_ModificadoDistrito");
            });

            modelBuilder.Entity<Edade>(entity =>
            {
                entity.HasKey(e => e.IdEdad)
                    .HasName("PK__Edades__0BBCEBD462CDCF70");

                entity.Property(e => e.Edad)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.RangoEdad).HasMaxLength(5);
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__Estados__FBB0EDC18F158955");

                entity.Property(e => e.FechaCreado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificado).HasColumnType("datetime");

                entity.Property(e => e.Nombre).HasMaxLength(150);

                entity.HasOne(d => d.CreadoPorNavigation)
                    .WithMany(p => p.EstadoCreadoPorNavigations)
                    .HasForeignKey(d => d.CreadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CreadoEstado");

                entity.HasOne(d => d.ModificadoPorNavigation)
                    .WithMany(p => p.EstadoModificadoPorNavigations)
                    .HasForeignKey(d => d.ModificadoPor)
                    .HasConstraintName("FK_ModificadoEstado");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.IdEstudiante)
                    .HasName("PK__Estudian__B5007C242BC8F76F");

                entity.Property(e => e.Apellido).HasMaxLength(255);

                entity.Property(e => e.FechaCreado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificado).HasColumnType("datetime");

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.Idsigerd)
                    .HasMaxLength(100)
                    .HasColumnName("IDSigerd");

                entity.Property(e => e.Nombre).HasMaxLength(255);

                entity.HasOne(d => d.CentroNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.Centro)
                    .HasConstraintName("FK_EstCentro");

                entity.HasOne(d => d.CreadoPorNavigation)
                    .WithMany(p => p.EstudianteCreadoPorNavigations)
                    .HasForeignKey(d => d.CreadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CreadoEstudiante");

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("FK_EstadoEstudiantes");

                entity.HasOne(d => d.ModificadoPorNavigation)
                    .WithMany(p => p.EstudianteModificadoPorNavigations)
                    .HasForeignKey(d => d.ModificadoPor)
                    .HasConstraintName("FK_ModificadoEstudiante");

                entity.HasOne(d => d.SexoNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.Sexo)
                    .HasConstraintName("FK_SexoEstudiante");
            });

            modelBuilder.Entity<EstudiantesTipo>(entity =>
            {
                entity.HasKey(e => e.IdEstudianteTipo)
                    .HasName("PK__Estudian__E279F0BBB5D109B4");

                entity.ToTable("EstudiantesTipo");

                entity.Property(e => e.Nombre).HasMaxLength(150);

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.EstudiantesTipos)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("FK_EstadoEstudiantesTipo");
            });

            modelBuilder.Entity<FactInscripcion>(entity =>
            {
                entity.HasKey(e => e.IdFactInscripcion)
                    .HasName("PK__FactInsc__854BD311EC6C9650");

                entity.ToTable("FactInscripcion");

                entity.Property(e => e.FechaCreado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificado).HasColumnType("datetime");

                entity.HasOne(d => d.CreadoPorNavigation)
                    .WithMany(p => p.FactInscripcionCreadoPorNavigations)
                    .HasForeignKey(d => d.CreadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CreadoInscripcion");

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.FactInscripcions)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("FK_EstadoInscripcion");

                entity.HasOne(d => d.IdAnioEscolarNavigation)
                    .WithMany(p => p.FactInscripcions)
                    .HasForeignKey(d => d.IdAnioEscolar)
                    .HasConstraintName("FK_AnioEscolar");

                entity.HasOne(d => d.IdCentroNavigation)
                    .WithMany(p => p.FactInscripcions)
                    .HasForeignKey(d => d.IdCentro)
                    .HasConstraintName("FK_InscripcionCentro");

                entity.HasOne(d => d.IdCondicionNavigation)
                    .WithMany(p => p.FactInscripcions)
                    .HasForeignKey(d => d.IdCondicion)
                    .HasConstraintName("FK_Condicion");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.FactInscripcions)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK_Curso");

                entity.HasOne(d => d.IdEdadNavigation)
                    .WithMany(p => p.FactInscripcions)
                    .HasForeignKey(d => d.IdEdad)
                    .HasConstraintName("FK_Edad");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.FactInscripcions)
                    .HasForeignKey(d => d.IdEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Estudiante");

                entity.HasOne(d => d.IdEstudianteTipoNavigation)
                    .WithMany(p => p.FactInscripcions)
                    .HasForeignKey(d => d.IdEstudianteTipo)
                    .HasConstraintName("FK_EstudianteTipo");

                entity.HasOne(d => d.IdModalidadTipoNavigation)
                    .WithMany(p => p.FactInscripcions)
                    .HasForeignKey(d => d.IdModalidadTipo)
                    .HasConstraintName("FK_ModalidadTipo");

                entity.HasOne(d => d.IdProfesorNavigation)
                    .WithMany(p => p.FactInscripcions)
                    .HasForeignKey(d => d.IdProfesor)
                    .HasConstraintName("FK_Profesor");

                entity.HasOne(d => d.ModificadoPorNavigation)
                    .WithMany(p => p.FactInscripcionModificadoPorNavigations)
                    .HasForeignKey(d => d.ModificadoPor)
                    .HasConstraintName("FK_ModificadoInscripcion");
            });

            modelBuilder.Entity<ModalidadesTipo>(entity =>
            {
                entity.HasKey(e => e.IdModalidadTipo)
                    .HasName("PK__Modalida__C219930D2A04D80E");

                entity.ToTable("ModalidadesTipo");

                entity.Property(e => e.Nombre).HasMaxLength(150);

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.ModalidadesTipos)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("FK_EstadoModalidadesTipo");
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.HasKey(e => e.IdMunicipio)
                    .HasName("PK__Municipi__6100597884125475");

                entity.Property(e => e.Nombre).HasMaxLength(255);

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Municipios)
                    .HasForeignKey(d => d.IdProvincia)
                    .HasConstraintName("FK_ProvinciaMunicipio");
            });

            modelBuilder.Entity<Nivele>(entity =>
            {
                entity.HasKey(e => e.IdNivel)
                    .HasName("PK__Niveles__A7F93DECB9336BBA");

                entity.Property(e => e.Nombre).HasMaxLength(255);

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.Niveles)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("FK_EstadoNiveles");
            });

            modelBuilder.Entity<Perfile>(entity =>
            {
                entity.HasKey(e => e.IdPerfil)
                    .HasName("PK__Perfiles__C7BD5CC15F2BAC44");

                entity.Property(e => e.FechaCreado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificado).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Rol).HasColumnName("rol");

                entity.HasOne(d => d.CreadoPorNavigation)
                    .WithMany(p => p.PerfileCreadoPorNavigations)
                    .HasForeignKey(d => d.CreadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CreadoPerfil");

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.Perfiles)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("FK_EstadoPerfiles");

                entity.HasOne(d => d.ModificadoPorNavigation)
                    .WithMany(p => p.PerfileModificadoPorNavigations)
                    .HasForeignKey(d => d.ModificadoPor)
                    .HasConstraintName("FK_ModificadoPerfil");

                entity.HasOne(d => d.RolNavigation)
                    .WithMany(p => p.Perfiles)
                    .HasForeignKey(d => d.Rol)
                    .HasConstraintName("FK_RolPerfil");
            });

            modelBuilder.Entity<PersonalCentro>(entity =>
            {
                entity.HasKey(e => e.IdPersonalCentro)
                    .HasName("PK__Personal__53273D9E0CA587AC");

                entity.ToTable("PersonalCentro");

                entity.Property(e => e.Apellido).HasMaxLength(255);

                entity.Property(e => e.Cedula).HasMaxLength(11);

                entity.Property(e => e.FechaCreado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificado).HasColumnType("datetime");

                entity.Property(e => e.Nombre).HasMaxLength(255);

                entity.HasOne(d => d.CreadoPorNavigation)
                    .WithMany(p => p.PersonalCentroCreadoPorNavigations)
                    .HasForeignKey(d => d.CreadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CreadoPersonalC");

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.PersonalCentros)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("FK_EstadoPersonCentro");

                entity.HasOne(d => d.IdCentroNavigation)
                    .WithMany(p => p.PersonalCentros)
                    .HasForeignKey(d => d.IdCentro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonalCentro");

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.PersonalCentros)
                    .HasForeignKey(d => d.IdDepartamento)
                    .HasConstraintName("FK_DeptoCentro");

                entity.HasOne(d => d.ModificadoPorNavigation)
                    .WithMany(p => p.PersonalCentroModificadoPorNavigations)
                    .HasForeignKey(d => d.ModificadoPor)
                    .HasConstraintName("FK_ModificadoPersonalC");
            });

            modelBuilder.Entity<PersonalDistrito>(entity =>
            {
                entity.HasKey(e => e.IdPersonalDistrito)
                    .HasName("PK__Personal__078F5842E782113E");

                entity.ToTable("PersonalDistrito");

                entity.Property(e => e.Apellido).HasMaxLength(255);

                entity.Property(e => e.Cedula).HasMaxLength(11);

                entity.Property(e => e.FechaCreado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificado).HasColumnType("datetime");

                entity.Property(e => e.Nombre).HasMaxLength(255);

                entity.HasOne(d => d.CreadoPorNavigation)
                    .WithMany(p => p.PersonalDistritoCreadoPorNavigations)
                    .HasForeignKey(d => d.CreadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CreadoPersonalD");

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.PersonalDistritos)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("FK_EstadoPersonDistrito");

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.PersonalDistritos)
                    .HasForeignKey(d => d.IdDepartamento)
                    .HasConstraintName("FK_DeptoDistrito");

                entity.HasOne(d => d.IdDistritoNavigation)
                    .WithMany(p => p.PersonalDistritos)
                    .HasForeignKey(d => d.IdDistrito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonalDistrito");

                entity.HasOne(d => d.ModificadoPorNavigation)
                    .WithMany(p => p.PersonalDistritoModificadoPorNavigations)
                    .HasForeignKey(d => d.ModificadoPor)
                    .HasConstraintName("FK_ModificadoPersonalD");
            });

            modelBuilder.Entity<Profesore>(entity =>
            {
                entity.HasKey(e => e.IdProfesor)
                    .HasName("PK__Profesor__C377C3A1F7D6B389");

                entity.Property(e => e.Apellido).HasMaxLength(255);

                entity.Property(e => e.Cedula).HasMaxLength(11);

                entity.Property(e => e.FechaCreado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificado).HasColumnType("datetime");

                entity.Property(e => e.Nombre).HasMaxLength(255);

                entity.HasOne(d => d.CreadoPorNavigation)
                    .WithMany(p => p.ProfesoreCreadoPorNavigations)
                    .HasForeignKey(d => d.CreadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CreadoProfesor");

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.Profesores)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("FK_EstadoProfesores");

                entity.HasOne(d => d.IdAsignaturaNavigation)
                    .WithMany(p => p.Profesores)
                    .HasForeignKey(d => d.IdAsignatura)
                    .HasConstraintName("FK_Area");

                entity.HasOne(d => d.IdCentroNavigation)
                    .WithMany(p => p.Profesores)
                    .HasForeignKey(d => d.IdCentro)
                    .HasConstraintName("FK_ProfesorDistrito");

                entity.HasOne(d => d.ModificadoPorNavigation)
                    .WithMany(p => p.ProfesoreModificadoPorNavigations)
                    .HasForeignKey(d => d.ModificadoPor)
                    .HasConstraintName("FK_ModificadoProfesor");
            });

            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.HasKey(e => e.IdProvincia)
                    .HasName("PK__Provinci__EED744552FC9B067");

                entity.Property(e => e.Nombre).HasMaxLength(255);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Roles__2A49584C297DC450");

                entity.Property(e => e.FechaCreado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificado).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.CreadoPorNavigation)
                    .WithMany(p => p.RoleCreadoPorNavigations)
                    .HasForeignKey(d => d.CreadoPor)
                    .HasConstraintName("FK_CreadoPorRoles");

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("FK_EstadoRoles");

                entity.HasOne(d => d.ModificadoPorNavigation)
                    .WithMany(p => p.RoleModificadoPorNavigations)
                    .HasForeignKey(d => d.ModificadoPor)
                    .HasConstraintName("FK_ModificadoPorRoles");
            });

            modelBuilder.Entity<Seccione>(entity =>
            {
                entity.HasKey(e => e.IdSeccion)
                    .HasName("PK__Seccione__CD2B049F0B51609B");

                entity.Property(e => e.Nombre).HasMaxLength(255);
            });

            modelBuilder.Entity<Sexo>(entity =>
            {
                entity.HasKey(e => e.IdSexo)
                    .HasName("PK__Sexo__A7739FA260A327CA");

                entity.ToTable("Sexo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TipoCentro>(entity =>
            {
                entity.HasKey(e => e.IdTipoCentro)
                    .HasName("PK__TipoCent__B539A383594A372D");

                entity.ToTable("TipoCentro");

                entity.Property(e => e.Nombre).HasMaxLength(255);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__CA04062BE37AC692");

                entity.ToTable("TipoUsuario");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.TipoUsuarios)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("FK_TipoUsuarioEstado");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__5B65BF979F9C27F2");

                entity.Property(e => e.Contrasena).HasMaxLength(255);

                entity.Property(e => e.Correo).HasMaxLength(255);

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificado).HasColumnType("datetime");

                entity.Property(e => e.NombreUsuario).HasMaxLength(255);

                entity.Property(e => e.Perfil).HasColumnName("perfil");

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("FK_EstadoUsuarios");

                entity.HasOne(d => d.PerfilNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Perfil)
                    .HasConstraintName("FK_PerfilUsuario");

                entity.HasOne(d => d.TipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.TipoUsuario)
                    .HasConstraintName("FK_TipoUsuarios");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
