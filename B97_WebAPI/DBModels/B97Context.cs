using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace B97_WebAPI.DBModels;

public partial class B97Context : DbContext
{
    public B97Context()
    {
    }

    public B97Context(DbContextOptions<B97Context> options)
        : base(options)
    {
    }

    public virtual DbSet<AuditB97> AuditB97s { get; set; }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<ViewStudentCountBranch> ViewStudentCountBranches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LP002212\\SQLEXPRESS;Database=B97;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuditB97>(entity =>
        {
            entity.HasKey(e => e.AuditId).HasName("PK__Audit_B9__43D17399B514C094");

            entity.ToTable("Audit_B97");

            entity.Property(e => e.AuditId).HasColumnName("auditId");
            entity.Property(e => e.AuditLog)
                .IsUnicode(false)
                .HasColumnName("auditLog");
            entity.Property(e => e.AuditedOn)
                .HasColumnType("datetime")
                .HasColumnName("auditedOn");
        });

        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasKey(e => e.BranchId).HasName("PK__Branch__A1682FC5DAF1C9D9");

            entity.ToTable("Branch");

            entity.Property(e => e.BranchCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.BranchName)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.GenderId).HasName("PK__Gender__4E24E8170B7DD663");

            entity.ToTable("Gender");

            entity.Property(e => e.GenderId).HasColumnName("GenderID");
            entity.Property(e => e.GenderName)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52B9973AD754D");

            entity.ToTable("Student", tb =>
                {
                    tb.HasTrigger("tri_Student");
                    tb.HasTrigger("tri_Student_Delete");
                    tb.HasTrigger("tri_Student_update");
                });

            entity.HasIndex(e => new { e.StudentName, e.StudentDateofBirth, e.GenderId }, "idx_stnamedobgender");

            entity.Property(e => e.StudentDateofBirth).HasColumnType("datetime");
            entity.Property(e => e.StudentName)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.Branch).WithMany(p => p.Students)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK__Student__BranchI__3F466844");

            entity.HasOne(d => d.Gender).WithMany(p => p.Students)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK__Student__GenderI__49C3F6B7");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__CB9A1CFF4E6891BC");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.Password)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("userEmail");
            entity.Property(e => e.UserName)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("userName");
        });

        modelBuilder.Entity<ViewStudentCountBranch>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("view_Student_Count_Branch");

            entity.Property(e => e.BranchName)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
