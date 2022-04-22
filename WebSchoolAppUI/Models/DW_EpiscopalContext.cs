using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class DW_EpiscopalContext : DbContext
    {
        public DW_EpiscopalContext()
        {
        }

        public DW_EpiscopalContext(DbContextOptions<DW_EpiscopalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Age> Ages { get; set; }
        public virtual DbSet<Condition> Conditions { get; set; }
        public virtual DbSet<FactSignOn> FactSignOns { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<FilesDetail> FilesDetails { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<ModalitiesType> ModalitiesTypes { get; set; }
        public virtual DbSet<SchoolYear> SchoolYears { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentsType> StudentsTypes { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Time> Times { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-151NMHQA;Initial Catalog=DW_Episcopal;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Age>(entity =>
            {
                entity.HasKey(e => e.IdAge)
                    .HasName("PK__Ages__0E2BC6CD5E063BC1");

                entity.Property(e => e.Range).HasMaxLength(5);
            });

            modelBuilder.Entity<Condition>(entity =>
            {
                entity.HasKey(e => e.IdCondition)
                    .HasName("PK__Conditio__4C46691159D9E134");

                entity.Property(e => e.Name).HasMaxLength(150);
            });

            modelBuilder.Entity<FactSignOn>(entity =>
            {
                entity.HasKey(e => e.IdFactSignOn)
                    .HasName("PK__FactSign__1892CAAC61941D77");

                entity.ToTable("FactSignOn");

                entity.Property(e => e.IdDate).HasMaxLength(10);

                entity.HasOne(d => d.IdAgeNavigation)
                    .WithMany(p => p.FactSignOns)
                    .HasForeignKey(d => d.IdAge)
                    .HasConstraintName("FK_Age");

                entity.HasOne(d => d.IdConditionNavigation)
                    .WithMany(p => p.FactSignOns)
                    .HasForeignKey(d => d.IdCondition)
                    .HasConstraintName("FK_Condition");

                entity.HasOne(d => d.IdDateNavigation)
                    .WithMany(p => p.FactSignOns)
                    .HasForeignKey(d => d.IdDate)
                    .HasConstraintName("FK_Date");

                entity.HasOne(d => d.IdGradeNavigation)
                    .WithMany(p => p.FactSignOns)
                    .HasForeignKey(d => d.IdGrade)
                    .HasConstraintName("FK_Grade");

                entity.HasOne(d => d.IdModalityTypeNavigation)
                    .WithMany(p => p.FactSignOns)
                    .HasForeignKey(d => d.IdModalityType)
                    .HasConstraintName("FK_ModalityType");

                entity.HasOne(d => d.IdSchoolYearNavigation)
                    .WithMany(p => p.FactSignOns)
                    .HasForeignKey(d => d.IdSchoolYear)
                    .HasConstraintName("FK_SchoolYear");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.FactSignOns)
                    .HasForeignKey(d => d.IdStudent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student");

                entity.HasOne(d => d.IdStudentTypeNavigation)
                    .WithMany(p => p.FactSignOns)
                    .HasForeignKey(d => d.IdStudentType)
                    .HasConstraintName("FK_StudentType");

                entity.HasOne(d => d.IdTeacherNavigation)
                    .WithMany(p => p.FactSignOns)
                    .HasForeignKey(d => d.IdTeacher)
                    .HasConstraintName("FK_Teacher");
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.HasKey(e => e.IdFile)
                    .HasName("PK__Files__01E644E17F8CAAAC");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.FileName).HasMaxLength(150);

                entity.Property(e => e.Route).HasMaxLength(255);

                entity.HasOne(d => d.IdSchoolYearNavigation)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.IdSchoolYear)
                    .HasConstraintName("FK_Files_SchoolYear");

                entity.HasOne(d => d.IdStateNavigation)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.IdState)
                    .HasConstraintName("FK_State");
            });

            modelBuilder.Entity<FilesDetail>(entity =>
            {
                entity.HasKey(e => e.IdFileDetail)
                    .HasName("PK__FilesDet__102C2CE897F4BF89");

                entity.Property(e => e.Comment).HasMaxLength(255);

                entity.Property(e => e.Condition).HasMaxLength(255);

                entity.Property(e => e.Course).HasMaxLength(255);

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Idsigerd)
                    .HasMaxLength(200)
                    .HasColumnName("IDSigerd");

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.Modality).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.Sex)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.State).HasMaxLength(150);

                entity.Property(e => e.StudentId).HasMaxLength(50);

                entity.HasOne(d => d.IdStateNavigation)
                    .WithMany(p => p.FilesDetails)
                    .HasForeignKey(d => d.IdState)
                    .HasConstraintName("FK_FileDetailState");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.HasKey(e => e.IdGrade)
                    .HasName("PK__Grades__393DFCB63ABF1F92");

                entity.Property(e => e.Level).HasMaxLength(150);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Section).HasMaxLength(255);
            });

            modelBuilder.Entity<ModalitiesType>(entity =>
            {
                entity.HasKey(e => e.IdModalityType)
                    .HasName("PK__Modaliti__6EFAE9E4741374FD");

                entity.ToTable("ModalitiesType");

                entity.Property(e => e.Name).HasMaxLength(150);
            });

            modelBuilder.Entity<SchoolYear>(entity =>
            {
                entity.HasKey(e => e.IdSchoolYear)
                    .HasName("PK__SchoolYe__DD7E231384DD0016");

                entity.ToTable("SchoolYear");

                entity.Property(e => e.Year).HasMaxLength(20);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => e.IdState)
                    .HasName("PK__States__2E1972BC2FF44968");

                entity.Property(e => e.Name).HasMaxLength(150);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.IdStudent)
                    .HasName("PK__Students__61B351041CF48B02");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Idsigerd)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("IDSigerd");

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Sex)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<StudentsType>(entity =>
            {
                entity.HasKey(e => e.IdStudentType)
                    .HasName("PK__Students__245A001EE63D2F95");

                entity.ToTable("StudentsType");

                entity.Property(e => e.Name).HasMaxLength(150);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.IdTeacher)
                    .HasName("PK__Teachers__F515A7219E90226A");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Time>(entity =>
            {
                entity.HasKey(e => e.IdDate)
                    .HasName("PK__Time__F298CC899659D8CF");

                entity.ToTable("Time");

                entity.Property(e => e.IdDate).HasMaxLength(10);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Day).HasMaxLength(2);

                entity.Property(e => e.Month).HasMaxLength(2);

                entity.Property(e => e.Year).HasMaxLength(4);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
