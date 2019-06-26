namespace API.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Modelapi : DbContext
    {
        public Modelapi()
            : base("name=Modelapi")
        {
        }

        public virtual DbSet<BaiVietHeThong> BaiVietHeThongs { get; set; }
        public virtual DbSet<Chitietdonhang> Chitietdonhangs { get; set; }
        public virtual DbSet<Donhang_KhachHang> Donhang_KhachHang { get; set; }
        public virtual DbSet<GroupSupport> GroupSupports { get; set; }
        public virtual DbSet<HangSX> HangSXes { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public virtual DbSet<Medium> Media { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<QuangCao> QuangCaos { get; set; }
        public virtual DbSet<Sanpham> Sanphams { get; set; }
        public virtual DbSet<Support> Supports { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tbvisistor> tbvisistors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Donhang_KhachHang>()
                .Property(e => e.DTnguoinhan)
                .IsUnicode(false);

            modelBuilder.Entity<Donhang_KhachHang>()
                .Property(e => e.EmailnguoiNhan)
                .IsUnicode(false);

            modelBuilder.Entity<GroupSupport>()
                .Property(e => e.Lang)
                .IsUnicode(false);

            modelBuilder.Entity<HangSX>()
                .Property(e => e.Website)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Dienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiSanPham>()
                .Property(e => e.Hinhanh)
                .IsUnicode(false);

            modelBuilder.Entity<Sanpham>()
                .HasMany(e => e.Chitietdonhangs)
                .WithOptional(e => e.Sanpham)
                .HasForeignKey(e => e.IdSanPham);

            modelBuilder.Entity<Support>()
                .Property(e => e.Nick)
                .IsUnicode(false);
        }
    }
}
