using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SE1635_GROUP5_PROJECT.Model;

public partial class ProjectPrnContext : DbContext
{
    public ProjectPrnContext()
    {
    }

    public ProjectPrnContext(DbContextOptions<ProjectPrnContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var conf = new ConfigurationBuilder().AddJsonFile("appsetting.json").Build();
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(conf.GetConnectionString("DBConnection"));
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Username);

            entity.ToTable("Account");

            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Address).IsRequired();
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email)
                .IsRequired()
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasColumnName("First Name");
            entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasColumnName("Last Name");
            entity.Property(e => e.Password)
                .IsRequired()
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .IsRequired()
                .IsUnicode(false)
                .HasColumnName("Phone Number");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Maloai);

            entity.ToTable("Category");

            entity.Property(e => e.Maloai)
                .ValueGeneratedNever()
                .HasColumnName("MALOAI");
            entity.Property(e => e.Loaisp)
                .IsRequired()
                .HasColumnName("LOAISP");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Makh);

            entity.ToTable("CUSTOMER");

            entity.Property(e => e.Makh)
                .ValueGeneratedNever()
                .HasColumnName("MAKH");
            entity.Property(e => e.Diachi).IsRequired();
            entity.Property(e => e.DienThoai)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Tenkh)
                .IsRequired()
                .HasColumnName("TENKH");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Mahd);

            entity.ToTable("Invoice");

            entity.Property(e => e.Mahd)
                .ValueGeneratedNever()
                .HasColumnName("MAHD");
            entity.Property(e => e.Makh).HasColumnName("MAKH");
            entity.Property(e => e.Manv)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MANV");
            entity.Property(e => e.Ngayban)
                .HasColumnType("date")
                .HasColumnName("NGAYBAN");
            entity.Property(e => e.Tongtien)
                .HasColumnType("money")
                .HasColumnName("TONGTIEN");

            entity.HasOne(d => d.MakhNavigation).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.Makh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoice_CUSTOMER");

            entity.HasOne(d => d.ManvNavigation).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.Manv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoice_Account");
        });

        modelBuilder.Entity<InvoiceDetail>(entity =>
        {
            entity.HasKey(e => e.Mahddt);

            entity.ToTable("InvoiceDetail");

            entity.Property(e => e.Mahddt)
                .ValueGeneratedNever()
                .HasColumnName("MAHDDT");
            entity.Property(e => e.Dongia)
                .HasColumnType("money")
                .HasColumnName("DONGIA");
            entity.Property(e => e.Giamgia).HasColumnName("GIAMGIA");
            entity.Property(e => e.Mahd).HasColumnName("MAHD");
            entity.Property(e => e.Masp).HasColumnName("MASP");
            entity.Property(e => e.Soluong).HasColumnName("SOLUONG");
            entity.Property(e => e.Thanhtien)
                .HasColumnType("money")
                .HasColumnName("THANHTIEN");

            entity.HasOne(d => d.MahdNavigation).WithMany(p => p.InvoiceDetails)
                .HasForeignKey(d => d.Mahd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceDetail_Invoice");

            entity.HasOne(d => d.MaspNavigation).WithMany(p => p.InvoiceDetails)
                .HasForeignKey(d => d.Masp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceDetail_Product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Masp);

            entity.ToTable("Product");

            entity.Property(e => e.Masp)
                .ValueGeneratedNever()
                .HasColumnName("MASP");
            entity.Property(e => e.Buy).HasColumnType("money");
            entity.Property(e => e.Image).IsRequired();
            entity.Property(e => e.Maloai).HasColumnName("MALOAI");
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.Tensp)
                .IsRequired()
                .HasColumnName("TENSP");

            entity.HasOne(d => d.MaloaiNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Maloai)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Category");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
