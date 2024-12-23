using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KKNDotNetCore.ConsoleAppEFCore.Database.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblBlog> TblBlogs { get; set; }

    public virtual DbSet<TblLogEvent> TblLogEvents { get; set; }

    public virtual DbSet<TblPieChart> TblPieCharts { get; set; }

    public virtual DbSet<TblPizza> TblPizzas { get; set; }

    public virtual DbSet<TblPizzaExtra> TblPizzaExtras { get; set; }

    public virtual DbSet<TblPizzaOrder> TblPizzaOrders { get; set; }

    public virtual DbSet<TblPizzaOrderDetail> TblPizzaOrderDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=DotNetTraining;User ID=sa;Password=root;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblBlog>(entity =>
        {
            entity.HasKey(e => e.BlogId);

            entity.ToTable("Tbl_Blog");

            entity.Property(e => e.BlogAuthor)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.BlogContent)
                .HasMaxLength(225)
                .IsUnicode(false);
            entity.Property(e => e.BlogTitle)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblLogEvent>(entity =>
        {
            entity.ToTable("Tbl_LogEvents");

            entity.Property(e => e.TimeStamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblPieChart>(entity =>
        {
            entity.HasKey(e => e.PieChartId);

            entity.ToTable("Tbl_PieChart");

            entity.Property(e => e.PieChartName)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.PieChartValue).HasColumnType("numeric(18, 2)");
        });

        modelBuilder.Entity<TblPizza>(entity =>
        {
            entity.HasKey(e => e.PizzaId);

            entity.ToTable("Tbl_Pizza");

            entity.Property(e => e.Pizza)
                .HasMaxLength(225)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<TblPizzaExtra>(entity =>
        {
            entity.HasKey(e => e.PizzaExtraId).HasName("PK_Tbl_PizzaExtra1");

            entity.ToTable("Tbl_PizzaExtra");

            entity.Property(e => e.PizzaExtraName)
                .HasMaxLength(225)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<TblPizzaOrder>(entity =>
        {
            entity.HasKey(e => e.PizzaOrderId);

            entity.ToTable("Tbl_PizzaOrder");

            entity.Property(e => e.PizzaOrderInvoiceNo)
                .HasMaxLength(225)
                .IsUnicode(false);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<TblPizzaOrderDetail>(entity =>
        {
            entity.HasKey(e => e.PizzaOrderDetailId);

            entity.ToTable("Tbl_PizzaOrderDetail");

            entity.Property(e => e.PizzaOrderInvoiceNo)
                .HasMaxLength(225)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
