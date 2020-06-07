using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CadenzApp.Models.DB
{
    public partial class CadenzAppContext : DbContext
    {
        public CadenzAppContext()
        {
        }

        public CadenzAppContext(DbContextOptions<CadenzAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MasterFile> MasterFile { get; set; }
        public virtual DbSet<MasterInstruments> MasterInstruments { get; set; }
        public virtual DbSet<MasterStudent> MasterStudent { get; set; }
        public virtual DbSet<MasterTask> MasterTask { get; set; }
        public virtual DbSet<MasterTaskStatus> MasterTaskStatus { get; set; }
        public virtual DbSet<MasterUserGroup> MasterUserGroup { get; set; }
        public virtual DbSet<MasterUsers> MasterUsers { get; set; }
        public virtual DbSet<PracticeLog> PracticeLog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=CadenzApp;Trusted_Connection=True;user id=sa;password=P@ssw0rd;");
                //optionsBuilder.UseSqlServer("Server=cadenzapp.database.windows.net;Database=CadenzAppDB;Trusted_Connection=False;Encrypt=True;user id=cadenzapp;password=P@ssw0rd;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MasterFile>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");
            });

            modelBuilder.Entity<MasterInstruments>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");
            });

            modelBuilder.Entity<MasterStudent>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.InstrumentId).HasColumnName("InstrumentID");

                entity.Property(e => e.JoinDate).HasColumnType("date");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.TutorId).HasColumnName("TutorID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<MasterTask>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.DateEnd).HasColumnType("date");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.TutorId).HasColumnName("TutorID");

                entity.Property(e => e.Type)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("T = Tutorial, H = Homework");
            });

            modelBuilder.Entity<MasterTaskStatus>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");
            });

            modelBuilder.Entity<MasterUserGroup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");
            });

            modelBuilder.Entity<MasterUsers>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("M = Male, F = Female, O = Other");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.UserGroupId).HasColumnName("UserGroupID");
            });

            modelBuilder.Entity<PracticeLog>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.Date })
                    .HasName("PK_MasterPracticeLog");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.InstrumentID).HasColumnName("InstrumentID");

                entity.Property(e => e.PracticeHours).HasColumnType("numeric(4, 2)");

                entity.Property(e => e.UpdatedDate).HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
