using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DemoMVC.Data;
//Class để tương tác với các bảng trong CSDL, cũng là được tạo từ tools
public partial class ShopContext : DbContext
{
    public ShopContext()
    {
    }

    public ShopContext(DbContextOptions<ShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chitietdonhang> Chitietdonhangs { get; set; }

    public virtual DbSet<Chitietgiohang> Chitietgiohangs { get; set; }

    public virtual DbSet<Donhang> Donhangs { get; set; }

    public virtual DbSet<Giohang> Giohangs { get; set; }

    public virtual DbSet<Hanghoa> Hanghoas { get; set; }

   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chitietdonhang>(entity =>
        {
            entity.HasKey(e => e.MaChiTiet).HasName("PK__CHITIETD__CDF0A114C3BAC94C");

            entity.ToTable("CHITIETDONHANG");

            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MaDonHangNavigation).WithMany(p => p.Chitietdonhangs)
                .HasForeignKey(d => d.MaDonHang)
                .HasConstraintName("FK__CHITIETDO__MaDon__4222D4EF");

            entity.HasOne(d => d.MaHangNavigation).WithMany(p => p.Chitietdonhangs)
                .HasForeignKey(d => d.MaHang)
                .HasConstraintName("FK__CHITIETDO__MaHan__4316F928");
        });

        modelBuilder.Entity<Chitietgiohang>(entity =>
        {
            entity.HasKey(e => e.MaChiTiet).HasName("PK__CHITIETG__CDF0A1148C238506");

            entity.ToTable("CHITIETGIOHANG");

            entity.HasOne(d => d.MaGioHangNavigation).WithMany(p => p.Chitietgiohangs)
                .HasForeignKey(d => d.MaGioHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHITIETGI__MaGio__3B75D760");

            entity.HasOne(d => d.MaHangNavigation).WithMany(p => p.Chitietgiohangs)
                .HasForeignKey(d => d.MaHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHITIETGI__MaHan__3C69FB99");
        });

        modelBuilder.Entity<Donhang>(entity =>
        {
            entity.HasKey(e => e.MaDonHang).HasName("PK__DONHANG__129584AD603C3675");

            entity.ToTable("DONHANG");

            entity.Property(e => e.TongTien).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MaGioHangNavigation).WithMany(p => p.Donhangs)
                .HasForeignKey(d => d.MaGioHang)
                .HasConstraintName("FK__DONHANG__MaGioHa__3F466844");
        });

        modelBuilder.Entity<Giohang>(entity =>
        {
            entity.HasKey(e => e.MaGioHang).HasName("PK__GIOHANG__F5001DA30BE3458E");

            entity.ToTable("GIOHANG");
        });

        modelBuilder.Entity<Hanghoa>(entity =>
        {
            entity.HasKey(e => e.MaHang).HasName("PK__HANGHOA__19C0DB1D8DD78B3D");

            entity.ToTable("HANGHOA");

            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TenHang).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
