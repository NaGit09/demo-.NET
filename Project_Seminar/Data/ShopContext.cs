using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Project_Seminar.Data;

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

    public virtual DbSet<Taikhoan> Taikhoans { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=VanTran\\VANTRAN;Initial Catalog=Shop;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chitietdonhang>(entity =>
        {
            entity.HasKey(e => e.MaChiTiet).HasName("PK__CHITIETD__CDF0A114D8126C75");

            entity.ToTable("CHITIETDONHANG");

            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MaDonHangNavigation).WithMany(p => p.Chitietdonhangs)
                .HasForeignKey(d => d.MaDonHang)
                .HasConstraintName("FK__CHITIETDO__MaDon__4222D4EF");

            entity.HasOne(d => d.MaHangNavigation).WithMany(p => p.Chitietdonhangs)
                .HasForeignKey(d => d.MaHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHITIETDO__MaHan__4316F928");
        });

        modelBuilder.Entity<Chitietgiohang>(entity =>
        {
            entity.HasKey(e => e.MaChiTiet).HasName("PK__CHITIETG__CDF0A114B5EBD8D8");

            entity.ToTable("CHITIETGIOHANG");

            entity.HasOne(d => d.MaGioHangNavigation).WithMany(p => p.Chitietgiohangs)
                .HasForeignKey(d => d.MaGioHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHITIETGI__MaGio__3E52440B");

            entity.HasOne(d => d.MaHangNavigation).WithMany(p => p.Chitietgiohangs)
                .HasForeignKey(d => d.MaHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHITIETGI__MaHan__3F466844");
        });

        modelBuilder.Entity<Donhang>(entity =>
        {
            entity.HasKey(e => e.MaDonHang).HasName("PK__DONHANG__129584ADE2A96E0D");

            entity.ToTable("DONHANG");

            entity.Property(e => e.TongTien).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MaGioHangNavigation).WithMany(p => p.Donhangs)
                .HasForeignKey(d => d.MaGioHang)
                .HasConstraintName("FK__DONHANG__MaGioHa__3B75D760");
        });

        modelBuilder.Entity<Giohang>(entity =>
        {
            entity.HasKey(e => e.MaGioHang).HasName("PK__GIOHANG__F5001DA38707E50E");

            entity.ToTable("GIOHANG");

            entity.HasOne(d => d.KhachHang).WithMany(p => p.Giohangs)
                .HasForeignKey(d => d.KhachHangId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_id");
        });

        modelBuilder.Entity<Hanghoa>(entity =>
        {
            entity.HasKey(e => e.MaHang).HasName("PK__HANGHOA__19C0DB1D7E211A3E");

            entity.ToTable("HANGHOA");

            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TenHang).HasMaxLength(255);
        });

        modelBuilder.Entity<Taikhoan>(entity =>
        {
            entity.HasKey(e => e.KhachHangId).HasName("PK__TAIKHOAN__880F21FB88226ABF");

            entity.ToTable("TAIKHOAN");

            entity.Property(e => e.KhachHangId).ValueGeneratedNever();
            entity.Property(e => e.MatKhau)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
