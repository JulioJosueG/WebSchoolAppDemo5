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
        public virtual DbSet<Archivo> Archivos { get; set; }
        public virtual DbSet<ArchivosDetalle> ArchivosDetalles { get; set; }
        public virtual DbSet<Asignatura> Asignaturas { get; set; }
        public virtual DbSet<CentrosEducativo> CentrosEducativos { get; set; }
        public virtual DbSet<Condicione> Condiciones { get; set; }
        public virtual DbSet<Curso> Cursos { get; set; }
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
        public virtual DbSet<PersonalCentro> PersonalCentros { get; set; }
        public virtual DbSet<PersonalDistrito> PersonalDistritos { get; set; }
        public virtual DbSet<Profesore> Profesores { get; set; }
        public virtual DbSet<Provincia> Provincias { get; set; }
        public virtual DbSet<Seccione> Secciones { get; set; }
        public virtual DbSet<Tiempo> Tiempos { get; set; }
        public virtual DbSet<TipoCentro> TipoCentros { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<ValidacionDatum> ValidacionData { get; set; }

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
                    .HasName("PK__AnioEsco__48B63D2515F4CB74");

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

                entity.HasOne(d => d.ModificadoPorNavigation)
                    .WithMany(p => p.AnioEscolarModificadoPorNavigations)
                    .HasForeignKey(d => d.ModificadoPor)
                    .HasConstraintName("FK_ModificadoAnioEscolar");
            });

            modelBuilder.Entity<Archivo>(entity =>
            {
                entity.HasKey(e => e.IdArchivo)
                    .HasName("PK__Archivos__26B921115762C772");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.NombreArchivo).HasMaxLength(150);

                entity.Property(e => e.Ruta).HasMaxLength(255);

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Archivos)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("FK_FileEstado");
            });

            modelBuilder.Entity<ArchivosDetalle>(entity =>
            {
                entity.HasKey(e => e.IdArchivoDetalle)
                    .HasName("PK__Archivos__E7FC5354D87CED92");

                entity.ToTable("ArchivosDetalle");

                entity.Property(e => e.Condicion).HasMaxLength(255);

                entity.Property(e => e.Curso).HasMaxLength(255);

                entity.Property(e => e.Estado).HasMaxLength(150);

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.Modalidad).HasMaxLength(255);

                entity.Property(e => e.Nombre).HasMaxLength(150);

                entity.HasOne(d => d.IdArchivoNavigation)
                    .WithMany(p => p.ArchivosDetalles)
                    .HasForeignKey(d => d.IdArchivo)
                    .HasConstraintName("FK_Archivo");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.ArchivosDetalles)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("FK_ArchivoDetalleEstado");
            });

            modelBuilder.Entity<Asignatura>(entity =>
            {
                entity.HasKey(e => e.IdAsignatura)
                    .HasName("PK__Asignatu__94F174B86FD149D4");

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

                entity.HasOne(d => d.ModificadoPorNavigation)
                    .WithMany(p => p.AsignaturaModificadoPorNavigations)
                    .HasForeignKey(d => d.ModificadoPor)
                    .HasConstraintName("FK_ModificadoAsignatura");
            });

            modelBuilder.Entity<CentrosEducativo>(entity =>
            {
                entity.HasKey(e => e.IdCentroEducativo)
                    .HasName("PK__CentrosE__0C73717D49C46517");

                entity.Property(e => e.FechaCreado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificado).HasColumnType("datetime");

                entity.Property(e => e.Nombre).HasMaxLength(5);

                entity.HasOne(d => d.CreadoPorNavigation)
                    .WithMany(p => p.CentrosEducativoCreadoPorNavigations)
                    .HasForeignKey(d => d.CreadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CreadoCentro");

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

            modelBuilder.Entity<Condicione>(entity =>
            {
                entity.HasKey(e => e.IdCondicion)
                    .HasName("PK__Condicio__7BCB65142C7D29E8");

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

                entity.HasOne(d => d.ModificadoPorNavigation)
                    .WithMany(p => p.CondicioneModificadoPorNavigations)
                    .HasForeignKey(d => d.ModificadoPor)
                    .HasConstraintName("FK_ModificadoCondiciones");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__Cursos__085F27D60B425404");

                entity.Property(e => e.Nombre).HasMaxLength(255);

                entity.HasOne(d => d.IdNivelNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdNivel)
                    .HasConstraintName("FK_CursoNivel");

                entity.HasOne(d => d.IdSeccionNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdSeccion)
                    .HasConstraintName("FK_CursoSeccion");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento)
                    .HasName("PK__Departam__787A433D5E0B182F");

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

                entity.HasOne(d => d.IdDistritoNavigation)
                    .WithMany(p => p.Departamentos)
                    .HasForeignKey(d => d.IdDistrito)
                    .HasConstraintName("FK_DistritoDpto");

                entity.HasOne(d => d.ModificadoPorNavigation)
                    .WithMany(p => p.DepartamentoModificadoPorNavigations)
                    .HasForeignKey(d => d.ModificadoPor)
                    .HasConstraintName("FK_ModificadoDpto");
            });

            modelBuilder.Entity<Distrito>(entity =>
            {
                entity.HasKey(e => e.IdDistrito)
                    .HasName("PK__Distrito__DE8EED59C79218A3");

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
                    .HasName("PK__Edades__0BBCEBD43D360B6B");

                entity.Property(e => e.Edad)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.RangoEdad).HasMaxLength(5);
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__Estados__FBB0EDC1AB800A0F");

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
                    .HasName("PK__Estudian__B5007C240CB48C18");

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

                entity.Property(e => e.Sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.CreadoPorNavigation)
                    .WithMany(p => p.EstudianteCreadoPorNavigations)
                    .HasForeignKey(d => d.CreadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CreadoEstudiante");

                entity.HasOne(d => d.ModificadoPorNavigation)
                    .WithMany(p => p.EstudianteModificadoPorNavigations)
                    .HasForeignKey(d => d.ModificadoPor)
                    .HasConstraintName("FK_ModificadoEstudiante");
            });

            modelBuilder.Entity<EstudiantesTipo>(entity =>
            {
                entity.HasKey(e => e.IdEstudianteTipo)
                    .HasName("PK__Estudian__E279F0BB98E10DB3");

                entity.ToTable("EstudiantesTipo");

                entity.Property(e => e.Nombre).HasMaxLength(150);
            });

            modelBuilder.Entity<FactInscripcion>(entity =>
            {
                entity.HasKey(e => e.IdFactInscripcion)
                    .HasName("PK__FactInsc__854BD311669E5312");

                entity.ToTable("FactInscripcion");

                entity.Property(e => e.FechaCreado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificado).HasColumnType("datetime");

                entity.Property(e => e.IdFecha).HasMaxLength(10);

                entity.HasOne(d => d.CreadoPorNavigation)
                    .WithMany(p => p.FactInscripcionCreadoPorNavigations)
                    .HasForeignKey(d => d.CreadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CreadoInscripcion");

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

                entity.HasOne(d => d.IdFechaNavigation)
                    .WithMany(p => p.FactInscripcions)
                    .HasForeignKey(d => d.IdFecha)
                    .HasConstraintName("FK_Fecha");

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
                    .HasName("PK__Modalida__C219930D5E7E2141");

                entity.ToTable("ModalidadesTipo");

                entity.Property(e => e.Nombre).HasMaxLength(150);
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.HasKey(e => e.IdMunicipio)
                    .HasName("PK__Municipi__61005978A316E83C");

                entity.Property(e => e.Nombre).HasMaxLength(255);

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Municipios)
                    .HasForeignKey(d => d.IdProvincia)
                    .HasConstraintName("FK_ProvinciaMunicipio");
            });

            modelBuilder.Entity<Nivele>(entity =>
            {
                entity.HasKey(e => e.IdNivel)
                    .HasName("PK__Niveles__A7F93DEC0C46BC40");

                entity.Property(e => e.Nombre).HasMaxLength(255);
            });

            modelBuilder.Entity<PersonalCentro>(entity =>
            {
                entity.HasKey(e => e.IdPersonalCentro)
                    .HasName("PK__Personal__53273D9E1EA97028");

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
                    .HasName("PK__Personal__078F58427C6BB63B");

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
                    .HasName("PK__Profesor__C377C3A17FF642C9");

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
                    .HasName("PK__Provinci__EED7445569F20C2F");

                entity.Property(e => e.Nombre).HasMaxLength(255);
            });

            modelBuilder.Entity<Seccione>(entity =>
            {
                entity.HasKey(e => e.IdSeccion)
                    .HasName("PK__Seccione__CD2B049FBF2AF033");

                entity.Property(e => e.Nombre).HasMaxLength(255);
            });

            modelBuilder.Entity<Tiempo>(entity =>
            {
                entity.HasKey(e => e.IdFecha)
                    .HasName("PK__Tiempo__8D0F205AEBF35EFD");

                entity.ToTable("Tiempo");

                entity.Property(e => e.IdFecha).HasMaxLength(10);

                entity.Property(e => e.Anio).HasMaxLength(4);

                entity.Property(e => e.Dia).HasMaxLength(2);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.FechaCreado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificado).HasColumnType("datetime");

                entity.Property(e => e.Mes).HasMaxLength(2);

                entity.HasOne(d => d.CreadoPorNavigation)
                    .WithMany(p => p.TiempoCreadoPorNavigations)
                    .HasForeignKey(d => d.CreadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CreadoTiempo");

                entity.HasOne(d => d.ModificadoPorNavigation)
                    .WithMany(p => p.TiempoModificadoPorNavigations)
                    .HasForeignKey(d => d.ModificadoPor)
                    .HasConstraintName("FK_ModificadoTiempo");
            });

            modelBuilder.Entity<TipoCentro>(entity =>
            {
                entity.HasKey(e => e.IdTipoCentro)
                    .HasName("PK__TipoCent__B539A38300B33924");

                entity.ToTable("TipoCentro");

                entity.Property(e => e.Nombre).HasMaxLength(255);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__5B65BF97B38B9E29");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.FechaCreado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificado).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ValidacionDatum>(entity =>
            {
                entity.HasKey(e => e.IdValidacion)
                    .HasName("PK__Validaci__5407AA74E6AFC4A3");

                entity.Property(e => e.Comment).HasMaxLength(255);

                entity.HasOne(d => d.IdArchivoNavigation)
                    .WithMany(p => p.ValidacionData)
                    .HasForeignKey(d => d.IdArchivo)
                    .HasConstraintName("FK_FileValidate");

                entity.HasOne(d => d.IdArchivoDetalleNavigation)
                    .WithMany(p => p.ValidacionData)
                    .HasForeignKey(d => d.IdArchivoDetalle)
                    .HasConstraintName("FK_ArchivoDetValidate");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.ValidacionData)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("FK_EstadoValidate");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
