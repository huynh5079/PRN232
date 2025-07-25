using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entities;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BorrowRecord> BorrowRecords { get; set; }

    public virtual DbSet<Borrower> Borrowers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=PEBolomadtoDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__Books__3DE0C207DF42DD2D");

            entity.Property(e => e.Author).HasMaxLength(100);
            entity.Property(e => e.Genre).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.AssignedToNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.AssignedTo)
                .HasConstraintName("FK__Books__AssignedT__286302EC");
        });

        modelBuilder.Entity<BorrowRecord>(entity =>
        {
            entity.HasKey(e => e.RecordId).HasName("PK__BorrowRe__FBDF78E9A6AD5993");

            entity.Property(e => e.BorrowDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsReturned).HasDefaultValue(false);

            entity.HasOne(d => d.Book).WithMany(p => p.BorrowRecords)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK__BorrowRec__BookI__2E1BDC42");

            entity.HasOne(d => d.Borrower).WithMany(p => p.BorrowRecords)
                .HasForeignKey(d => d.BorrowerId)
                .HasConstraintName("FK__BorrowRec__Borro__2F10007B");
        });

        modelBuilder.Entity<Borrower>(entity =>
        {
            entity.HasKey(e => e.BorrowerId).HasName("PK__Borrower__568EDB57A51C6F84");

            entity.HasIndex(e => e.Email, "UQ__Borrower__A9D1053433CC7526").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C824A05F8");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534C1F141B9").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
