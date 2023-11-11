using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace works.Models;

public partial class WorkContext : DbContext
{
    public WorkContext()
    {
    }

    public WorkContext(DbContextOptions<WorkContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CustomerDetail> CustomerDetails { get; set; }

    public virtual DbSet<LoginDetail> LoginDetails { get; set; }

    public virtual DbSet<Vegetable> Vegetables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-K3S4HJSA\\SQLEXPRESS; Database=work; Integrated Security=True; Encrypt=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerDetail>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__customer__A4AE64D8EA2E0FDA");

            entity.ToTable("customerDetails");

            entity.HasOne(d => d.LoginDetails).WithMany(p => p.CustomerDetails)
                .HasForeignKey(d => d.LoginDetailsId)
                .HasConstraintName("FK__customerD__Login__02FC7413");

            entity.HasOne(d => d.Vegetable).WithMany(p => p.CustomerDetails)
                .HasForeignKey(d => d.VegetableId)
                .HasConstraintName("FK__customerD__Veget__03F0984C");
        });

        modelBuilder.Entity<LoginDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LoginDet__3213E83FDBACCEF4");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LoginEmail)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.LoginPassWord)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Vegetable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__vegetabl__3213E83F74C4BE02");

            entity.ToTable("vegetable");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.VegetablesName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("vegetables_Name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
